using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoolData
{  
    public GameObject fatherObj;
    public Queue<GameObject> queueObj;

    public PoolData(GameObject father,GameObject obj)
    {
        fatherObj = new GameObject();
        fatherObj.name = obj.name;
        fatherObj.transform.SetParent(father.transform);
        Push(obj);
    }
    public void Push(GameObject obj)
    {
        queueObj.Enqueue(obj);
        obj.SetActive(false);
        obj.transform.SetParent(fatherObj.transform);
    }
    public GameObject Get()
    {
       GameObject obj=   queueObj.Dequeue();
        obj.SetActive(true);
        obj.transform.SetParent(null);
        return obj;
    }
}

public class PoolManager : BaseManager<PoolManager>
{
    private Dictionary<string, PoolData> dicPool = new Dictionary<string, PoolData>();
    private GameObject fatherObj;

    public void PushObj(string Objname,GameObject obj)
    {
         if(fatherObj==null)
        {
            fatherObj = new GameObject();
            fatherObj.name = "PoolManager";
        }
         if(dicPool.ContainsKey(Objname))
        {
            dicPool[Objname].Push(obj);
        }
         else
        {
           
            dicPool.Add(Objname, new PoolData(fatherObj, obj));
        }
    }
    public void GetObj(string Objname,UnityAction<GameObject> action = null)
    {
        if(dicPool.ContainsKey(Objname))
        {
           GameObject obj =  dicPool[Objname].Get();
            action.Invoke(obj);
        }
        else
        {
            ResourcesManager.Instance.LoadAsync<GameObject>(Objname, action);
        }
    }
    public void Clear()
    {
        dicPool.Clear();
        fatherObj = null;
    }
}
