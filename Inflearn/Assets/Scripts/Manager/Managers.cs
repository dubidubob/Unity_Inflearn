using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    #region Singleton
    static Managers s_instance; //���ϼ��� ����ȴ�
    static Managers Instance { get { Init(); return s_instance; } } //������ �Ŵ����� �����´�

    InputManager _input = new InputManager();
    ResourceManager _resource = new ResourceManager();
    UIManager _ui = new UIManager();
    PoolManager _pool = new PoolManager();

    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static UIManager UI { get { return Instance._ui; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    void Start()
    {
        Init();
    }

    void Update()
    {
        _input.OnUpdate();
    }


    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }
    #endregion
}