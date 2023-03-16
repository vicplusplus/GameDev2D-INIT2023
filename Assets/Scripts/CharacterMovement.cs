using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Physical Properties")]
    public float Speed;
    public float JumpSpeed;

    [Header("Ground Check Parameters")]
    public Vector2 GroundCheckSize;
    public float GroundCheckYOffset;
    public LayerMask GroundLayers;

    [HideInInspector] public Vector2 MoveDirection;
    [HideInInspector] public bool IsJumping;
    [SerializeField] private State _state;
    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _state = State.Falling;
    }

    private void FixedUpdate()
    {
        _body.velocity = new(Speed * MoveDirection.x, _body.velocity.y);

        switch(_state)
        {
            case State.Grounded:
                if(IsJumping)
                {
                    _body.velocity = new(_body.velocity.x, JumpSpeed);
                    _state = State.Jumping;
                }
                break;
            case State.Jumping:
                if(_body.velocity.y <= 0)
                {
                    _state = State.Falling;
                }
                break;
            case State.Falling:
                var hit = Physics2D.BoxCast(
                    _body.position + (GroundCheckYOffset + GroundCheckSize.y / 2) * Vector2.up, 
                    GroundCheckSize, 
                    0, 
                    Vector2.down, 
                    GroundCheckSize.y, 
                    GroundLayers
                );
                if(hit)
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
