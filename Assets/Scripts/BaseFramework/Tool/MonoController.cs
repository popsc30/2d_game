using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class MonoController : MonoBehaviour
{
    private UnityAction updateEvent = null;

    // Update is called once per frame
    void Update()
    {
         if(updateEvent !=null)
        {
            updateEvent.Invoke();
        }
    }
    public void AddUpdateListener(UnityAction action)
    {
        updateEvent += action;
    }
    public void RemoveUpdateListener(UnityAction action)
    {
        updateEvent -= action;
    }
    public void Timer(float time, UnityAction callback)
    {
        StartCoroutine(TimerCoroutine(time, callback));
    }
    private IEnumerator TimerCoroutine(float time, UnityAction callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }

}
