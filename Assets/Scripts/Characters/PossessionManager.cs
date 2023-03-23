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

    public void Possess(CharacterController callingController)
    {
        if(_possessionQueue.Count() < 1) return;

       callingController.Character = _possessionQueue.Dequeue();
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