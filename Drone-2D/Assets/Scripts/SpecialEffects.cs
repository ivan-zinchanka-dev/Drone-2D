using UnityEngine;

public class SpecialEffects : MonoBehaviour
{
    public static SpecialEffects Instance { get; private set; } = null;
    [SerializeField] private ParticleSystem _feathers = null;
    [SerializeField] private ParticleSystem _smoke = null;
    [SerializeField] private SpriteRenderer _explosionSpark = null;
    [SerializeField] private AudioClip _explosionSound = null;
    [SerializeField] private float _sparkDuration = 0.25f;
    [SerializeField] private AudioSource _audioSource = null; 

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Создано несколько объектов SpecialEffects!");
        }

        Instance = this;
    }

    public void CreateFeathers(Vector3 position) {

        ParticleSystem feathers_clone = Instantiate(_feathers, position, Quaternion.identity) as ParticleSystem;
        Destroy(feathers_clone.gameObject, _feathers.duration * 2);
    }

    public void CreateExplosion(Vector3 position)
    {
        ParticleSystem smoke_clone = Instantiate(_smoke, position, Quaternion.identity) as ParticleSystem;
        Destroy(smoke_clone.gameObject, _smoke.duration * 2);

        SpriteRenderer explosion_clone = Instantiate(_explosionSpark, position, Quaternion.identity) as SpriteRenderer;
        Destroy(explosion_clone.gameObject, _sparkDuration);

        _audioSource.clip = _explosionSound;
        _audioSource.Play();
    }

}
