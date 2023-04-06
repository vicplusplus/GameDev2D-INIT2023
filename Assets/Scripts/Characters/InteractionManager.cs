using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InteractionManager : MonoBehaviour
{
    // Detection Layer 
    public LayerMask detectionLayer;
    private BoxCollider2D _collider;
    private Character _character;
    private Queue<Interaction> _interactionQueue;

    void Awake()
    {
        _character = GetComponent<Character>();
        _collider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        _interactionQueue = new();
    }

    public void ConsumeInteraction()
    {
        if(_interactionQueue.Count == 0) return;

        Interaction interaction = _interactionQueue.Dequeue();

        Debug.Log(interaction.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Interaction interaction = other.GetComponent<Interaction>();

        if (interaction == null) return;

        if(interaction.Verify(_character))
        {
            _interactionQueue.Enqueue(interaction);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Interaction interaction = other.GetComponent<Interaction>();

        if (interaction == null) return;

        _interactionQueue = new Queue<Interaction>(_interactionQueue.Where(x => x != interaction));
    }

    bool DetectObject()
    {
        return Physics2D.OverlapBox(transform.position,
                                    _collider.size,
                                    detectionLayer);
    }
}
