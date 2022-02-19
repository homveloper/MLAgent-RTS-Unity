using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransform  : MonoBehaviour , IMoveVelocity{

    [SerializeField] private float moveSpeed;
    private Vector3 velocity;

    private void Awake() {

    }

    public void SetVelocity(Vector3 velocity)
    {
        this.velocity = velocity;
    }


    private void Update() {
        transform.position += velocity * moveSpeed * Time.deltaTime;
    }

    public void SetSpeed(float speed)
    {
        this.moveSpeed = speed;
    }
}