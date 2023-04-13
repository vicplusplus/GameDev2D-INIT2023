using UnityEngine.SceneManagement;

public class DoorInteraction : Interaction
{
    public int NextSceneID;
    public override void Enact(Character callingCharacter)
    {
        SceneManager.LoadScene(NextSceneID);
    }

    public override bool Verify(Character callingCharacter)
    {
        return callingCharacter.Controller.GetType() == typeof(CatIdleController);
    }
}
