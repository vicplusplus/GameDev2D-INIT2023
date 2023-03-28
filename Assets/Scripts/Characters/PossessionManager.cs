using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PossessionManager : MonoBehaviour
{
    public LayerMask CharacterLayers;
    [HideInInspector]public Rigidbody2D Body;
    private Queue<Character> _possessionQueue;
    private BoxCollider2D _bodyCollider;

    private void Awake()
    {
        _bodyCollider = GetComponent<BoxCollider2D>();
        Body = GetComponent<Rigidbody2D>();

    }

    public void Possess(CharacterController callingController)
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(
        Body.position + _bodyCollider.offset,
        _bodyCollider.size,
        0,
        CharacterLayers
        );
        Debug.Log(hits.Length);

        for (int i = 0; i < hits.Length; i++)
        {
            Character temp = hits[i].GetComponent<Character>();
            if (temp != null && hits[i].gameObject != gameObject)
            {
                callingController.Character.Possession.Body.velocity = Vector2.zero;
                callingController.Character = temp;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Character otherCharacter = other.GetComponent<Character>();
        Debug.Log($"{other}");

        if (otherCharacter == null) return;

        _possessionQueue.Enqueue(otherCharacter);
        Debug.Log($"Added {otherCharacter} to {this} queue.");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Character otherCharacter = other.GetComponent<Character>();
        Debug.Log($"{other}");

        if (otherCharacter == null) return;

        _possessionQueue = new Queue<Character>(_possessionQueue.Where(x => x != otherCharacter));
        Debug.Log($"Removed {otherCharacter} from {this} queue.");
    }

    public enum State
    {
        Idle,
        Confused,
        Possessed
    }
}