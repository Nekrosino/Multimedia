using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;
    public GameObject music;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Przypisz tê instancjê jako jedyn¹
            DontDestroyOnLoad(music); // Zapewnia, ¿e obiekt nie zostanie zniszczony przy zmianie sceny
        }
        else
        {
            Destroy(music); // Zniszcz now¹ instancjê, jeœli ju¿ istnieje jedna
        }
    }
}
