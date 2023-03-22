using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(CharacterMovement))]
public class PossessionManager : MonoBehaviour
{
    public Controller _controller;
    private CharacterMovement _movement;
    private bool IsPossessing
    {
        get { return _controller.IsPossessing; }
        set { _controller.IsPossessing = value; }
    }
    private Queue<Controller> _controllerQueue;


    private void Awake()
    {
        _movement = GetComponent<CharacterMovement>();
        _controllerQueue = new Queue<Controller>();
    }

    private void Update()
    {
        _movement.MoveDirection = _controller.MoveDirection;
        _movement.IsJumping = _controller.IsJumping;
        if (IsPossessing) OnPossess();
    }

    private void OnPossess()
    {
        Debug.Log("Possesing");
        IsPossessing = false;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PossessionManager otherPossession = GetComponent<PossessionManager>();

        if (otherPossession == null) return;

        _controllerQueue.Enqueue(otherPossession._controller);
        Debug.Log("Got a Controller");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PossessionManager otherPossession = GetComponent<PossessionManager>();

        if (otherPossession == null) return;

        _controllerQueue = new Queue<Controller>(_controllerQueue.Where(x => x != _controller));

        Debug.Log("Removed a Controller");
    }
}