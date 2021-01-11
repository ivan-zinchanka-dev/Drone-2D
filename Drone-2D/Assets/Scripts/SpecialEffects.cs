using UnityEngine;

public class SpecialEffects : MonoBehaviour
{
    public static SpecialEffects Instance = null;
    [SerializeField] private ParticleSystem feathers = null;
    [SerializeField] private ParticleSystem smoke = null;
    [SerializeField] private SpriteRenderer explosion_spark = null;
    [SerializeField] private AudioClip explosion_sound = null;
    [SerializeField] private float spark_duration = 0.25f;
    private AudioSource audioSource; 

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Создано несколько объектов SpecialEffects!");
        }

        Instance = this;
        audioSource = this.GetComponent<AudioSource>();
    }

    public void CreateFeathers(Vector3 position) {

        ParticleSystem feathers_clone = Instantiate(feathers, position, Quaternion.identity) as ParticleSystem;
        Destroy(feathers_clone.gameObject, feathers.duration * 2);

    }

    public void CreateExplosion(Vector3 position)
    {

        ParticleSystem smoke_clone = Instantiate(smoke, position, Quaternion.identity) as ParticleSystem;
        Destroy(smoke_clone.gameObject, smoke.duration * 2);

        SpriteRenderer explosion_clone = Instantiate(explosion_spark, position, Quaternion.identity) as SpriteRenderer;
        Destroy(explosion_clone.gameObject, spark_duration);

        audioSource.clip = explosion_sound;
        audioSource.Play();
    }

}
