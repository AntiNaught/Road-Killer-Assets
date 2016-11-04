using UnityEngine;
using System.Collections;

public class CarCamera : MonoBehaviour {

    public Transform car;
    public float offset=10;
    public float y;

    void LateUpdate()
    {
        y = car.position.y + offset;
        transform.position = new Vector3(0, y, -10);
    }
}
