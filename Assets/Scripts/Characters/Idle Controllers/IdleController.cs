using UnityEngine;

public abstract class IdleController : MonoBehaviour
{
    protected CharacterMovement movement;

    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
    }

    private void OnEnable()
    {
        movement.MoveDirection = Vector2.zero;
        movement.IsJumping = false;
    }
}