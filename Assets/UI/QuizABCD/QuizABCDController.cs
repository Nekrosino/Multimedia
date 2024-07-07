using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuizABCDController : MonoBehaviour
{
    public SceneController sceneController;
    public QuestionManager questionManager;
    VisualElement root;

    Button returnMenuButton;
    RadioButton AnswerA;
    RadioButton AnswerB;
    RadioButton AnswerC;
    RadioButton AnswerD;
    Button nextQuestion;
    Label questionNumber;
    Label questionText;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        returnMenuButton = root.Q<Button>("BackButton");
        questionNumber = root.Q<Label>("QuestionNumber");
        nextQuestion = root.Q<Button>("NextQuestion");
        questionText = root.Q<Label>("QuestionText");
        handleQuestions();


        returnMenuButton.clicked += () =>
        {
            sceneController.LoadSelectingQuiz();
        };

        nextQuestion.clicked += () =>
        {
            handleQuestions();
        };
    }


    //Pobierz kolejny numer pytania
    /*   public void setQuestion()
        {
            int nextQuestionNumber = questionManager.nextQuestionNumber();
            questionNumber.text = "Pytanie numer: "+nextQuestionNumber;
            Debug.Log(""+questionNumber.text);

            questionText.text = questionManager.nextQuestionText(nextQuestionNumber);
        }*/

    public void setQuestion(int questionnumber, string questiontext)
    {
        questionNumber.text = "Pytanie numer: " + (questionnumber+1);
        questionText.text = questiontext;
    }

    public void handleQuestions()
    {
        questionManager.sendQuestion();
    }
}
