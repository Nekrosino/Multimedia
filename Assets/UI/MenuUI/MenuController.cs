using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    VisualElement root;
    public SceneController sceneController;
    // Start is called before the first frame update
    Button startButton;
    Button quitButton;
    Button authorsButton;

    public void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("StartButton");
        quitButton = root.Q<Button>("QuitButton");
        authorsButton = root.Q<Button>("AuthorsButton");

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


}
