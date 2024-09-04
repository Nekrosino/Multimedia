using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class DataBase : MonoBehaviour
{
    private string dbPath;
   // int questionNumber=1;

    [Serializable]
    public class Question
    {
        public string QuestionText;
        public string imgsrc;
        public List<Answer> Answers = new List<Answer>();

        public Question(string QuestionText,string imgsrc)
        {
            this.QuestionText = QuestionText;
            this.imgsrc = imgsrc;
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
    }
    //public List<Question> Questions;

    void Start()
    {
        dbPath = "URI=file:" + Application.dataPath + "/QuizDatabase.db";
        CreateDatabase();
        LogAnswers();
/*        for (int i = 1; i <= 10;i++)
        {
           // AddQuestionsToQuiz(Questions);
        }*/
    }

/*    public void returnQuestion(int questionNumber, out string questionname, out string answerAName, out bool isCorrectA, out string answerBName, out bool isCorrectB, out string answerCName, out bool isCorrectC, out string answerDName, out bool isCorrectD)
    {
        questionname = Questions[questionNumber].QuestionText;
        answerAName = Questions[questionNumber].Answers[0].answerText;
        isCorrectA = Questions[questionNumber].Answers[0].isCorrect;
        answerBName = Questions[questionNumber].Answers[1].answerText;
        isCorrectB = Questions[questionNumber].Answers[1].isCorrect;
        answerCName = Questions[questionNumber].Answers[2].answerText;
        isCorrectC = Questions[questionNumber].Answers[2].isCorrect;
        answerDName = Questions[questionNumber].Answers[3].answerText;
        isCorrectD = Questions[questionNumber].Answers[3].isCorrect;

    }*/



    void CreateDatabase()
    {
        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                // Tworzenie tabel je�li nie istniej�
                command.CommandText = "CREATE TABLE IF NOT EXISTS Questions (QuestionID INTEGER PRIMARY KEY AUTOINCREMENT, QuestionText TEXT NOT NULL, imgsrc TEXT NOT NULL DEFAULT 'placeholder');";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS Answers (AnswerID INTEGER PRIMARY KEY AUTOINCREMENT, QuestionID INTEGER NOT NULL, AnswerText TEXT NOT NULL, IsCorrect INTEGER NOT NULL, FOREIGN KEY (QuestionID) REFERENCES Questions(QuestionID));";
                command.ExecuteNonQuery();

                // Sprawdzenie, czy pytanie ju� istnieje
                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic� Francji?';";
                long questionExists = (long)command.ExecuteScalar();

                if (questionExists == 0)
                {
                    // Je�li pytanie nie istnieje, wstaw dane
                    command.CommandText = "INSERT INTO Questions (QuestionText, imgsrc) VALUES ('Co jest stolic� Francji?', 'francja_img');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (1, 'Pary�', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (1, 'Londyn', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (1, 'Berlin', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (1, 'Warszawa', 0);";
                    command.ExecuteNonQuery();
                }

                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic� Polski?';";
                long questionExists2 = (long)command.ExecuteScalar();

                if (questionExists2 == 0)
                {
                    // Je�li pytanie nie istnieje, wstaw dane
                    command.CommandText = "INSERT INTO Questions (QuestionText, imgsrc) VALUES ('Co jest stolic� Polski?', 'polska_img');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (2, 'Radom', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (2, 'Gniezno', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (2, 'Krak�w', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (2, 'Warszawa', 1);";
                    command.ExecuteNonQuery();
                }

                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic� Niemiec?';";
                long questionExists3 = (long)command.ExecuteScalar();

                if (questionExists3 == 0)
                {
                    command.CommandText = "INSERT INTO Questions (QuestionText, imgsrc) VALUES ('Co jest stolic� Niemiec?', 'niemcy_img');";
                    command.ExecuteNonQuery();


                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (3, 'Hamburg', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (3, 'Monachium', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (3, 'Berlin', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (3, 'Dortmund', 0);";
                    command.ExecuteNonQuery();
                }


                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic� W�och?';";
                long questionExists4 = (long)command.ExecuteScalar();

                if (questionExists4 == 0)
                {
                    command.CommandText = "INSERT INTO Questions (QuestionText, imgsrc) VALUES ('Co jest stolic� W�och?' , 'wlochy_img');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (4, 'Rzym', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (4, 'Lizbona', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (4, 'Ateny', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (4, 'Wiede�', 0);";
                    command.ExecuteNonQuery();
                }


                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic� Hiszpanii?';";
               long questionExists5 = (long)command.ExecuteScalar();

                if (questionExists5 == 0)
                {
                    command.CommandText = "INSERT INTO Questions (QuestionText, imgsrc) VALUES ('Co jest stolic� Hiszpanii?' , 'hiszpania_img');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (5, 'Barcelona', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (5, 'Sewilla', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (5, 'Valencia', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (5, 'Madryt', 1);";
                    command.ExecuteNonQuery();
                }

                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic� Wielkiej Brytanii?';";
                long questionExists6 = (long)command.ExecuteScalar();

                if (questionExists6 == 0)
                {
                    command.CommandText = "INSERT INTO Questions (QuestionText, imgsrc) VALUES ('Co jest stolic� Wielkiej Brytanii?' , 'uk_img');";
                    command.ExecuteNonQuery();


                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (6, 'Edynburg', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (6, 'Dublin', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (6, 'Londyn', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (6, 'Manchester', 0);";
                    command.ExecuteNonQuery();
                }

                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic� Portugalii?';";
               long questionExists7 = (long)command.ExecuteScalar();

                if (questionExists7 == 0)
                {
                    command.CommandText = "INSERT INTO Questions (QuestionText, imgsrc) VALUES ('Co jest stolic� Portugalii?' , 'portugalia_img');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (7, 'Porto', 0);";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (7, 'Lizbona', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (7, 'Madryt', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (7, 'Barcelona', 0);";
                    command.ExecuteNonQuery();
                }

                // Pytanie o Grecj�
                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic� Grecji?';";
                long questionExists8 = (long)command.ExecuteScalar();

                if (questionExists8 == 0)
                {
                    command.CommandText = "INSERT INTO Questions (QuestionText, imgsrc) VALUES ('Co jest stolic� Grecji?' , 'grecja_img');";
                    command.ExecuteNonQuery();


                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (8, 'Saloniki', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (8, 'Heraklion', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (8, 'Ateny', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (8, 'Patras', 0);";
                    command.ExecuteNonQuery();
                }

                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic� Rosji?';";
                long questionExists9 = (long)command.ExecuteScalar();

                if (questionExists9 == 0)
                {
                    command.CommandText = "INSERT INTO Questions (QuestionText, imgsrc) VALUES ('Co jest stolic� Rosji?' , 'rosja_img');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (9, 'Sankt Petersburg', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (9, 'Moskwa', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (9, 'Nowosybirsk', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (9, 'Kaza�', 0);";
                    command.ExecuteNonQuery();
                }

                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic� Ukrainy?';";
                long questionExists10 = (long)command.ExecuteScalar();

                if (questionExists10 == 0)
                {
                    // Je�li pytanie nie istnieje, wstaw dane
                    command.CommandText = "INSERT INTO Questions (QuestionText, imgsrc) VALUES ('Co jest stolic� Ukrainy?', 'ukraina_img');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (10, 'Moskwa', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (10, 'Radom', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (10, 'Kij�w', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (10, 'Lw�w', 0);";
                    command.ExecuteNonQuery();
                }

                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic� Belgii?';";
                long questionExists11 = (long)command.ExecuteScalar();

                if (questionExists11 == 0)
                {
                    // Je�li pytanie nie istnieje, wstaw dane
                    command.CommandText = "INSERT INTO Questions (QuestionText, imgsrc) VALUES ('Co jest stolic� Belgii?', 'Belgia_img');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (11, 'Bruksela', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (11, 'Antwerpia', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (11, 'Brugia', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (11, 'Gandawa', 0);";
                    command.ExecuteNonQuery();
                }


                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic� Australii?';";
                long questionExists12 = (long)command.ExecuteScalar();

                if (questionExists12 == 0)
                {
                    // Je�li pytanie nie istnieje, wstaw dane
                    command.CommandText = "INSERT INTO Questions (QuestionText, imgsrc) VALUES ('Co jest stolic� Australii?', 'Australia_img');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (12, 'Canberra', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (12, 'Sydney', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (12, 'Melbourne', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (12, 'Perth', 0);";
                    command.ExecuteNonQuery();
                }



                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic� Japoni?';";
                long questionExists13 = (long)command.ExecuteScalar();

                if (questionExists13 == 0)
                {
                    // Je�li pytanie nie istnieje, wstaw dane
                    command.CommandText = "INSERT INTO Questions (QuestionText, imgsrc) VALUES ('Co jest stolic� Japoni?', 'Japonia_img');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (13, 'Tokio', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (13, 'Osaka', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (13, 'Kioto', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (13, 'Hiroshima', 0);";
                    command.ExecuteNonQuery();
                }



                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic� Brazylii?';";
                long questionExists14 = (long)command.ExecuteScalar();

                if (questionExists14 == 0)
                {
                    // Je�li pytanie nie istnieje, wstaw dane
                    command.CommandText = "INSERT INTO Questions (QuestionText, imgsrc) VALUES ('Co jest stolic� Brazylii?', 'Brazylia_img');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (14, 'Brasilia', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (14, 'Rio de Janeiro', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (14, 'Sao Paulo', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (14, 'Salvador', 0);";
                    command.ExecuteNonQuery();
                }


                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic� Egiptu?';";
                long questionExists15 = (long)command.ExecuteScalar();

                if (questionExists15 == 0)
                {
                    // Je�li pytanie nie istnieje, wstaw dane
                    command.CommandText = "INSERT INTO Questions (QuestionText, imgsrc) VALUES ('Co jest stolic� Egiptu?', 'Egipt_img');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (15, 'Kair', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (15, 'Aleksandria', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (15, 'Giza', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (15, 'Luxor', 0);";
                    command.ExecuteNonQuery();
                }



            }

        }
        
    }

    void LogAnswers()
    {
        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Answers";
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int answerID = reader.GetInt32(0);
                        int questionID = reader.GetInt32(1);
                        string answerText = reader.GetString(2);
                        bool isCorrect = reader.GetInt32(3) == 1;

                      //  Debug.Log($"AnswerID: {answerID}, QuestionID: {questionID}, AnswerText: {answerText}, IsCorrect: {isCorrect}");
                    }
                }
            }
        }
    }

    public void AddAnswersToQuiz(List <string> odpowiedzi)
    {
        dbPath = "URI=file:" + Application.dataPath + "/QuizDatabase.db";
        // List<string> pytania = new List<string>();
        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Answers";
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string answerText = reader.GetString(2);
                        odpowiedzi.Add(answerText);
                 
                    }
                }
            }

        }
        foreach (string element in odpowiedzi)
        {
          //  Debug.Log("Test " + element);
        }
    }

    //public void AddQuestionsToQuiz(List <string> pytania)
    public void AddQuestionsToQuiz(List<Question>questions,int questionNumber)
    {
        dbPath = "URI=file:" + Application.dataPath + "/QuizDatabase.db";
       // List <string> pytania = new List<string>();
         //List<string> odpowiedzi = new List<string>();
        //List<bool> isValid = new List<bool>();
       // List <Question> questions = new List<Question>();
        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {  
                command.CommandText = "SELECT * FROM Questions where QuestionID ="+ questionNumber;
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {   
                        
                        string questionText = reader.GetString(1);
                        string imgsrc = reader.GetString(2);
                        Question question = new Question(questionText,imgsrc);
                        //pytania.Add(QuestionText, imgsrc);
                        //questions.Add(new Question(QuestionText, imgsrc));
                        using (var command2 = connection.CreateCommand())
                        {
                            command2.CommandText = "SELECT * from Answers where QuestionID = "+questionNumber;
                            using (IDataReader reader2 = command2.ExecuteReader())
                            {
                                while (reader2.Read())
                                {
                                    string answerText = reader2.GetString(2);
                                    bool isCorrect = reader2.GetBoolean(3);
                                    // odpowiedzi.Add(answerText);
                                    // isValid.Add(isCorrect);
                                    question.Answers.Add(new Answer(answerText, isCorrect));
                                }
                            }
                        }
                        questions.Add(question);
                       

                    }
                   // questionmin++;
                }
            }

        }
       foreach(var question in questions)
        {
            Debug.Log("Pytanie: " + question.QuestionText);
            foreach(var answer in question.Answers)
            {
                Debug.Log("Odpowiedz: " + answer.answerText + " IsCorrect " + answer.isCorrect);
            }
            
        }

    }



}
