using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    // Detection Point
    public Transform detectionPoint;
    //Character
    public Character Character;
    // Detection Layer 
    public LayerMask detectionLayer;
    void Update()
    {
        if (DetectObject())
        {
            if(InteractInput())
            {
                Debug.Log("Interact");
            }
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.X);
    }

    bool DetectObject()
    {
        return Physics2D.OverlapBox(detectionPoint.position,
                                    Character.Movement.BodyCollider.size,
                                    detectionLayer);
    }
}
