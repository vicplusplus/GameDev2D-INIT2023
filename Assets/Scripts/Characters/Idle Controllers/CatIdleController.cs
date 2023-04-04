using UnityEngine;
public class CatIdleController : IdleController
{
    private void OnEnable()
    {
        movement.MoveDirection = Vector2.zero;
        movement.IsJumping = false;
    }
}