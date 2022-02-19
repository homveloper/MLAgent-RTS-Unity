using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePositionNavMesh : MonoBehaviour, IMovePosition
{
    private NavMeshAgent agent;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void SetMovePosition(Vector3 movePosition)
    {
        agent.SetDestination(movePosition);

        Stop(false);
    }

    public void Stop(bool isStopped){
        agent.isStopped = isStopped;
    }
}
