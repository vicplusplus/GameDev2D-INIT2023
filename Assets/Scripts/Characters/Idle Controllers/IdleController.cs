using UnityEngine;

public abstract class IdleController : MonoBehaviour
{
    protected CharacterMovement movement;

    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
    }
}