using UnityEngine;
using UnityEngine.UIElements;

public class SoundButtons : MonoBehaviour
{
    public AudioClip hoverSound; // DŸwiêk najechania na przycisk
    private AudioSource audioSource;
    private VisualElement rootVisualElement;
    private static SoundButtons instance;
   
    private void Awake()
    {
  
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("Brak AudioSource na obiekcie: " + gameObject.name);
        }


        var uiDocument = GetComponent<UIDocument>();
        if (uiDocument != null)
        {
            rootVisualElement = uiDocument.rootVisualElement;
        }
        else
        {
            Debug.LogError("Brak UIDocument na obiekcie: " + gameObject.name);
        }
    }

    private void Start()
    {

        var buttons = rootVisualElement.Query<Button>().ToList();
        audioSource.volume = 0.2f;
        foreach (var button in buttons)
        {
            button.RegisterCallback<MouseEnterEvent>(ev => PlayHoverSound());
   
        }
    }

    private void PlayHoverSound()
    {
        if (hoverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }
    }
}
