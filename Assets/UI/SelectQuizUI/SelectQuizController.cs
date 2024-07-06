using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectQuizControler : MonoBehaviour
{
    public SceneController scenecontroller;
    VisualElement root;
    Button menuReturnButton;
    Button quiz1Button;
    Button quiz2Button;
    Button quiz3Button;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        quiz1Button = root.Q<Button>("Quiz1Button");
        quiz2Button = root.Q<Button>("Quiz2Button");
        quiz3Button = root.Q<Button>("Quiz3Button");
        menuReturnButton = root.Q<Button>("ReturnToMenuButton");

        quiz1Button.clicked += () =>
        {
            scenecontroller.LoadQuiz1();
        };

        quiz2Button.clicked += () =>
        {
            scenecontroller.LoadQuiz2();
        };

        quiz3Button.clicked += () =>
        {
            scenecontroller.LoadQuiz3();
        };


        menuReturnButton.clicked += () =>
        {
            scenecontroller.LoadMainMenu();
        };
    }
}
