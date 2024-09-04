using System.Collections;
using System.Collections.Generic;
//using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UIElements;

public class AuthorsController : MonoBehaviour
{
    public SceneController sceneController;
    VisualElement root;
    Button returnMenuButton;
    Label label1;
    Label label2;
    Label label3;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        returnMenuButton = root.Q<Button>("ReturnMenuButton");
        label1 = root.Q<Label>("Label1");
        label2 = root.Q<Label>("Label2");
        label3 = root.Q<Label>("Label3");

        StartCoroutine(Korutynka());

        returnMenuButton.clicked += () =>
        {
            label1.RemoveFromClassList("end6");
            label2.RemoveFromClassList("end7");
            label3.RemoveFromClassList("end8");
            sceneController.LoadMainMenu();
   
        };
    }


    IEnumerator Korutynka()
    {
        Debug.Log("Start korutynki");
        yield return new WaitForSeconds(0.25f);
        label1.AddToClassList("end6");
        label2.AddToClassList("end7");
        label3.AddToClassList("end8");

        Debug.Log("Dodano korutynke");
    }


}


