using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : UI_Base
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

    private void Start()
    {
        Bind<Button>(typeof(Buttons));//이 enum 타입을 넘기겠다.
        Bind<TextMeshProUGUI>(typeof(Texts));// <T> : 그 중에 TextMeshPro라는 component를 찾아서 맵핑해주세요.
        //Bind<GameObject>(typeof(GameObjects));

        //Get<Text>((int)Texts.ScoreText).text = "Bind Test";
        GetTextUI((int)Texts.ScoreText).text = "Bind Test";

    }
    
    int _score = 0;
    public void OnButtonClicked()
    {
        _score++;
        _text.text = $"점수 : {_score}";
    }
}
