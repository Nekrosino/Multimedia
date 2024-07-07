using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public QuizABCDController quizabcdcontroller;
    public List<string> pytania = new List<string>();
    int questionNumber=0;
    string questionText;
    //Awake dziala Start nie dziala bo trzeba przed uruchomieniem klasy uzupelnic liste (chyba)
    private void Awake()
    {
       // questionNumber = 0;

        pytania.AddRange(new List<string> { "Apple", "Banana", "Cherry" });
    }

    //Wysyla tresc oraz numer pytania do ControlleraQuizu zeby ten mogl go wrzucic na intrefejs
    public void sendQuestion()
    {
        //przypisujemy tresc pytania z listy o numerze pytania czyli dla Pytania 0 - dostajemy tresc z indeksu numer 0 
        questionText = pytania[questionNumber];
        //wywolanie funkcji z kontrolera ktora ustawia numer pytania i jego tresc
        quizabcdcontroller.setQuestion(questionNumber, questionText);
        //zwiekszenie indeksu aby po kliknieciu przycisku zaladowalo kolejne pytanie
        //===================================================================================================================================================
        //DODAC coroutine zeby po wcisnieciu przycisku dodatkowo wyswietlala sie poprawna odpowiedz i dopiero po jakis 2 sekundach ladowalo kolejna odpowiedz
        //===================================================================================================================================================
        questionNumber += 1;
    }

}
