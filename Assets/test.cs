using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Color color;

    // Start is called before the first frame update
    public void ChangeColor()
    {
        GetComponent<MeshRenderer>().material.color = color;
    }
}
