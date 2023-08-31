using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public enum E_UI_Layer
{
    Bot,
    Mid,
    Top,
    System,
}

public class UIManager : BaseManager<UIManager>
{
    public Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();

    private Transform bot;
    private Transform mid;
    private Transform top;
    private Transform system;

    public RectTransform canvas;

    public UIManager()
    {
        GameObject obj = ResourcesManager.Instance.LoadRes<GameObject>("UI/UICanvas");
        canvas = obj.transform as RectTransform;
        GameObject.DontDestroyOnLoad(obj);

        bot = canvas.Find("Bot");
        mid = canvas.Find("Mid");
        top = canvas.Find("Top");
        system = canvas.Find("System");

    }

    public Transform GetLayerFather(E_UI_Layer layer)
    {
        switch(layer)
        {
            case E_UI_Layer.Bot:
                return this.bot;
            case E_UI_Layer.Mid:
                return this.mid;
            case E_UI_Layer.Top:
                return this.top;
            case E_UI_Layer.System:
                return this.system;
        }
        return null;
    }

    public void ShowPanel<T>( E_UI_Layer layer = E_UI_Layer.Mid, UnityAction<T> callBack = null) where T:BasePanel
    {
       string  panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].ShowMe();
            if (callBack != null)
                callBack(panelDic[panelName] as T);
            return;
        }

        ResourcesManager.Instance.LoadAsync<GameObject>("UI/UIPanel/" + panelName, (obj) =>
        {
            Transform father = bot;
            switch(layer)
            {
                case E_UI_Layer.Mid:
                    father = mid;
                    break;
                case E_UI_Layer.Top:
                    father = top;
                    break;
                case E_UI_Layer.System:
                    father = system;
                    break;
            }
            obj.transform.SetParent(father);

            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;

            (obj.transform as RectTransform).offsetMax = Vector2.zero;
            (obj.transform as RectTransform).offsetMin = Vector2.zero;

            T panel = obj.GetComponent<T>();
            if (callBack != null)
                callBack(panel);

            panel.ShowMe();
            panelDic.Add(panelName, panel);

        });
    }

    public void HidePanel<T>()
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].HideMe();
            GameObject.Destroy(panelDic[panelName].gameObject);
            panelDic.Remove(panelName);
        }
    }

    public T GetPanel<T>() where T:BasePanel
    {
       string name = typeof(T).Name;

        if (panelDic.ContainsKey(name))
            return panelDic[name] as T;
        return null;
    }

    public static void AddCustomEventListener(UIBehaviour control, EventTriggerType type, UnityAction<BaseEventData> callBack)
    {
        EventTrigger trigger = control.GetComponent<EventTrigger>();
        if (trigger == null)
            trigger = control.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.AddListener(callBack);
        trigger.triggers.Add(entry);
    }

}
