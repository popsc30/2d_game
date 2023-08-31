using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MonoManager : BaseManager<MonoManager>
{

    private MonoController monoController;
     public MonoManager()
    {
        GameObject obj = new GameObject();
        obj.name = "MonoManager";
        monoController = obj.AddComponent<MonoController>();
        GameObject.DontDestroyOnLoad(obj);
    }

    public void AddUpdateListener(UnityAction action)
    {
        monoController.AddUpdateListener(action);
    }
    public void RemoveUpdateListener(UnityAction action)
    {
        monoController.RemoveUpdateListener(action);
    }
    public Coroutine StartCoroutine(IEnumerator routine)
    {
        return monoController.StartCoroutine(routine);
    }
    public void StopCoroutine(IEnumerator routine)
    {
        monoController.StopCoroutine(routine);
    }
    public void Timer(float time, UnityAction callback)
    {
        monoController.Timer(time, callback);
    }

}
