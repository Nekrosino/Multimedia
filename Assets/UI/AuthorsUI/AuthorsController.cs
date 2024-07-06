using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AuthorsController : MonoBehaviour
{
    public SceneController sceneController;
    VisualElement root;
    Button returnMenuButton;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        returnMenuButton = root.Q<Button>("ReturnMenuButton");

        returnMenuButton.clicked += () =>
        {
            sceneController.LoadMainMenu();
        };
    }

}
