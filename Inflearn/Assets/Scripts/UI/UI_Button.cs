using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    //Dictionary<Type, UnityEngine.Object[]>
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

    private void Start()
    {
        Bind<Button>(typeof(Buttons));//이 enum 타입을 넘기겠다.
        Bind<Text>(typeof(Texts));// <T> : 그 중에 Text라는 component를 찾아서 맵핑해주세요.
    }
    void Bind<T>(Type type)
    {
        string[] names = Enum.GetNames(type);

        
    }

    int _score = 0;
    public void OnButtonClicked()
    {
        _score++;
        _text.text = $"점수 : {_score}";
    }
}
