using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager //for managing sort order of canvas, sort order save and load
{
    int _order = 10;

    //FILO
    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    UI_Scene _sceneUI = null;

    public GameObject Root
    {
        get 
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject { name = "@UI_Root" };
            return root;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true; //2nd canvas, whatever my parent sorting order is, i will have my own

        if (sort)
        {
            canvas.sortingOrder = (_order);
            _order++;
        }
        else
            canvas.sortingOrder = 0;

    }

    public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/SubItem/{name}");
        if (parent != null)
            go.transform.SetParent(parent);

        return Util.GetOrAddComponent<T>(go);
    }


    public T ShowSceneUI<T>(string name = null) where T : UI_Scene//name of prefab & T is inherit of UI_Popup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;//extract the type into string

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");
        T sceneUI = Util.GetOrAddComponent<T>(go);
        _sceneUI = sceneUI;

        go.transform.SetParent(Root.transform);

        return sceneUI;
    }

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup//name of prefab & T is inherit of UI_Popup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;//extract the type into string

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        T popup =Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);

        go.transform.SetParent(Root.transform);

        return popup;
    }

    public void ClosePopupUI(UI_Popup popup)//an jeon bbang
    {
        if (_popupStack.Count == 0) // if you use stack, cound shold always be checked
            return;

        if (_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed!");
            return;
        }

        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;
        _order--;
    }

    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }

}
