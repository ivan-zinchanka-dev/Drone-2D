using UnityEngine;

public class WorldSoundsManager : MonoBehaviour
{ 
    [SerializeField] private AudioClip seagull_scream_1 = null;
    [SerializeField] private AudioClip seagull_scream_2 = null;
    private AudioSource audioSource;

    private static Sound scream = Sound.FIRST; 

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();

        if (scream == Sound.FIRST)
        {
            audioSource.clip = seagull_scream_1;

            //audioSource.volume = 0.5f;
            scream++;
        }
        else {

            audioSource.clip = seagull_scream_2;
            //audioSource.volume = 1.0f;
            scream = Sound.FIRST;
        }

        audioSource.Play();
    }

}


enum Sound { 

    FIRST = 0, SECOND = 1
}