using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class SummaryController : MonoBehaviour
{   

    VisualElement root;
    Button returnMenuButton;
    [SerializeField] Points points;
    [SerializeField] SceneController sceneController;
    Label pointsSummary;
    int score; 

 
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        returnMenuButton = root.Q<Button>("BackButton");
        pointsSummary = root.Q<Label>("PointsSummary");
        score = Points.Instance.getScore();
        pointsSummary.text = ("Wynik: " + score);
      

        returnMenuButton.clicked += () =>
        {
            sceneController.LoadMainMenu();
            Points.Instance.Reset(); 
        };
        
    }


}
