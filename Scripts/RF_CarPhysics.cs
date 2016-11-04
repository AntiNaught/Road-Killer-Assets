using UnityEngine;
using System.Collections;

public class RF_CarPhysics : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
//        float relativeSpeed = other.relativeVelocity.magnitude;
        Vector2 Normal=other.contacts[0].normal;
        float value = Vector2.Dot(Normal , transform.up);
        //value的绝对值越小，则碰撞角越小 值从0到－1之间
//        Debug.Log("shake speed = " + value);
        if (Mathf.Abs(value) > 0.8f)
        {
            EventManager.Instance.DispachEvent(RF_Config.events.carPlayerExplode);
        }
        else
        {
            EventManager.Instance.DispachEvent(RF_Config.events.hugeFriction,value);
        }
        //镜头晃动 音效“哇哦” 
        CameraShakeEffect.Instance.Shake(1);
    }
}
