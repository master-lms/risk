using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager _instance;
    public static ResourceManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new ResourceManager();

            return _instance;
        }
    }


    private void AsynLoadPrefab<T>(string path, Action<T> callBack = null) where T : UnityEngine.Object
    {
        if (string.IsNullOrEmpty(path))
        {
            Debug.Log("Error : C# ResourceManager, path not exsit, path = " + path);
            return;
        }

        T obj = Resources.Load<T>(path);
        if (callBack != null)
        {
            callBack.Invoke(obj);
        }
    }


    public void LoadPrefab(string path, Action<GameObject> cb)
    {
        AsynLoadPrefab(path, cb);
    }

    //private IEnumerator AsynLoadPrefab<T>(string path, Action<T> callBack) where T : UnityEngine.Object
    //{


    //    ResourceRequest req = Resources.LoadAsync<T>(path);


    //    while (!req.isDone)
    //    {
    //        yield return null;
    //    }
    //    //Resources.LoadAsync<T>(path);

    //    yield return null;
    //}
}
