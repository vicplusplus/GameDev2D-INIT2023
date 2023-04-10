public class GravestoneController : IdleController
{
    private void OnEnable()
    {
        Destroy(gameObject);
    }
}
