using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Controller", menuName = "GameDev2D-INIT2023/Controller", order = 0)]
public class Controller : ScriptableObject, Controls.IInGameActions
{

    public Vector2 MoveDirection;
    public bool IsJumping;
    public bool IsPossessing;
    public bool IsInteracting;
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
        IsInteracting = context.ReadValueAsButton();
    }

    void Controls.IInGameActions.OnJump(InputAction.CallbackContext context)
    {
        IsJumping = context.ReadValueAsButton();

    }

    void Controls.IInGameActions.OnMove(InputAction.CallbackContext context)
    {
        MoveDirection = context.ReadValue<Vector2>();
    }

    void Controls.IInGameActions.OnPossess(InputAction.CallbackContext context)
    {
        if (context.started) {
            IsPossessing = context.ReadValueAsButton();
        }
        
    }
}