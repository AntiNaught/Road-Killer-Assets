using UnityEngine;
using System.Collections;

public class RF_EventsManager : MonoBehaviour
{
    private static RF_EventsManager _instance;
    public static RF_EventsManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("RF Events Manager");
                _instance = go.AddComponent<RF_EventsManager>();
            }
            return _instance;
        }
    }

    /// <summary>
    /// 燃油耗尽
    /// </summary>
    event notify FuelUseUp;
    /// <summary>
    /// 玩家车辆爆炸
    /// </summary>
    event notify CarPlayerExplode;
    /// <summary>
    /// 经过加油站
    /// </summary>
    event notify AddFuelLoad;
    /// <summary>
    /// 踩上油迹
    /// </summary>
    event notify OilStain;
    /// <summary>
    /// 小角度撞击
    /// </summary>
    event notify<float> HugeFriction;

    public void fuelUseUp()
    {
        FuelUseUp();
    }

    public void AddListener(EventType type,notify method)
    {
        
    }

    public void Addlistener(EventType type,notify<float> method)
    {
        
    }
}

public enum EventType
{
    FuelUseUp,
    CarPlayerExplode,
    AddFuelLoad,
    OilStain,
    HugeFriction
}

public delegate void notify();
public delegate void notify<T>(T t);
public delegate void notify<T1,T2>(T1 t1,T2 t2);