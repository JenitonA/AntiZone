using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
public class audioManager : MonoBehaviour
{

    public Sound[] sounds;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    void Start()
    {
        Play("Intro"); // Plays the intro theme using my play method
        StartCoroutine(playTheme()); //Play the main theme that will loop
    }

    IEnumerator playTheme()
    {
        // Waits 2 seconds so that the intro can finish
        yield return new WaitForSeconds(1.6f);
        Play("Theme");
    }


    // This method plays the sound. It enable be to call it outside of this class which is why its public
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play(); // This is unity's built in play function
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop(); // This is unity's built in stop function
    }
}
