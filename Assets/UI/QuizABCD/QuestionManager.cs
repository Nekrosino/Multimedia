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
        dataBase.AddQuestionsToQuiz(pytania);
        dataBase.AddAnswersToQuiz(odpowiedzi);
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
        AnswerA = odpowiedzi[a];
        AnswerB = odpowiedzi[b];
        AnswerC = odpowiedzi[c];
        AnswerD = odpowiedzi[d];
        quizabcdcontroller.setAnswer(1, AnswerA, AnswerB, AnswerC, AnswerD, 1);
/*          ==============================================
            TYMCZASOWE ROZWIAZANIE KWESTII KOLEJNYCH PYTAN
            ==============================================*/
        a += 4;
        b += 4;
        c += 4;
        d += 4;
        //quizabcdcontroller.setAnswer(2, AnswerA, AnswerB, AnswerC, AnswerD, 4);
    }

}
