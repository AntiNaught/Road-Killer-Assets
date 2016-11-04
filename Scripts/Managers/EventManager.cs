using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager {

    private static EventManager _instance;
    public static EventManager Instance{ 
        get 
        {
            if (_instance == null)
                _instance = new EventManager();
            return _instance; 
        } 
    }

    private Dictionary<string,List<IEventHandler>> dic_Handler;
    EventManager()
    {
        dic_Handler = new Dictionary<string, List<IEventHandler>>();
    }

    /// <summary>
    /// Add Event Interception
    /// </summary>
    /// <param name="type">Type.</param>
    /// <param name="listener">Listener.</param>
    public void AddListener(string type,IEventHandler listener)
    {
        if (!dic_Handler.ContainsKey(type))
            dic_Handler.Add(type, new List<IEventHandler>());
        dic_Handler[type].Add(listener);
    }

    /// <summary>
    /// 移除 type 类事件的所有监听
    /// </summary>
    /// <param name="type">Type.</param>
    public void RemoveEventListener(string type)
    {
        if (dic_Handler.ContainsKey(type))
            dic_Handler.Remove(type);
    }

    /// <summary>
    /// 移除监听者的多有监听
    /// </summary>
    public void ClearEventListener(IEventHandler listener)
    {
        foreach (var item in dic_Handler)
        {
            if (item.Value.Contains(listener))
            {
                item.Value.Remove(listener);
            }
        }
    }

    public void ClearEventListener()
    {
        Debug.Log("清空对所有事件的监听");
        if (dic_Handler != null)
            dic_Handler.Clear();
    }

    /// <summary>
    /// 事件派发
    /// </summary>
    /// <param name="type">Type.</param>
    /// <param name="data">Data.</param>
    public void DispachEvent(string type,object data=null)
    {
        if (!dic_Handler.ContainsKey(type))
        {
            Debug.Log("Did not add any IEventHandler of"+type+"in EventManager!");
            return;
        }

        List<IEventHandler> list = dic_Handler[type];
        for (int i = 0; i < list.Count; i++)
        {
            list[i].OnEventExecute(type, data);
        }
    }
}

public interface IEventHandler
{
    void OnEventExecute(string type, object data);
}