using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Physical Properties")]
    public float Speed;
    public float JumpSpeed;
    public BoxCollider2D BodyCollider;

    [Header("Ground Check Parameters")]
    public float GroundCheckDistance;
    public LayerMask GroundLayers;

    [HideInInspector] public Vector2 MoveDirection;
    [HideInInspector] public bool IsJumping;
    [HideInInspector] public Rigidbody2D Body;
    private State _state;

    private void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
        _state = State.Falling;
    }

    private void FixedUpdate()
    {
        if(Body.bodyType == RigidbodyType2D.Static) return;
        
        Body.velocity = new(Speed * MoveDirection.x, Body.velocity.y);

        switch (_state)
        {
            case State.Grounded:
                if (IsJumping)
                {
                    Body.velocity = new(Body.velocity.x, JumpSpeed);
                    _state = State.Jumping;
                }
                break;
            case State.Jumping:
                if (Body.velocity.y <= 0)
                {
                    _state = State.Falling;
                }
                break;
            case State.Falling:
                var hit = Physics2D.BoxCast(
                    Body.position + BodyCollider.offset + ((BodyCollider.size.y - GroundCheckDistance) / 2) * Vector2.down,
                    new Vector2(BodyCollider.size.x, GroundCheckDistance),
                    0,
                    Vector2.down,
                    GroundCheckDistance,
                    GroundLayers
                );
                if (hit)
                {
                    _state = State.Grounded;
                }
                break;
        }
    }

    private enum State
    {
        Grounded,
        Jumping,
        Falling
    }
}
