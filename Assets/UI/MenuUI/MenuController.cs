using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    VisualElement root;
    public SceneController sceneController;
    public MusicPlayer musicPlayer;
    // Start is called before the first frame update
    Button startButton;
    Button quitButton;
    Button authorsButton;
    public Toggle toggleMusic;
    VisualElement img;
    VisualElement unitycheckmark;
    public bool isMuted;
    //[SerializeField] MusicPlayer music;

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

        startButton.clicked += () =>
        {
            sceneController.LoadSelectingQuiz();
        };

        quitButton.clicked += () =>
        {
            sceneController.QuitGame();
        };

        authorsButton.clicked += () =>
        {
            sceneController.LoadAuthors();
        };
    

    }

    private void Start()
    {
        // isMuted = musicPlayer.isMusicMuted();
        //toggleMusic.value = isMuted;
        // toggleMusic.value = mute;
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
