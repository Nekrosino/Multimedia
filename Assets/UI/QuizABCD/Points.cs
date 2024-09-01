using UnityEngine;

public class Points : MonoBehaviour
{
    // Statyczna w³aœciwoœæ, która przechowuje jedyn¹ instancjê klasy GameManager
    public static Points Instance { get; private set; }
    public GameObject Score;

    // Mo¿esz dodaæ inne pola i metody tutaj
    public int score;

    // Metoda wywo³ywana podczas tworzenia obiektu
    private void Awake()
    {
        // Sprawdzenie, czy instancja ju¿ istnieje
        if (Instance != null && Instance != this)
        {
            // Zniszcz nowy obiekt, jeœli instancja ju¿ istnieje
            Destroy(Score);
            return;
        }

        // Ustawienie instancji na ten obiekt
        Instance = this;

        // Opcjonalnie: Zachowaj obiekt miêdzy scenami
        DontDestroyOnLoad(Score);
    }

    // Przyk³adowa metoda
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