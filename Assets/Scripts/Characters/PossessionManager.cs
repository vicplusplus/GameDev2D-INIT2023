using UnityEngine;

public class PossessionManager : MonoBehaviour
{
    public LayerMask CharacterLayers;
    private Rigidbody2D Body;
    private BoxCollider2D _bodyCollider;

    private void Awake()
    {
        _bodyCollider = GetComponent<BoxCollider2D>();
        Body = GetComponent<Rigidbody2D>();
    }

    public void Possess(CharacterController callingController)
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(
        Body.position + _bodyCollider.offset,
        _bodyCollider.size,
        0,
        CharacterLayers
        );

        for (int i = 0; i < hits.Length; i++)
        {
            Character temp = hits[i].GetComponent<Character>();
            if (temp != null && hits[i].gameObject != gameObject)
            {
                CharacterMovement oldCharacterMovement = callingController.Character.Movement;
                temp.Movement.MoveDirection = oldCharacterMovement.MoveDirection;
                temp.Movement.IsJumping = oldCharacterMovement.IsJumping;

                callingController.Character.Controller.enabled = true;
                temp.Controller.enabled = false;

                callingController.Character = temp;
            }
        }
    }

    public enum State
    {
        Idle,
        Confused,
        Possessed
    }
}