using UnityEngine;

[RequireComponent(typeof(CharacterMovement), typeof(PossessionManager))]
public class Character : MonoBehaviour
{
    [HideInInspector] public CharacterMovement Movement;
    [HideInInspector] public PossessionManager Possession;
    [HideInInspector] public IdleController Controller;

    private void Awake()
    {
        Movement = GetComponent<CharacterMovement>();
        Possession = GetComponent<PossessionManager>();
        Controller = GetComponent<IdleController>();

        if(Controller == null)
        {
            Debug.LogWarning($"{gameObject} does not contain an Idle Controller!");
        }
    }
}