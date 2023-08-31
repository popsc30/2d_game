using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ResourcesManager : BaseManager<ResourcesManager>
{
    public T LoadRes<T>(string pathName) where T : Object
    {
        T obj = Resources.Load<T>(pathName) ;

        if(obj is GameObject)
        {
            GameObject o = GameObject.Instantiate(obj) as GameObject;
            o.name = pathName;
            return o as T;
        }
        else
        {
            return obj;
        }
    }


    public void LoadAsync<T>(string pathName,UnityAction<T> callBack ) where T:Object
    {
        MonoManager.Instance.StartCoroutine(ReallyLoadAsync<T>(pathName, callBack));
    }

    private IEnumerator ReallyLoadAsync<T>(string pathName, UnityAction<T> callBack ) where T :Object
    {
        ResourceRequest res = Resources.LoadAsync<T>(pathName);
        yield return res;
      
        if (res.asset is GameObject)
        {
            T obj = GameObject.Instantiate(res.asset) as T;
       
            obj.name = pathName;
            callBack.Invoke(obj);

        }
        else
        {
            //res.asset.name = pathName;
           callBack.Invoke(res.asset as T);
        }
    }
   
}
