using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    { 
        GridPanel
    }

    void Start()
    {
        Init();
        
    }

    public override void Init()
    {
        base.Init();
        Bind < GameObject >(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach (Transform child in gridPanel.transform) //all the child is gone
            Managers.Resource.Destroy(child.gameObject);

        for (int i = 0; i < 8; i++)
        {
            GameObject item = Managers.Resource.Instantiate("UI/Scene/UI_Inven_Item");
            item.transform.SetParent(gridPanel.transform);

            UI_Inven_Item invenItem = Util.GetOrAddComponent<UI_Inven_Item>(item); //or addcomponent to ui_inven
            invenItem.SetInfo($"�����{i}��");
        }
    }

}
