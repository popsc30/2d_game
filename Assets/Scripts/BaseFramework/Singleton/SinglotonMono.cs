using UnityEngine;

public class SinglotonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;
    public static T Instance
    {
        get
        {
            if (instance) return instance;
            return null;
        }
    }

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this as T;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}

