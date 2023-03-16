using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, Controls.IInGameActions
{
    public CharacterMovement CurrentCharacter;

    private Vector2 _move;
    private Controls _controls;

    private void OnEnable()
    {
        if (_controls == null)
        {
            _controls = new Controls();
            _controls.InGame.SetCallbacks(this);
        }
        _controls.Enable();
    }

    void Controls.IInGameActions.OnInteract(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    void Controls.IInGameActions.OnJump(InputAction.CallbackContext context)
    {
        if (CurrentCharacter != null)
        {
            CurrentCharacter.IsJumping = context.ReadValueAsButton();
        }
    }

    void Controls.IInGameActions.OnMove(InputAction.CallbackContext context)
    {
        print("hi");
        if (CurrentCharacter != null)
        {
            CurrentCharacter.MoveDirection = context.ReadValue<Vector2>();
        }
    }

    void Controls.IInGameActions.OnPossess(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
