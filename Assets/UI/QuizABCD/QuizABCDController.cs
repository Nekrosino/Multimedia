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
    Label Title;

    Button nextQuestion;
    Label questionNumber;
    Label questionText;
    VisualElement Image;
    VisualElement leftbar;
    VisualElement rightbar;

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
        leftbar = root.Q<VisualElement>("LeftBar");
        Title = root.Q<Label>("Title");
        rightbar = root.Q<VisualElement>("RightBar");
        AnswerA = root.Q<RadioButton>("AnswerA");
        AnswerB = root.Q<RadioButton>("AnswerB");
        AnswerC = root.Q<RadioButton>("AnswerC");
        AnswerD = root.Q<RadioButton>("AnswerD");
        AnswerALabel = AnswerA.Query<Label>().First();
        AnswerBLabel = AnswerB.Query<Label>().First();
        AnswerCLabel = AnswerC.Query<Label>().First();
        AnswerDLabel = AnswerD.Query<Label>().First();
        Image = root.Q<VisualElement>("Image");

         StartCoroutine(TestowaKorutynka());
        handleQuestions();
       


        returnMenuButton.clicked += () =>
        {
            sceneController.LoadSelectingQuiz();
        };

        nextQuestion.clicked += () =>
        {

            AnswerA.value = false;
            AnswerB.value = false;
            AnswerC.value = false;
            AnswerD.value = false;
            AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
            AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
            AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
            AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);
            questionNumber.RemoveFromClassList("end4");
            questionText.RemoveFromClassList("end5");
            StartCoroutine(TestowaKorutynka());
            handleQuestions();
            // dataBase.AddQuestionsToQuiz();

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

    IEnumerator TestowaKorutynka()
    {
        Debug.Log("Start korutynki");
        yield return new WaitForSeconds(0.25f);
        rightbar.AddToClassList("end2");
        leftbar.AddToClassList("end");
        Title.AddToClassList("end3");
        questionNumber.AddToClassList("end4");
        questionText.AddToClassList("end5");
        Debug.Log("Dodano korutynke");
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
       // imgsrc = "niemcy_img";
        questionManager.sendQuestion();
        questionManager.sendAnswers();
       
        Image.style.backgroundImage = Resources.Load<Texture2D>("img/" + imgsrc);



    }

    public void setImage(int questionnumber)
    {
        if(questionnumber == 1) //francja
            imgsrc = "francja_img";
        if (questionnumber == 2) //polska
            imgsrc = "polska_img";
        if (questionnumber == 3) //niemcy
            imgsrc = "niemcy_img";
        if (questionnumber == 4) //wlochy
            imgsrc = "wlochy_img";
        if (questionnumber == 5) //hiszpania
            imgsrc = "hiszpania_img";
        if (questionnumber == 6) //uk
            imgsrc = "uk_img";
        if (questionnumber == 7) //Portugalia
            imgsrc = "portugalia_img";
        if (questionnumber == 8) ///Grecja
            imgsrc = "grecja_img";
        if (questionnumber == 9) //Rosja
            imgsrc = "rosja_img";
        if (questionnumber == 10) //Ukraina
            imgsrc = "ukraina_img";
    }

    public void checkAnswer(int selectedanswer,int correctanswer)
    {
        if (selectedanswer == correctanswer)
        {
            if(selectedanswer == 1 && AnswerA.value)
            {
                AnswerA.style.backgroundColor = new Color(0, 255, 0, 255);
                AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);

            }
            else if(selectedanswer== 2 && AnswerB.value)
            {
                AnswerA.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerB.style.backgroundColor = new Color(0, 255, 0, 255);
                AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);
            }
            else if(selectedanswer == 3 && AnswerC.value)
            {
                AnswerA.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerC.style.backgroundColor = new Color(0, 255, 0, 255);
                AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);
            }
            else if (selectedanswer == 4 && AnswerD.value)
            {
                AnswerA.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerD.style.backgroundColor = new Color(0, 255, 0, 255);
            }
            else if(AnswerA.value == false || AnswerB.value == false || AnswerC.value == false || AnswerD.value == false)
            {
                AnswerA.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);
            }
        }
        else
        {
            if(selectedanswer == 1 && AnswerA.value)
            {
                AnswerA.style.backgroundColor = new Color(255, 0, 0, 255);
                AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);

            }
            else if(selectedanswer == 2 && AnswerB.value)
            {
                AnswerA.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerB.style.backgroundColor = new Color(255, 0, 0, 255);
                AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);
            }
            else if(selectedanswer==3 && AnswerC.value)
            {
                AnswerA.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerC.style.backgroundColor = new Color(255, 0, 0, 255);
                AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);
            }
            else if(selectedanswer==4 && AnswerD.value)
            {
                AnswerA.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerD.style.backgroundColor = new Color(255, 0, 0, 255);
            }
            else if (AnswerA.value == false || AnswerB.value == false || AnswerC.value == false || AnswerD.value == false)
            {
                AnswerA.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);
            }
        }

    }

    public void setCorrectAnswer(int correctanswer)
    {
        this.correctanswer = correctanswer;
    }
}
