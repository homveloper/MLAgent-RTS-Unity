using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMoveVelocity))]
public class MovementInput : MonoBehaviour {

    private IMoveVelocity move;

    private void Awake() {
        move = GetComponent<IMoveVelocity>();
    }

    private void Update() {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(moveX, moveY).normalized;
        move.SetVelocity(moveVector);
    }
}