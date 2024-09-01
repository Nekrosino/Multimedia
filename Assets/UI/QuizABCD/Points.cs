using UnityEngine;

public class Points : MonoBehaviour
{
    // Statyczna w�a�ciwo��, kt�ra przechowuje jedyn� instancj� klasy GameManager
    public static Points Instance { get; private set; }
    public GameObject Score;

    // Mo�esz doda� inne pola i metody tutaj
    public int score;

    // Metoda wywo�ywana podczas tworzenia obiektu
    private void Awake()
    {
        // Sprawdzenie, czy instancja ju� istnieje
        if (Instance != null && Instance != this)
        {
            // Zniszcz nowy obiekt, je�li instancja ju� istnieje
            Destroy(Score);
            return;
        }

        // Ustawienie instancji na ten obiekt
        Instance = this;

        // Opcjonalnie: Zachowaj obiekt mi�dzy scenami
        DontDestroyOnLoad(Score);
    }

    // Przyk�adowa metoda
    public void givePoint()
    {
        score++;
    }

    public void Reset()
    {
        score = 0;
    }

    public int getScore()
    {
        return score;
    }
}