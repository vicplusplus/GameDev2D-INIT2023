using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PossessionManager : MonoBehaviour
{
    private Queue<Character> _possessionQueue;

    private void Awake()
    {
        _possessionQueue = new Queue<Character>();
    }

    private void OnPossess()
    {
        Debug.Log("Possesing");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Character otherCharacter = GetComponent<Character>();

        if (otherCharacter == null) return;

        _possessionQueue.Enqueue(otherCharacter);
        Debug.Log($"Added {otherCharacter} to {this} queue.");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Character otherCharacter = GetComponent<Character>();

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