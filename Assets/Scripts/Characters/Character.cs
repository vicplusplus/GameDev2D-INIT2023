using UnityEngine;

[RequireComponent(typeof(CharacterMovement), typeof(PossessionManager))]
public class Character : MonoBehaviour
{
    [HideInInspector] public CharacterMovement movement;
    [HideInInspector] public PossessionManager possession;

    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
        possession = GetComponent<PossessionManager>();
    }
}