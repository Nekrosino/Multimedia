using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance { get; private set; }
    public GameObject music;
    public bool isMuted = false;
    [SerializeField] AudioSource musicSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Przypisz t� instancj� jako jedyn�
            DontDestroyOnLoad(music); // Zapewnia, �e obiekt nie zostanie zniszczony przy zmianie sceny
        }
        else
        {
            Destroy(music); // Zniszcz now� instancj�, je�li ju� istnieje jedna
        }
    }

    public void toggleMusic(bool toggle)
    {
        isMuted = toggle;
        if (isMuted)
        {
            musicSource.mute = true;
           
        }
        else
        {
            musicSource.mute = false;
        }

    }

    public bool isMusicMuted()
    {
        return isMuted;
    }
       
}
