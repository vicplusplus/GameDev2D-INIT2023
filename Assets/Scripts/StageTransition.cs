using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTransition : MonoBehaviour
{
    public Vector2 NewCameraPosition;
    public Vector2 NewBodyPosition;
    public Transform cameraTransform;
    public PlayerController controller;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform == controller.Character.transform)
        {
            cameraTransform.position = NewCameraPosition;
            controller.Character.Movement.Body.position = NewBodyPosition;
        }
    }
}
