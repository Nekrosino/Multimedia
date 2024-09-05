using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

/*Klasa s³u¿¹ca do zarz¹dzania Menu*/
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

/*    Funkcja wykonuj¹ca siê przy w³¹czeniu interfejsu*/
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
        Przycisk umo¿liwiaj¹cy przejœcie do wyboru quizów*/
        startButton.clicked += () =>
        {
            sceneController.LoadSelectingQuiz();
        };
        //Przycisk s³u¿¹cy do wyjœcia z aplikacji
        quitButton.clicked += () =>
        {
            sceneController.QuitGame();
        };
        //Przycisk umo¿liwiaj¹cy przejœcie do ekranu autorów
        authorsButton.clicked += () =>
        {
            sceneController.LoadAuthors();
        };
    

    }

    //Funkcja wywo³uj¹ca siê w momencie za³adowania klasy przed metod¹ Update()
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

    //Funkcja wywo³ywana w ka¿dej klatce
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
