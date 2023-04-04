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
    private Rigidbody2D _body;
    private State _state;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _state = State.Falling;
    }

    private void FixedUpdate()
    {
        _body.velocity = new(Speed * MoveDirection.x, _body.velocity.y);

        switch (_state)
        {
            case State.Grounded:
                if (IsJumping)
                {
                    _body.velocity = new(_body.velocity.x, JumpSpeed);
                    _state = State.Jumping;
                }
                break;
            case State.Jumping:
                if (_body.velocity.y <= 0)
                {
                    _state = State.Falling;
                }
                break;
            case State.Falling:
                var hit = Physics2D.BoxCast(
                    _body.position + BodyCollider.offset + ((BodyCollider.size.y - GroundCheckDistance) / 2) * Vector2.down,
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
