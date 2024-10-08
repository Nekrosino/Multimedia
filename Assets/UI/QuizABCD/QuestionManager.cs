using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public QuizABCDController quizabcdcontroller;
    public DataBase dataBase;
    public List<string> pytania = new List<string>();
    public List<string> odpowiedzi = new List<string>();
    
    int questionNumber=0;
    string questionText;
    string AnswerA;
    string AnswerB;
    string AnswerC;
    string AnswerD;
    int a = 0;
    int b = 1;
    int c = 2;
    int d = 3;
    //Awake dziala Start nie dziala bo trzeba przed uruchomieniem klasy uzupelnic liste (chyba)
    private void Awake()
    {
        // questionNumber = 0;

        // pytania.AddRange(new List<string> { "Apple", "Banana", "Cherry" });
        // odpowiedzi.AddRange(new List<string> { "Tak", "Nie", "Nie wiem", "Test" });
        //dataBase.AddQuestionsToQuiz(odpowiedzi);
    }

    //Rozwiazanie zastepcze
    public void QuestionInitialize()
    {   
        
        pytania.RemoveRange(0, pytania.Count);
        odpowiedzi.RemoveRange(0, odpowiedzi.Count);

        //pytania.AddRange(new List<string> { "Apple", "Banana", "Cherry" });
       // dataBase.AddQuestionsToQuiz(pytania);
        dataBase.AddAnswersToQuiz(odpowiedzi);
        Debug.Log("QuestionInitializing testowe: " + odpowiedzi[1]);
       // odpowiedzi.AddRange(new List<string> { "Tak", "Nie", "Nie wiem", "Test" });
    }
    //Wysyla tresc oraz numer pytania do ControlleraQuizu zeby ten mogl go wrzucic na intrefejs
    public void sendQuestion()
    {
        if (questionNumber >= 11)
        {
            questionText = "";
        }
        else
        {
            QuestionInitialize();
/*            string AnswerA;
            string AnswerB;
            string AnswerC;
            string AnswerD;
            string questionText;
            bool isCorrectA;
            bool isCorrectB;
            bool isCorrectC;
            bool isCorrectD;*/
            //przypisujemy tresc pytania z listy o numerze pytania czyli dla Pytania 0 - dostajemy tresc z indeksu numer 0 
           /* dataBase.returnQuestion(questionNumber, out string questionText,out string AnswerA,out bool isCorrectA,out string AnswerB,out bool isCorrectB,out string AnswerC,out bool isCorrectC,out string AnswerD,out bool isCorrectD);
            Debug.Log(questionText, AnswerA, isCorrectA);*/
            //questionText = pytania[questionNumber];
            Debug.Log("Wys�ano: " + questionText);
           
            //wywolanie funkcji z kontrolera ktora ustawia numer pytania i jego tresc
           // quizabcdcontroller.setQuestion(questionNumber, questionText);
            //zwiekszenie indeksu aby po kliknieciu przycisku zaladowalo kolejne pytanie
            //===================================================================================================================================================
            //DODAC coroutine zeby po wcisnieciu przycisku dodatkowo wyswietlala sie poprawna odpowiedz i dopiero po jakis 2 sekundach ladowalo kolejna odpowiedz
            //===================================================================================================================================================
            questionNumber += 1;
        }
    }

    public void sendAnswers()
    {
        if (questionNumber >= 11)
        {
            AnswerA = "";
            AnswerB = "";
            AnswerC = "";
            AnswerD = "";
        }
        else
        {
            AnswerA = odpowiedzi[a];
            AnswerB = odpowiedzi[b];
            AnswerC = odpowiedzi[c];
            AnswerD = odpowiedzi[d];
            if (questionNumber == 1)
            {
             //   quizabcdcontroller.setAnswer(1, AnswerA, AnswerB, AnswerC, AnswerD, 1);
                quizabcdcontroller.setImage(1);
            }
            if (questionNumber == 2)
            {
              //  quizabcdcontroller.setAnswer(2, AnswerA, AnswerB, AnswerC, AnswerD, 4);
                quizabcdcontroller.setImage(2);
            }
            if (questionNumber == 3) //Niemcy
            {
               // quizabcdcontroller.setAnswer(3, AnswerA, AnswerB, AnswerC, AnswerD, 3);
                quizabcdcontroller.setImage(3);
            }
            if (questionNumber == 4)
            {
               // quizabcdcontroller.setAnswer(4, AnswerA, AnswerB, AnswerC, AnswerD, 1);
                quizabcdcontroller.setImage(4);
            }
            if (questionNumber == 5)
            {
              //  quizabcdcontroller.setAnswer(5, AnswerA, AnswerB, AnswerC, AnswerD, 4);
                quizabcdcontroller.setImage(5);
            }
            if (questionNumber == 6)
            {
               // quizabcdcontroller.setAnswer(6, AnswerA, AnswerB, AnswerC, AnswerD, 3);
                quizabcdcontroller.setImage(6);
            }
            if (questionNumber == 7)
            {
              //  quizabcdcontroller.setAnswer(7, AnswerA, AnswerB, AnswerC, AnswerD, 2);
                quizabcdcontroller.setImage(7);
            }
            if (questionNumber == 8)
            {
               // quizabcdcontroller.setAnswer(8, AnswerA, AnswerB, AnswerC, AnswerD, 3);
                quizabcdcontroller.setImage(8);
            }
            if (questionNumber == 9)
            {
               // quizabcdcontroller.setAnswer(9, AnswerA, AnswerB, AnswerC, AnswerD, 2);
                quizabcdcontroller.setImage(9);
            }
            if (questionNumber == 10)
            {
              //  quizabcdcontroller.setAnswer(10, AnswerA, AnswerB, AnswerC, AnswerD, 3);
                quizabcdcontroller.setImage(10);
            }

            /*          ==============================================
                        TYMCZASOWE ROZWIAZANIE KWESTII KOLEJNYCH PYTAN
                        ==============================================*/
            a += 4;
            b += 4;
            c += 4;
            d += 4;
            // quizabcdcontroller.setAnswer(2, AnswerA, AnswerB, AnswerC, AnswerD, 4);
        }
    }
}
