using UnityEngine;
using System.Collections;

public class TilingRoad : MonoBehaviour
{
    RoadTilingManager parent;

    void Awake()
    {
        parent = GetComponentInParent<RoadTilingManager>();
    }

    void Start()
    {
        parent.ToInVisibleCollection(this);
    }

    public void TilingForward()
    {
        parent.AvailableRoad.position = transform.position + 10 * Vector3.up;
    }

    void OnBecameVisible()
    {
        parent.ToVisibleCollection(this);
        TilingForward();
    }

    void OnBecameInvisible()
    {
        parent.ToInVisibleCollection(this);
    }
}
