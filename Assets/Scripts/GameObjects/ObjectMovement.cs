using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    void Update()
    {
        transform.position -= Vector3.forward * 1 * Time.deltaTime;
    }
}
