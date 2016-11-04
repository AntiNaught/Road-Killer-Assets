using UnityEngine;
using System.Collections;

public class CarPlayer : MonoBehaviour,IEventHandler
{

    private static CarPlayer _instance;

    public static CarPlayer Instance{ get { return _instance; } }

    public int Distance{ get { return (int)transform.position.y; } }

    public readonly float maxSpeed = 35;
    public float totalDistance;

    [SerializeField]
    float speed;
    float interval;
    bool canSpeedUp = true;
    bool canTurn = true;
    //max_deceleration=max_Acceleration = max_speed*dece_speedRatio
    public float deceleration = 4;
    public float dece_speedRatio = 0.3f;
    public float maxFuelLoad = 100;
    public float currentFuelLoad = 0;
    public float baseFuelConsumeSpeed = 2;
    public float extraFuelConsume;

    #region Mono

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        interval = Time.fixedDeltaTime;
        currentFuelLoad = maxFuelLoad;
    }

    void FixedUpdate()
    {
        //运动
        transform.position += speed * transform.up * interval;

        //摩擦力
        if (speed > 0)
        {
            speed -= deceleration * interval;
            canTurn = true;
        }
        else if (speed < 0)
        {
            speed = 0;
            canTurn = false;
        }

        //燃油消耗
        if (!(currentFuelLoad < 0))
            currentFuelLoad = currentFuelLoad - (baseFuelConsumeSpeed + extraFuelConsume) * interval;
        else
        {
            //燃油消耗玩了
        }
        InfoDisplay.Instance.DisplayFuelRatio(currentFuelLoad / maxFuelLoad);
    }

    #endregion Mono

    #region API

    public void Speedup(float _acceleration)
    {
        if (!canSpeedUp)
            return;
        speed += _acceleration * interval;
        deceleration = speed * dece_speedRatio;
        extraFuelConsume = _acceleration * 0.3f;

        InfoDisplay.Instance.RotateSpeedoPointer(speed);
        InfoDisplay.Instance.RotateTachoPointer(speed);
    }

    public void Turn(float hInput)
    {
        if (!canTurn)
            return;
        float offsetAngle = hInput * 60;
        transform.rotation = Quaternion.Euler(0, 0, -offsetAngle);
    }

    #endregion API

    #region Events Stuff
    readonly string[] events = new string[4]
        {
            RF_Config.events.addFuel,
            RF_Config.events.useUpFuel,
            RF_Config.events.hugeFriction,
            RF_Config.events.carPlayerExplode
        };

    void OnEnable()
    {
        for (int i = 0; i < events.Length; i++)
        {
            EventManager.Instance.AddListener(events[i], this);
        }
    }

    void OnDisable()
    {
        for (int i = 0; i < events.Length; i++)
        {
            EventManager.Instance.RemoveEventListener(events[i]);
        }
    }

    public void OnEventExecute(string type, object data)
    {
        switch (type)
        {
            case RF_Config.events.addFuel:
                currentFuelLoad += 50;
                if (currentFuelLoad > maxFuelLoad)
                    currentFuelLoad = maxFuelLoad;
                canSpeedUp = true;
                break;
            case RF_Config.events.useUpFuel:
                Debug.Log("燃油耗尽");
                canSpeedUp = false;
                Debug.Log("全速前进没油的时间是" + Time.time);
                break;
            case RF_Config.events.carPlayerExplode:
                Debug.Log("车炸了，全部都炸了");
                break;
            case RF_Config.events.oilStain:
                Debug.Log("车滑了一下");
                break;
            case RF_Config.events.hugeFriction:
                float factor = (float)data;
                speed *= (1 + factor);
                Debug.Log("大大的减速" + factor);
                break;
            default:
                break;
        }
    }
    #endregion
}
