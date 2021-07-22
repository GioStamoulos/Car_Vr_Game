using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour
{
    private Transform movingTransform;

    private Vector3 movementDirection;

    private float speed;

    public void GetValues(float speed)
    {
        this.speed = speed;
    }

    public void Move()
    {
        movingTransform.position -= movementDirection * speed * Time.deltaTime;
    }

    public MovementBehaviour(Transform movingTransform, Vector3 movementDirection, float speed)
    {
        this.movingTransform = movingTransform;
        this.movementDirection = movementDirection;
        this.speed = speed;
    }
}
