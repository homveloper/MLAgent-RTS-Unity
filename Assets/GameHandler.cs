using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridPathfindingSystem;

public class GameHandler : MonoBehaviour
{
    public static GridPathfinding gridPathfinding;

    void Start()
    {
        gridPathfinding = new GridPathfinding(new Vector3(-20,-20), new Vector3(20,20), 0.5f);
        gridPathfinding.RaycastWalkable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
