using UnityEngine;

public class CashierSound : MonoBehaviour
{
    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audio;
    public bool alreadyPlayed = false;
    void Start(){
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(){
        if(!alreadyPlayed){
            audio.PlayOneShot(SoundToPlay,Volume);
            alreadyPlayed = true;
        }
    }
}
