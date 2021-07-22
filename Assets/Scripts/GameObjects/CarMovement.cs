using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarMovement : MonoBehaviour
{
    public Transform camera;
    public Transform carTransform;

    public float roadXScale = 10;


    public float turnSpeed = -0.01f;

    public void StartEngine()
    {
        FindObjectOfType<SoundManager>().Play("CarVoice");
    }
    public void  StopEngine()
    {
        FindObjectOfType<SoundManager>().Stop("CarVoice");
    }

    private void Awake()
    {
        carTransform = transform;
    }

    void Update()
    {
        carTransform.eulerAngles = new Vector3(0, -camera.eulerAngles.z, 0);

        if (Math.Abs(carTransform.position.x) <= (roadXScale / 2))
        {
            carTransform.position += new Vector3(Mathf.Sin(camera.localRotation.z) * turnSpeed, 0, 0);
        }
        else if (carTransform.position.x < 0)
        {
            carTransform.position = new Vector3(-roadXScale / 2, 0, 0);
        }
        else
        {
            carTransform.position = new Vector3((roadXScale) / 2, 0, 0);
        }

    }

    public float CorrectedAngle(float inputFloat)
    {

        return inputFloat;
    }

}
