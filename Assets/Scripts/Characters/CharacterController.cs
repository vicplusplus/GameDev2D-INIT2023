using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour, Controls.IInGameActions
{
    public Character character;
    private Vector2 _moveDirection;
    private bool _isJumping;
    private bool _isPossessing;
    private bool _isInteracting;
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

    private void OnDisable()
    {
        _controls.Disable();
    }

    void Controls.IInGameActions.OnInteract(InputAction.CallbackContext context)
    {
        _isInteracting = context.ReadValueAsButton();
    }

    void Controls.IInGameActions.OnJump(InputAction.CallbackContext context)
    {
        _isJumping = context.ReadValueAsButton();
    }

    void Controls.IInGameActions.OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }

    void Controls.IInGameActions.OnPossess(InputAction.CallbackContext context)
    {
        if (context.started) {
            _isPossessing = context.ReadValueAsButton();
        }
    }
}