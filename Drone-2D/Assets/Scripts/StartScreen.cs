using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public WorldGenerator wgen;

    private void OnMouseUp()
    {
        wgen.StartGame();
        Destroy(this.gameObject);
    }

}
