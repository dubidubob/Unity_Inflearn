using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object //find the original
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        // 1. if origin is there, use rightly.
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");//original prefab is loaded in memory
        if (prefab == null)
        {
            Debug.Log($"Failed to Load Prefab : { path}");
            return null;
        }

        // 2. if there any pooled object?
        GameObject go = Object.Instantiate(prefab, parent);//copy, go to parent's child
        go.name = prefab.name;

        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        // if pooling is needed, go to pool manager
        Object.Destroy(go);
    }
}
