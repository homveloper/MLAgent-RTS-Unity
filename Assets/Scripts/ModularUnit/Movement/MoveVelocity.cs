using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveVelocity : MonoBehaviour , IMoveVelocity{

    [SerializeField] private float moveSpeed;
    private Vector3 velocity;
    private Rigidbody2D rigidbody2D;

    private void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(Vector3 velocity)
    {
        this.velocity = velocity;
    }

    private void FixedUpdate() {
        rigidbody2D.velocity = velocity * moveSpeed;
    }

    public void SetSpeed(float speed)
    {
        this.moveSpeed = speed;
    }
}