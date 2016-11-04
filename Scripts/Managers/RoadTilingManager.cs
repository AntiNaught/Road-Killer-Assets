using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoadTilingManager : MonoBehaviour {

    public Transform AvailableRoad{ get { return invisibleRoads[0].transform; } }

    List<TilingRoad> visibleRoads;
    List<TilingRoad> invisibleRoads;

    public TilingRoad[] roads;

    void Awake()
    {
        roads = GetComponentsInChildren<TilingRoad>();
        visibleRoads = new List<TilingRoad>();
        invisibleRoads = new List<TilingRoad>();
    }

    public void ToVisibleCollection(TilingRoad _road)
    {
        visibleRoads.Add(_road);
        invisibleRoads.Remove(_road);
    }

    public void ToInVisibleCollection(TilingRoad _road)
    {
        invisibleRoads.Add(_road);
        visibleRoads.Remove(_road);
    }
}
