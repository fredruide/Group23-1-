using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip[0];
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.enabled = s.enabled;
        }
        PlayLoop("Music");
    }

    public void Play(string name) // Kan kun blive spillet 1 gang selv med Loop bool true
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        int selection = UnityEngine.Random.Range(0, s.clip.Length);
        s.source.PlayOneShot(s.clip[selection]);
        // FindObjectOfType<AudioManager>().Play("NavnPåSound"); for at spille en sound i manageren
    }
    public void PlayLoop(string name) // Bruges til ting der skal loopes, og kun har 1 sound file i sig.
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}


// Put dette script på et empty gameobject i scenen. Scriptet kører med et array af forskellige "Sounds". Når man roder ved array size
// Aldrig lav nummeret lavere så det overwriter en anden lyd der er lavet i forvejen. da den så ville forsvinde
// Put FindObjectOfType<AudioManager>().Play("SoundName"); I andre scripts hvor man ville have at lyden skal blive afspillet
// Hvis Lyden skal spilles på en animation, så lav istedet en void i scriptet hvor animationen kører, og put lyd afspilleren deri,
// Og lav condition på KeyFrame at den skal køre den void.