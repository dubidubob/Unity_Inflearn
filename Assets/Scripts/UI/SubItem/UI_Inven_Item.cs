using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Inven_Item : UI_Base
{
    //base.Init() is not allowed, cause it's abstract
    enum GameObjects
    { 
        ItemIcon,
        ItemNameText,
    }

    string _name;

    private void Start()
    {
        Init();
    }
    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<TextMeshProUGUI>().text = _name;

        Get<GameObject>((int)GameObjects.ItemIcon).BindEvent((PointerEventData => { Debug.Log($"������ Ŭ��! {_name}"); }));
    }

    public void SetInfo(string name)
    { _name = name; }
}
