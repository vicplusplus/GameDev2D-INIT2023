using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour, Controls.IInGameActions
{
    public CharacterController CurrentCharacter;

    private Vector2 _move;

    void Controls.IInGameActions.OnMove(InputAction.CallbackContext context)
    {
        if (CurrentCharacter != null)
        {
            CurrentCharacter.MoveDirection = context.ReadValue<Vector2>();
        }
    }


}
