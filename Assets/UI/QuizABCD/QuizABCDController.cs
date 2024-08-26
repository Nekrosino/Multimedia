using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuizABCDController : MonoBehaviour
{
    public SceneController sceneController;
    public QuestionManager questionManager;
    public DataBase dataBase;
    VisualElement root;

    Button returnMenuButton;
    RadioButton AnswerA;
    RadioButton AnswerB;
    RadioButton AnswerC;
    RadioButton AnswerD;

    Label AnswerALabel;
    Label AnswerBLabel;
    Label AnswerCLabel;
    Label AnswerDLabel;

    Button nextQuestion;
    Label questionNumber;
    Label questionText;
    VisualElement Image;

    RadioButton selectedRadioButton;
    int selectedanswer;
    int correctanswer;
    private string imgsrc;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        returnMenuButton = root.Q<Button>("BackButton");
        questionNumber = root.Q<Label>("QuestionNumber");
        nextQuestion = root.Q<Button>("NextQuestion");
        questionText = root.Q<Label>("QuestionText");
        AnswerA = root.Q<RadioButton>("AnswerA");
        AnswerB = root.Q<RadioButton>("AnswerB");
        AnswerC = root.Q<RadioButton>("AnswerC");
        AnswerD = root.Q<RadioButton>("AnswerD");
        AnswerALabel = AnswerA.Query<Label>().First();
        AnswerBLabel = AnswerB.Query<Label>().First();
        AnswerCLabel = AnswerC.Query<Label>().First();
        AnswerDLabel = AnswerD.Query<Label>().First();
        Image = root.Q<VisualElement>("Image");
        handleQuestions();
       


        returnMenuButton.clicked += () =>
        {
            sceneController.LoadSelectingQuiz();
        };

        nextQuestion.clicked += () =>
        {
            handleQuestions();
            dataBase.AddQuestionsToQuiz();
        };
    }

    public void Update()
    {
        AnswerA.RegisterCallback<ChangeEvent<bool>>(OnRadioButtonChanged);
        AnswerB.RegisterCallback<ChangeEvent<bool>>(OnRadioButtonChanged);
        AnswerC.RegisterCallback<ChangeEvent<bool>>(OnRadioButtonChanged);
        AnswerD.RegisterCallback<ChangeEvent<bool>>(OnRadioButtonChanged);
        checkAnswer(selectedanswer, correctanswer);
    }


    private void OnRadioButtonChanged(ChangeEvent<bool> evt)
    {
        if(evt.newValue)
        {
            selectedRadioButton = (RadioButton)evt.target;
            Debug.Log($"Selected: {selectedRadioButton.name}");
            if(selectedRadioButton.name == "AnswerA" ) 
            {
                selectedanswer = 1;
                Debug.Log($"Selected: {selectedanswer}");
                Debug.Log($"Correct: {correctanswer}");
            }

            else if(selectedRadioButton.name == "AnswerB")
            {
                selectedanswer = 2;
                Debug.Log($"Selected: {selectedanswer}");
                Debug.Log($"Correct: {correctanswer}");
            }

            else if( selectedRadioButton.name == "AnswerC")
            {
                selectedanswer = 3;
                Debug.Log($"Selected: {selectedanswer}");
                Debug.Log($"Correct: {correctanswer}");
            }

            else if( selectedRadioButton.name == "AnswerD")
            {
                selectedanswer = 4;
                Debug.Log($"Selected: {selectedanswer}");
                Debug.Log($"Correct: {correctanswer}");
            }
        }
    }


    //Pobierz kolejny numer pytania
    /*   public void setQuestion()
        {
            int nextQuestionNumber = questionManager.nextQuestionNumber();
            questionNumber.text = "Pytanie numer: "+nextQuestionNumber;
            Debug.Log(""+questionNumber.text);

            questionText.text = questionManager.nextQuestionText(nextQuestionNumber);
        }*/

    //Ustawienie numeru pytania oraz tresci na interfejsie (wywolywana w QuestionManager gdzie zawarte sa tresci pytan
    public void setQuestion(int questionnumber, string questiontext)
    {
        questionNumber.text = "Pytanie numer: " + (questionnumber+1);
        questionText.text = questiontext;
        Debug.Log("Otrzymano" + questiontext);
   
    }

    public void setAnswer(int questionnumber, string answertextA, string answertextB, string answertextC, string answertextD, int correctanswer)
    {
        AnswerALabel.text = "A. " + answertextA;
        AnswerBLabel.text = "B. " + answertextB;
        AnswerCLabel.text = "C. " + answertextC;
        AnswerDLabel.text = "D. " + answertextD;
        setCorrectAnswer(correctanswer);
    }

    //obsluga pytan - sluzy jako funkcja posrednicza zeby odbierac dane pytan
    public void handleQuestions()
    {
        imgsrc = "placeholder";
        questionManager.sendQuestion();
        questionManager.sendAnswers();
       
        Image.style.backgroundImage = Resources.Load<Texture2D>("img/" + imgsrc);
      
    }

    public void checkAnswer(int selectedanswer,int correctanswer)
    {
        if (selectedanswer == correctanswer)
        {
            if(selectedanswer == 1)
            {
                AnswerA.style.backgroundColor = new Color(0, 255, 0, 255);
                AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);

            }
            else if(selectedanswer== 2)
            {
                AnswerA.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerB.style.backgroundColor = new Color(0, 255, 0, 255);
                AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);
            }
            else if(selectedanswer == 3)
            {
                AnswerA.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerC.style.backgroundColor = new Color(0, 255, 0, 255);
                AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);
            }
            else if (selectedanswer == 4)
            {
                AnswerA.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerD.style.backgroundColor = new Color(0, 255, 0, 255);
            }
        }
        else
        {
            if(selectedanswer == 1)
            {
                AnswerA.style.backgroundColor = new Color(255, 0, 0, 255);
                AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);

            }
            else if(selectedanswer == 2)
            {
                AnswerA.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerB.style.backgroundColor = new Color(255, 0, 0, 255);
                AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);
            }
            else if(selectedanswer==3)
            {
                AnswerA.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerC.style.backgroundColor = new Color(255, 0, 0, 255);
                AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);
            }
            else if(selectedanswer==4)
            {
                AnswerA.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerD.style.backgroundColor = new Color(255, 0, 0, 255);
            }
        }

    }

    public void setCorrectAnswer(int correctanswer)
    {
        this.correctanswer = correctanswer;
    }
}
