using System;
using UnityEngine;

[RequireComponent(typeof(CarController))]
public class CarUserControl : MonoBehaviour
{
    CarController controller;

    void Awake()
    {
        controller = GetComponent<CarController>();
    }

    void FixedUpdate()
    {
      

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float handbrake = Input.GetAxis("Jump");
        controller.Move(h, v, v, handbrake);
    }
}
