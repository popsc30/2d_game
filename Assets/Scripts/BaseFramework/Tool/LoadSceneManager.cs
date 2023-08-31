using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LoadSceneManager : BaseManager<LoadSceneManager>
{
    public void LoadScene(string sceneName,UnityAction action=null)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadAsyncScene(string sceneName,UnityAction action = null)
    {
        MonoManager.Instance.StartCoroutine(ReallyLoadAsyncScene(sceneName, action));
    }
    public void LoadAsyncAnimScene(string sceneName,float time=0, UnityAction action = null)
    {
        MonoManager.Instance.StartCoroutine(ReallyLoadAnimAsyncScene(sceneName, time, action));
    }

    private IEnumerator ReallyLoadAnimAsyncScene(string sceneName,float time=0,UnityAction action =null)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
        ao.allowSceneActivation = false;
        yield return new WaitForSeconds(0.5f);
        EventCenter.Instance.Clear();
        bool isLoad = false;
        float t = 0;
        float ti = 0;
        float len = 1000;
     
        while (!isLoad)
        {
            if(t>=1000)
            {
                isLoad = true;
             
                ao.allowSceneActivation = true;
             
                break;
            }
            ti += Time.deltaTime;

            t = len * (ti / time);
          
            yield return null;
        }
        if(action!=null)
        action.Invoke();
    }
    private IEnumerator ReallyLoadAsyncScene(string sceneName, UnityAction action = null)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
        EventCenter.Instance.Clear();

        while (!ao.isDone)
        {

            yield return null;
        }
        if (action != null)
            action.Invoke();
    }

    public string GetNowSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

}
