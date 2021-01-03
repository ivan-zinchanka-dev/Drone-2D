using UnityEngine;

public class LevelFix : MonoBehaviour
{
    [SerializeField] private string SortingLayerName = "Default";
    [SerializeField] private int SortingOrder = 0;

    void Start()
    {
        Renderer rend = GetComponent<ParticleSystem>().GetComponent<Renderer>();
        rend.sortingLayerName = SortingLayerName;
        rend.sortingOrder = SortingOrder;
    }

}