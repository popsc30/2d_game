using UnityEngine;

public class SinglotonAutoMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject();
                instance = obj.AddComponent<T>();
                GameObject.DontDestroyOnLoad(obj);
                obj.name = typeof(T).Name;
            }
            return instance;
        }
    }
}
