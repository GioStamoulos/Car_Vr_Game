using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfDeath : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameManager>().activeObjects.Remove(other.gameObject);

        Destroy(other.gameObject);
    }
}
