public abstract class Controller : Controls.IInGameActions 
{
    
    public Vector2 MoveDirection;
    public bool IsJumping;
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
        IsJumping = context.ReadValueAsButton();
    
    }

    void Controls.IInGameActions.OnMove(InputAction.CallbackContext context)
    {
        MoveDirection = context.ReadValue<Vector2>();
    }

    void Controls.IInGameActions.OnPossess(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}