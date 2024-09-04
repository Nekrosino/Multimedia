using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/*! A test class */
public class SummaryController : MonoBehaviour
{   

    VisualElement root;
    Button returnMenuButton;
    [SerializeField] Points points;
    [SerializeField] SceneController sceneController;
    Label pointsSummary;
    int score;    /*!< an integer value */

    //!< a member function.
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        returnMenuButton = root.Q<Button>("BackButton");
        pointsSummary = root.Q<Label>("PointsSummary");
        score = Points.Instance.getScore();
        pointsSummary.text = ("Wynik: " + score);
      
        /**
         * Przycisk
         */
        returnMenuButton.clicked += () =>
        {
            sceneController.LoadMainMenu();  //!< a member function.
            Points.Instance.Reset(); /**Reset punktow*/
        };
        
    }


}
