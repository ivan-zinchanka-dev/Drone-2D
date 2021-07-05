using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private WorldGenerator _wgen = null;

    private void OnMouseUp()
    {
        _wgen.StartGame();
        Destroy(this.gameObject);
    }

}
