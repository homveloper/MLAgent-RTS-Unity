using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridPathfindingSystem;

public class MovePositionPathfinding : MonoBehaviour , IMovePosition{
    private List<Vector3> pathVectorList;
    private int pathIndex = -1;

    private void Start() {
    }

    public void SetMovePosition(Vector3 movePosition)
    {
        pathVectorList = GridPathfinding.instance.GetPathRouteWithShortcuts(transform.position, movePosition).pathVectorList;
        if(pathVectorList.Count > 0)
        {
            pathIndex = 0;
        }
    }

    private void Update()
    {
        if(pathIndex != -1)
        {
            // Move to next path position
            Vector3 nextPathPosition = pathVectorList[pathIndex];
            Vector3 moveVelocity = (nextPathPosition - transform.position).normalized;
            GetComponent<IMoveVelocity>().SetVelocity(moveVelocity);

            float reachedPathPositionDistance = 0.2f;
            if(Vector3.Distance(transform.position, nextPathPosition) < reachedPathPositionDistance)
            {
                pathIndex++;
                if(pathIndex >= pathVectorList.Count)
                {
                    pathIndex = -1;
                }
            }
        }
        else{
            // Idle
            GetComponent<IMoveVelocity>().SetVelocity(Vector3.zero);
        }
    }


    public void Stop(bool isStopped)
    {
        pathIndex = -1;
        if(pathVectorList != null)
        {
            pathVectorList.Clear();
        }
    }
}