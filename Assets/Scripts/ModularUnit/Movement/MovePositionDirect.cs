using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMoveVelocity))]
public class MovePositionDirect : MonoBehaviour, IMovePosition
{
    private Vector3 movePosition;
    public void SetMovePosition(Vector3 movePosition)
    {
        this.movePosition = movePosition;
    }


    public void Stop(bool isStopped)
    {
        this.movePosition = transform.position;
    }



    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = (movePosition - transform.position).normalized;
        if (Vector3.Distance(movePosition, transform.position) <0.2f) moveDir = Vector3.zero; // Stop moving when near
        GetComponent<IMoveVelocity>().SetVelocity(moveDir);      
    }
}
