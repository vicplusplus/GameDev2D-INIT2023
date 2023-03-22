using UnityEngine;

[RequireComponent(typeof(CharacterMovement), typeof(PossessionManager))]
public class Character : MonoBehaviour
{
    [HideInInspector] public CharacterMovement Movement;
    [HideInInspector] public PossessionManager Possession;

    private void Awake()
    {
        Movement = GetComponent<CharacterMovement>();
        Possession = GetComponent<PossessionManager>();
    }
}