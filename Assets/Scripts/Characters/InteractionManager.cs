using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InteractionManager : MonoBehaviour
{
    // Detection Layer 
    public LayerMask InteractionLayers;
    private BoxCollider2D _bodyCollider;
    private Character _character;
    private Rigidbody2D _body;

    void Awake()
    {
        _character = GetComponent<Character>();
        _bodyCollider = GetComponent<BoxCollider2D>();
        _body = GetComponent<Rigidbody2D>();
    }

    public void Interact()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(
        _body.position + _bodyCollider.offset,
        _bodyCollider.size,
        0,
        InteractionLayers
        );

        for (int i = 0; i < hits.Length; i++)
        {
            Interaction interaction = hits[i].GetComponent<Interaction>();
            
            if(interaction == null) continue;

            if(interaction.Verify(_character))
            {
                interaction.Enact(_character);
                return;
            }
        }
    }
}
