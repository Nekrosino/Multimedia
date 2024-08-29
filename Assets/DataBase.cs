using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System;

public class DataBase : MonoBehaviour
{
    private string dbPath;

    void Start()
    {
        dbPath = "URI=file:" + Application.dataPath + "/QuizDatabase.db";
        CreateDatabase();
        LogAnswers();
    }


    void CreateDatabase()
    {
        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                // Tworzenie tabel jeœli nie istniej¹
                command.CommandText = "CREATE TABLE IF NOT EXISTS Questions (QuestionID INTEGER PRIMARY KEY AUTOINCREMENT, QuestionText TEXT NOT NULL);";
                command.ExecuteNonQuery();

                command.CommandText = "CREATE TABLE IF NOT EXISTS Answers (AnswerID INTEGER PRIMARY KEY AUTOINCREMENT, QuestionID INTEGER NOT NULL, AnswerText TEXT NOT NULL, IsCorrect INTEGER NOT NULL, FOREIGN KEY (QuestionID) REFERENCES Questions(QuestionID));";
                command.ExecuteNonQuery();

                // Sprawdzenie, czy pytanie ju¿ istnieje
                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic¹ Francji?';";
                long questionExists = (long)command.ExecuteScalar();

                if (questionExists == 0)
                {
                    // Jeœli pytanie nie istnieje, wstaw dane
                    command.CommandText = "INSERT INTO Questions (QuestionText) VALUES ('Co jest stolic¹ Francji?');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (1, 'Pary¿', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (1, 'Londyn', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (1, 'Berlin', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (1, 'Warszawa', 0);";
                    command.ExecuteNonQuery();
                }

                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic¹ Polski?';";
                long questionExists2 = (long)command.ExecuteScalar();

                if (questionExists2 == 0)
                {
                    // Jeœli pytanie nie istnieje, wstaw dane
                    command.CommandText = "INSERT INTO Questions (QuestionText) VALUES ('Co jest stolic¹ Polski?');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (2, 'Radom', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (2, 'Gniezno', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (2, 'Kraków', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (2, 'Warszawa', 1);";
                    command.ExecuteNonQuery();
                }

                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic¹ Niemiec?';";
                long questionExists3 = (long)command.ExecuteScalar();

                if (questionExists3 == 0)
                {
                    command.CommandText = "INSERT INTO Questions (QuestionText) VALUES ('Co jest stolic¹ Niemiec?');";
                    command.ExecuteNonQuery();


                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (2, 'Hamburg', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (2, 'Monachium', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (2, 'Berlin', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (2, 'Dortmund', 0);";
                    command.ExecuteNonQuery();
                }


                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic¹ W³och?';";
                long questionExists4 = (long)command.ExecuteScalar();

                if (questionExists4 == 0)
                {
                    command.CommandText = "INSERT INTO Questions (QuestionText) VALUES ('Co jest stolic¹ W³och?');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (3, 'Rzym', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (3, 'Lizbona', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (3, 'Ateny', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (3, 'Wiedeñ', 0);";
                    command.ExecuteNonQuery();
                }


                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic¹ Hiszpanii?';";
               long questionExists5 = (long)command.ExecuteScalar();

                if (questionExists == 0)
                {
                    command.CommandText = "INSERT INTO Questions (QuestionText) VALUES ('Co jest stolic¹ Hiszpanii?');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (4, 'Barcelona', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (4, 'Sewilla', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (4, 'Valencia', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (4, 'Madryt', 1);";
                    command.ExecuteNonQuery();
                }

                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic¹ Wielkiej Brytanii?';";
                long questionExists6 = (long)command.ExecuteScalar();

                if (questionExists6 == 0)
                {
                    command.CommandText = "INSERT INTO Questions (QuestionText) VALUES ('Co jest stolic¹ Wielkiej Brytanii?');";
                    command.ExecuteNonQuery();


                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (5, 'Edynburg', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (5, 'Dublin', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (5, 'Londyn', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (5, 'Manchester', 0);";
                    command.ExecuteNonQuery();
                }

                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic¹ Portugalii?';";
               long questionExists7 = (long)command.ExecuteScalar();

                if (questionExists7 == 0)
                {
                    command.CommandText = "INSERT INTO Questions (QuestionText) VALUES ('Co jest stolic¹ Portugalii?');";
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

                // Pytanie o Grecjê
                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic¹ Grecji?';";
                long questionExists8 = (long)command.ExecuteScalar();

                if (questionExists8 == 0)
                {
                    command.CommandText = "INSERT INTO Questions (QuestionText) VALUES ('Co jest stolic¹ Grecji?');";
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

                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic¹ Rosji?';";
                long questionExists9 = (long)command.ExecuteScalar();

                if (questionExists9 == 0)
                {
                    command.CommandText = "INSERT INTO Questions (QuestionText) VALUES ('Co jest stolic¹ Rosji?');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (9, 'Sankt Petersburg', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (9, 'Moskwa', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (9, 'Nowosybirsk', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (9, 'Kazañ', 0);";
                    command.ExecuteNonQuery();
                }

                command.CommandText = "SELECT COUNT(*) FROM Questions WHERE QuestionText = 'Co jest stolic¹ Ukrainy?';";
                long questionExists10 = (long)command.ExecuteScalar();

                if (questionExists10 == 0)
                {
                    // Jeœli pytanie nie istnieje, wstaw dane
                    command.CommandText = "INSERT INTO Questions (QuestionText) VALUES ('Co jest stolic¹ Ukrainy?');";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (2, 'Moskwa', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (2, 'Radom', 0);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (2, 'Kijów', 1);";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Answers (QuestionID, AnswerText, IsCorrect) VALUES (2, 'Lwów', 0);";
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

                        Debug.Log($"AnswerID: {answerID}, QuestionID: {questionID}, AnswerText: {answerText}, IsCorrect: {isCorrect}");
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
            Debug.Log("Test " + element);
        }
    }

    public void AddQuestionsToQuiz(List <string> pytania)
    {
        dbPath = "URI=file:" + Application.dataPath + "/QuizDatabase.db";
        // List<string> pytania = new List<string>();
        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Questions";
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string answerText = reader.GetString(1);
                        pytania.Add(answerText);

                    }
                }
            }

        }
        foreach (string element in pytania)
        {
            Debug.Log("Test " + element);
        }
    }
}
