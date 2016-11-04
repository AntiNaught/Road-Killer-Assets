using UnityEngine;
using System.Collections;

public class CameraShakeEffect : MonoBehaviour {

    private static CameraShakeEffect _instance;
    public static CameraShakeEffect Instance{ get { return _instance; } }

    public float shakeTime=0.2f;
    public float countTime=0;
    private Vector3 deltaPos=Vector3.zero;
    private bool shake = false;

    void Start()
    {
        _instance = this;
    }

    void Update()
    {
        if (countTime < shakeTime)
        {
            //shake
            transform.localPosition -= deltaPos;
            deltaPos = Random.insideUnitSphere / 7.0f;
            transform.localPosition += deltaPos;
            //count time
            countTime += Time.deltaTime;
        }
    }

    public void Shake(float _relativeSpeed)
    {
        countTime = 0;
    }

    public void StopShaking()
    {
        shake = false;
        transform.localPosition = Vector3.zero;
    }
}


