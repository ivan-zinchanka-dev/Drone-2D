using UnityEngine;

public class WorldSoundsManager : MonoBehaviour
{ 
    [SerializeField] private AudioClip _seagullScream0 = null;
    [SerializeField] private AudioClip _seagullScream1 = null;
    [SerializeField] private AudioSource _audioSource = null;

    private static Sound scream = Sound.FIRST; 

    private void Start()
    {        
        if (scream == Sound.FIRST)
        {
            _audioSource.clip = _seagullScream0;
            scream++;
        }
        else {

            _audioSource.clip = _seagullScream1;            
            scream = Sound.FIRST;
        }

        _audioSource.Play();
    }

}


enum Sound { 

    FIRST = 0, SECOND = 1
}