using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour {

    private static InfoDisplay _instance;
    public static InfoDisplay Instance{ get { return _instance; } }

    public Transform speedoPointer; //速度表指针
    public Transform tachoPointer;  //转速表指针
    public Slider oilMeter;      //油表
    public Transform totalDistance; //总行程
    public Transform steerWheel;    //方向盘

    #region Config
    public float maxAngle_steerWheel=60;
    public float maxAngle_speedo = 200;
    public float maxAngle_tacho = 250;

    #endregion

    void Awake()
    {
        _instance = this;
    }

    #region APIs
    public void RotateSteerWheel(float input)
    {
        steerWheel.transform.rotation = Quaternion.Euler(0, 0, -input * maxAngle_steerWheel);
    }

    public void RotateSpeedoPointer(float speed)
    {
        float angle = -speed * maxAngle_speedo / RF_Config.maxSpeed;
        speedoPointer.rotation = Quaternion.Euler(0,0,angle);
    }

    public void RotateTachoPointer(float speed)
    {
        float value = speed % 10;
        float angle = value * maxAngle_tacho / 10;
        tachoPointer.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void DisplayFuelRatio(float _value)
    {
        oilMeter.value = _value;
    }
    #endregion
}
