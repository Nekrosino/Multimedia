using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public QuizABCDController quizabcdcontroller;
    public List<string> pytania = new List<string>();
    int questionNumber=0;
    string questionText;
    // Start is called before the first frame update
    private void Awake()
    {
       // questionNumber = 0;

        pytania.AddRange(new List<string> { "Apple", "Banana", "Cherry" });
    }


    public void sendQuestion()
    {
        
        questionText = pytania[questionNumber];
        quizabcdcontroller.setQuestion(questionNumber, questionText);
        questionNumber += 1;
    }

    //Ustaw numer pytania
/*    public int nextQuestionNumber()
    {
        questionNumber += 1;
        nextQuestionText(questionNumber);
        return questionNumber;
       
    }*/

/*    public string nextQuestionText(int numberquestion)
    {
        questionText = pytania[numberquestion];
        
    }*/
    

}
