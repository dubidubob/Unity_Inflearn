using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    [SerializeField] TextMeshProUGUI _text;

    enum Buttons
    {
        PointButton
    }

    enum Texts
    { 
        PointText,
        ScoreText
    }

    enum GameObjects
    {
        TestObject,
    }

    enum Images
    {
        ItemIcon,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));//�� enum Ÿ���� �ѱ�ڴ�.
        Bind<TextMeshProUGUI>(typeof(Texts));// <T> : �� �߿� TextMeshPro��� component�� ã�Ƽ� �������ּ���.
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);

        //UI_EventHandler evt = go.GetComponent<UI_EventHandler>();
        //evt.OnDragHandler += ((PointerEventData data) => { evt.gameObject.transform.position = data.position; });//Rect transform�� transform�� ����Ѵ�.
        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        AddUIEvent(go, ((PointerEventData data) => { go.gameObject.transform.position = data.position; }), Define.UIEvent.Drag);

    }

    int _score = 0;
    public void OnButtonClicked(PointerEventData data)
    {
        _score++;
        //Get<Text>((int)Texts.ScoreText).text = "Bind Test";
        GetTextUI((int)Texts.ScoreText).text = $"���� : {_score}";
    }
}
