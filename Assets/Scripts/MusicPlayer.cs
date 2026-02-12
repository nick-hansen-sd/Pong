using UnityEngine;
using UnityEngine.InputSystem;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource musicAudioSource;
    public AudioClip bgMusic;
    public bool mute = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicAudioSource = GetComponent<AudioSource>();
        musicAudioSource.loop = true;
        musicAudioSource.clip = bgMusic;
        musicAudioSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            if (mute == false)
            {
                mute = true;
                musicAudioSource.enabled = false;
            } else
            {
                mute = false;
                musicAudioSource.enabled = true;
                musicAudioSource.PlayOneShot(bgMusic);
            }
        }
    }
}
