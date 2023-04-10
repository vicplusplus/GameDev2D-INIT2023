using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour, Controls.IInGameActions
{
    public Character Character;
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

    private void Start()
    {
        if (Character != null)
        {
            Character.Controller.enabled = false;
            Character.Renderer.material = Character.Possession.PossessedMaterial;
        }
    }

    void Controls.IInGameActions.OnInteract(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Character.Interactions.ConsumeInteraction();
        }
    }

    void Controls.IInGameActions.OnJump(InputAction.CallbackContext context)
    {
        Character.Movement.IsJumping = context.ReadValueAsButton();
    }

    void Controls.IInGameActions.OnMove(InputAction.CallbackContext context)
    {
        Character.Movement.MoveDirection = context.ReadValue<Vector2>();
    }

    void Controls.IInGameActions.OnPossess(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Character.Possession.Possess(this);
        }
    }
}