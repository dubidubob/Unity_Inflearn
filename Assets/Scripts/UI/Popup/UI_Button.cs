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

        Bind<Button>(typeof(Buttons));//이 enum 타입을 넘기겠다.
        Bind<TextMeshProUGUI>(typeof(Texts));// <T> : 그 중에 TextMeshPro라는 component를 찾아서 맵핑해주세요.
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);

        //UI_EventHandler evt = go.GetComponent<UI_EventHandler>();
        //evt.OnDragHandler += ((PointerEventData data) => { evt.gameObject.transform.position = data.position; });//Rect transform도 transform을 상속한다.
        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        AddUIEvent(go, ((PointerEventData data) => { go.gameObject.transform.position = data.position; }), Define.UIEvent.Drag);

    }

    int _score = 0;
    public void OnButtonClicked(PointerEventData data)
    {
        _score++;
        //Get<Text>((int)Texts.ScoreText).text = "Bind Test";
        GetTextUI((int)Texts.ScoreText).text = $"점수 : {_score}";
    }
}
