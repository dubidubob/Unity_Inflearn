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
        Bind<Button>(typeof(Buttons));//�� enum Ÿ���� �ѱ�ڴ�.
        Bind<TextMeshProUGUI>(typeof(Texts));// <T> : �� �߿� TextMeshPro��� component�� ã�Ƽ� �������ּ���.
        //Bind<GameObject>(typeof(GameObjects));

        //Get<Text>((int)Texts.ScoreText).text = "Bind Test";
        GetTextUI((int)Texts.ScoreText).text = "Bind Test";

    }
    
    int _score = 0;
    public void OnButtonClicked()
    {
        _score++;
        _text.text = $"���� : {_score}";
    }
}
