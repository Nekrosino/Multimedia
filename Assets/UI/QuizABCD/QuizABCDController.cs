using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class QuizABCDController : MonoBehaviour
{
    public SceneController sceneController;
    public QuestionManager questionManager;
    public SummaryController summaryController;
   // [SerializeField] Points points;
    public DataBase dataBase;
    VisualElement root;
    bool hasAwardedPoint=false;
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
  
    private string imgsrc;
    int questionCount = 0;
    int score;
    int startQuestion = 0;  
    int correctanswer = 5;

/*    [Serializable]
    public class Question
    {
        public string QuestionText;
        public List<Answer> Answers = new List<Answer>();

        public Question(string QuestionText)
        {
            this.QuestionText = QuestionText;
        }
    }

    [Serializable]
    public class Answer
    {
        public string answerText;
        public bool isCorrect;

        public Answer(string answerText, bool isCorrect)
        {
            this.answerText = answerText;
            this.isCorrect = isCorrect;
        }
    }*/

    public List<DataBase.Question> Questions;
    private int howManyQuestions=10;

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
        // dataBase.AddQuestionsToQuiz(Questions,howManyQuestions);
        LoadQuestions(howManyQuestions);
        Shuffle(Questions);
       
        InitializeQuestion();
        StartCoroutine(TestowaKorutynka());

       // handleQuestions();
       


        returnMenuButton.clicked += () =>
        {
            sceneController.LoadSelectingQuiz();
        };

        nextQuestion.clicked += () =>
        {
   /*         if (questionCount >= 9)
            {
                sceneController.LoadSummaryScene();
            }
*/
            hasAwardedPoint = false;
            AnswerA.value = false;
            AnswerB.value = false;
            AnswerC.value = false;
            AnswerD.value = false;
           // AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
         //   AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
          //  AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
         //   AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);

          

          //  handleQuestions();
         //   questionCount++;


            AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
            AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
            AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
            AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);
            /*AnswerA.text = Questions[1].Answers[0].answerText;*/
            if (startQuestion < howManyQuestions)
            {
                questionNumber.RemoveFromClassList("end4");
                questionText.RemoveFromClassList("end5");
                InitializeQuestion();
                StartCoroutine(TestowaKorutynka());
            }
            else
                sceneController.LoadSummaryScene();



            // dataBase.AddQuestionsToQuiz();

        };
    }

    public void InitializeQuestion()
    {   

        int QuestionsAmount = Questions.Count;
        Shuffle(Questions[startQuestion].Answers);
        string pytanie = Questions[startQuestion].QuestionText;
        string OdpA = Questions[startQuestion].Answers[0].answerText;
        bool isCorrectA = Questions[startQuestion].Answers[0].isCorrect;
        string OdpB = Questions[startQuestion].Answers[1].answerText;
        bool isCorrectB = Questions[startQuestion].Answers[1].isCorrect;
        string OdpC = Questions[startQuestion].Answers[2].answerText;
        bool isCorrectC = Questions[startQuestion].Answers[2].isCorrect;
        string OdpD = Questions[startQuestion].Answers[3].answerText;
        bool isCorrectD = Questions[startQuestion].Answers[3].isCorrect;
        if (isCorrectA)
        {
            correctanswer = 1;
            setCorrectAnswer(correctanswer);
        }
        else if (isCorrectB)
        {
            correctanswer = 2;
            setCorrectAnswer(correctanswer);
        }
        else if (isCorrectC)
        {
            correctanswer = 3;
            setCorrectAnswer(correctanswer);
        }
        else if (isCorrectD)
        {
            correctanswer = 4;
            setCorrectAnswer(correctanswer);
        }

        Debug.Log("Inicjalizacja Pytania " + pytanie);
        Debug.Log("Odp " + OdpA + " IsCorrect " + isCorrectA);
        Debug.Log("Odp " + OdpB + " IsCorrect " + isCorrectB);
        Debug.Log("Odp " + OdpC + " IsCorrect " + isCorrectC);
        Debug.Log("Odp " + OdpD + " IsCorrect " + isCorrectD);
        questionNumber.text = "Pytanie numer: " + (startQuestion + 1);
        questionText.text = pytanie;
        AnswerALabel.text = "A. " + OdpA;
        AnswerBLabel.text = "B. " + OdpB;
        AnswerCLabel.text = "C. " + OdpC;
        AnswerDLabel.text = "D. " + OdpD;
        setImage(startQuestion);
        Image.style.backgroundImage = Resources.Load<Texture2D>("img/" + imgsrc);

        // setCorrectAnswer(correctanswer);
        Debug.Log("Ustawiona Odpowiedz: " + correctanswer);
        startQuestion++;

    }

    public static void Shuffle<T>(List<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
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

    void LoadQuestions(int howManyQuestions)
    {   
        for(int i = 1; i <= howManyQuestions; i++)
        {
            dataBase.AddQuestionsToQuiz(Questions,i);
        }

    }

    public int getPoints(int score)
    {
        score = this.score;
        return score;
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
/*    public void setQuestion(int questionnumber, string questiontext)
    {
        questionNumber.text = "Pytanie numer: " + (questionnumber+1);
        questionText.text = questiontext;
        Debug.Log("Otrzymano" + questiontext);
   
    }*/


    public void setAnswer(int questionnumber, string answertextA, string answertextB, string answertextC, string answertextD, int correctanswer)
    {
        AnswerALabel.text = "A. " + answertextA;
        AnswerBLabel.text = "B. " + answertextB;
        AnswerCLabel.text = "C. " + answertextC;
        AnswerDLabel.text = "D. " + answertextD;
        //setCorrectAnswer(correctanswer);
    }

    //obsluga pytan - sluzy jako funkcja posrednicza zeby odbierac dane pytan
    public void handleQuestions()
    {
       // imgsrc = "niemcy_img";
        questionManager.sendQuestion();
        questionManager.sendAnswers();
       
        Image.style.backgroundImage = Resources.Load<Texture2D>("img/" + imgsrc);



    }

    public void setImage(int startquestion)
    {
        imgsrc = Questions[startQuestion].imgsrc;
/*        if(questionnumber == 1) //francja
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
            imgsrc = "ukraina_img";*/


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
                if(!hasAwardedPoint)
                {
                    hasAwardedPoint = true;
                    Points.Instance.givePoint();
                }
                   

            }
            else if(selectedanswer== 2 && AnswerB.value)
            {
                AnswerA.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerB.style.backgroundColor = new Color(0, 255, 0, 255);
                AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);
                if (!hasAwardedPoint)
                {
                    hasAwardedPoint = true;
                    Points.Instance.givePoint();
                }

            }
            else if(selectedanswer == 3 && AnswerC.value)
            {
                AnswerA.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerC.style.backgroundColor = new Color(0, 255, 0, 255);
                AnswerD.style.backgroundColor = new Color(0, 0, 0, 0);
                if (!hasAwardedPoint)
                {
                    hasAwardedPoint = true;
                    Points.Instance.givePoint();
                }

            }
            else if (selectedanswer == 4 && AnswerD.value)
            {
                AnswerA.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerB.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerC.style.backgroundColor = new Color(0, 0, 0, 0);
                AnswerD.style.backgroundColor = new Color(0, 255, 0, 255);
                if (!hasAwardedPoint)
                {
                    hasAwardedPoint = true;
                    Points.Instance.givePoint();
                }

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
