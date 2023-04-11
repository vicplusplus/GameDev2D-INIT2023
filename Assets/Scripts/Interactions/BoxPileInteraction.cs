using System.Collections.Generic;
using UnityEngine;

public class BoxPileInteraction : Interaction
{
    public Vector2 holdOffset;
    public float holdScale;

    private Transform _originalParent;
    private float _dropHeight;

    public void Awake()
    {
        _originalParent = transform.parent;
        _dropHeight = transform.position.y;
    }

    public override void Enact(Character callingCharacter)
    {
        if(transform.parent == callingCharacter.transform)
        {
            transform.position = new Vector2(transform.parent.position.x, _dropHeight);
            transform.SetParent(_originalParent);
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.SetParent(callingCharacter.transform);
            transform.position = transform.parent.position;
            transform.localScale = Vector3.one * holdScale;
        }
    }

    public override bool Verify(Character callingCharacter)
    {
        return callingCharacter.Controller.GetType() == typeof(RoadWorkerController);
    }
}
