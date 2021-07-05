using UnityEngine;

public class LevelFix : MonoBehaviour
{
    [SerializeField] private string _sortingLayerName = "Default";
    [SerializeField] private int _sortingOrder = 0;

    void Start()
    {
        Renderer rend = GetComponent<ParticleSystem>().GetComponent<Renderer>();
        rend.sortingLayerName = _sortingLayerName;
        rend.sortingOrder = _sortingOrder;
    }

}