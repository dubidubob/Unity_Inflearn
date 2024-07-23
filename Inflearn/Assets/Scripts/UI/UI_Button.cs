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
        Bind<Button>(typeof(Buttons));//�� enum Ÿ���� �ѱ�ڴ�.
        Bind<Text>(typeof(Texts));// <T> : �� �߿� Text��� component�� ã�Ƽ� �������ּ���.
    }
    void Bind<T>(Type type)
    {
        string[] names = Enum.GetNames(type);

        
    }

    int _score = 0;
    public void OnButtonClicked()
    {
        _score++;
        _text.text = $"���� : {_score}";
    }
}
