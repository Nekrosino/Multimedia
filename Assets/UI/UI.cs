using Assets.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class UI : MonoBehaviour
{   
    public Controller controller;

    VisualElement root;
    Label hint;
    Label hintNumLabel;
    Label questionNumLabel;
    Label timeLabel;
    Label answer_indicator;
    Label highscoreLabel;
    Label currentScoreLabel;

    Button nextHintButton;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        hint = root.Q<Label>("Hint");
        hintNumLabel = root.Q<Label>("HintNum");
        questionNumLabel = root.Q<Label>("QuestionCounter");
        nextHintButton = root.Q<Button>("NextHintButton");
        timeLabel = root.Q<Label>("CounterLabel");
        answer_indicator = root.Q<Label>("AnswerIndicator");
        highscoreLabel = root.Q<Label>("Highscore");
        currentScoreLabel = root.Q<Label>("MyScore");

        Initialize();
    }

    public void Initialize()
    {
        nextHintButton.clicked += () =>
        {
            controller.HandleWrongAnswer();
        };

        Setup.InitializeDragDrop(root, controller);
        Setup.InitializeIcons(root, controller.getAllQuestions());
    }

    public void GiveAnswerFeedback(bool correct)
    {
        answer_indicator.style.visibility = Visibility.Visible;
        answer_indicator.text = correct ? "Twoja odpowiedü jest prawid≥owa!" : "Twoja odpowiedü jest niepoprawna";

        StyleColor colorCorrect = new StyleColor(new Color32(0,132,19,255));
        StyleColor colorWrong = new StyleColor(new Color32(132, 0, 19, 255));

        answer_indicator.style.color = correct ? colorCorrect : colorWrong;
        StartCoroutine(CleanUpQuestion());
    }

    IEnumerator CleanUpQuestion()
    {
        yield return new WaitForSeconds(3);
        answer_indicator.style.visibility = Visibility.Hidden;

        VisualElement dropZone = root.Q<VisualElement>("DropBox");

        if(dropZone.childCount > 0 )
        {
            dropZone.RemoveAt(0);
        }
    }

    public void SetTimer(string seconds)
    {
        timeLabel.text = "Pozosta≥y czas: " + seconds + " sekund";
    }

    public void SetHint(string hintText)
    {
        hint.text = hintText;
    }

    public void SetHintNumber(int hintNum)
    {
        hintNumLabel.text = "Podpowiedü " + hintNum.ToString() + ":";
    }

    public void SetQuestionNumber(int questionNum) 
    {
        questionNumLabel.text = "Pytanie " + questionNum.ToString();
    }
}
