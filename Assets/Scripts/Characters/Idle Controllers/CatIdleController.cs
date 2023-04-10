using UnityEngine;
public class CatIdleController : IdleController
{
    private static float ReachedTargetThreshold = 0.1f;
    public Transform Gravestone;

    private void FixedUpdate()
    {
        float catToGrave = Gravestone.position.x - movement.Body.position.x;
        if (Mathf.Abs(catToGrave) > ReachedTargetThreshold)
        {
            movement.MoveDirection = new Vector2(Mathf.Sign(catToGrave), 0);
        }
        else
        {
            movement.MoveDirection = Vector2.zero;
        }
    }
}