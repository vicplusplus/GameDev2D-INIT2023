using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    public abstract bool Verify(Character callingCharacter);
    public abstract void Enact(Character callingCharacter);
}