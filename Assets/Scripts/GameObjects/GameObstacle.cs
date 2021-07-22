using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObstacle : MonoBehaviour
{
    public MovementBehaviour movementBehaviour;

    private void Awake()
    {
        movementBehaviour = new MovementBehaviour(transform, Vector3.forward, 2 * 5);//game speed
    }

    private void Update()
    {
        movementBehaviour.Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CarMovement>() != null)
        {
            
            FindObjectOfType<GameManager>().GameOver();
            FindObjectOfType<SoundManager>().Play("Crash");
            Debug.Log("You Lost the Game!");
        }
    }
}
