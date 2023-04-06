using UnityEngine;

[RequireComponent(typeof(CharacterMovement), typeof(PossessionManager)), RequireComponent(typeof(IdleController), typeof(InteractionManager))]
public class Character : MonoBehaviour
{
    [HideInInspector] public CharacterMovement Movement;
    [HideInInspector] public PossessionManager Possession;
    [HideInInspector] public IdleController Controller;
    [HideInInspector] public InteractionManager Interactions;

    private void Awake()
    {
        Movement = GetComponent<CharacterMovement>();
        Possession = GetComponent<PossessionManager>();
        Controller = GetComponent<IdleController>();
        Interactions = GetComponent<InteractionManager>();

        if(Controller == null)
        {
            Debug.LogWarning($"{gameObject} does not contain an Idle Controller!");
        }
    }
}