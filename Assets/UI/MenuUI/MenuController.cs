using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

/*Klasa s�u��ca do zarz�dzania Menu*/
public class MenuController : MonoBehaviour
{
    VisualElement root;
    public SceneController sceneController;
    public MusicPlayer musicPlayer;
    Button startButton;
    Button quitButton;
    Button authorsButton;
    public Toggle toggleMusic;
    VisualElement img;
    VisualElement unitycheckmark;
    public bool isMuted;

/*    Funkcja wykonuj�ca si� przy w��czeniu interfejsu*/
    public void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("StartButton");
        quitButton = root.Q<Button>("QuitButton");
        authorsButton = root.Q<Button>("AuthorsButton");
        toggleMusic = root.Q<Toggle>("ToggleMusic");
        unitycheckmark = toggleMusic.Q<VisualElement>("unity-checkmark");
        img = root.Q<VisualElement>("img");
        unitycheckmark.style.opacity = 0;
/*
        Przycisk umo�liwiaj�cy przej�cie do wyboru quiz�w*/
        startButton.clicked += () =>
        {
            sceneController.LoadSelectingQuiz();
        };
        //Przycisk s�u��cy do wyj�cia z aplikacji
        quitButton.clicked += () =>
        {
            sceneController.QuitGame();
        };
        //Przycisk umo�liwiaj�cy przej�cie do ekranu autor�w
        authorsButton.clicked += () =>
        {
            sceneController.LoadAuthors();
        };
    

    }

    //Funkcja wywo�uj�ca si� w momencie za�adowania klasy przed metod� Update()
    private void Start()
    {

        toggleMusic.value = MusicPlayer.Instance.isMuted;
        MusicPlayer.Instance.toggleMusic(toggleMusic.value);
        if(MusicPlayer.Instance.isMuted)
        {
            img.style.backgroundImage = Resources.Load<Texture2D>("img/mute");
        }
        if(MusicPlayer.Instance.isMuted == false)
        {
            img.style.backgroundImage = Resources.Load<Texture2D>("img/speaker");
        }
      
    }

    //Funkcja wywo�ywana w ka�dej klatce
    public void Update()
    {

        toggleMusic.RegisterValueChangedCallback(evt =>
        {
            Debug.Log("Toggle value: " + evt.newValue);
            MusicPlayer.Instance.toggleMusic(evt.newValue);
            if(evt.newValue == true)
            {
                img.style.backgroundImage = Resources.Load<Texture2D>("img/mute");
            }
            else
            {
                img.style.backgroundImage = Resources.Load<Texture2D>("img/speaker");
            }

        });
    }


}
