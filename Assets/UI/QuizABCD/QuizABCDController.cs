using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuizABCDController : MonoBehaviour
{
    public SceneController sceneController;
    VisualElement root;

    Button returnMenuButton;
    RadioButton AnswerA;
    RadioButton AnswerB;
    RadioButton AnswerC;
    RadioButton AnswerD;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        returnMenuButton = root.Q<Button>("BackButton");

        returnMenuButton.clicked += () =>
        {
            sceneController.LoadSelectingQuiz();
        };
    }
}
