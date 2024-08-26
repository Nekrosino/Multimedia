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

        pytania.AddRange(new List<string> { "Apple", "Banana", "Cherry" });
        dataBase.AddQuestionsToQuiz(odpowiedzi);
        Debug.Log("QuestionInitializing testowe: " + odpowiedzi[1]);
       // odpowiedzi.AddRange(new List<string> { "Tak", "Nie", "Nie wiem", "Test" });
    }
    //Wysyla tresc oraz numer pytania do ControlleraQuizu zeby ten mogl go wrzucic na intrefejs
    public void sendQuestion()
    {
        QuestionInitialize();
        //przypisujemy tresc pytania z listy o numerze pytania czyli dla Pytania 0 - dostajemy tresc z indeksu numer 0 
        questionText = pytania[questionNumber];
        Debug.Log("Wys³ano: "+questionText);
        //wywolanie funkcji z kontrolera ktora ustawia numer pytania i jego tresc
        quizabcdcontroller.setQuestion(questionNumber, questionText);
        //zwiekszenie indeksu aby po kliknieciu przycisku zaladowalo kolejne pytanie
        //===================================================================================================================================================
        //DODAC coroutine zeby po wcisnieciu przycisku dodatkowo wyswietlala sie poprawna odpowiedz i dopiero po jakis 2 sekundach ladowalo kolejna odpowiedz
        //===================================================================================================================================================
        questionNumber += 1;
    }

    public void sendAnswers()
    {
        AnswerA = odpowiedzi[0];
        AnswerB = odpowiedzi[1];
        AnswerC = odpowiedzi[2];
        AnswerD = odpowiedzi[3];
        quizabcdcontroller.setAnswer(1, AnswerA, AnswerB,AnswerC, AnswerD,1);
    }

}
