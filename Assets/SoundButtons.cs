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
        // Pobierz komponent AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("Brak AudioSource na obiekcie: " + gameObject.name);
        }

        // Pobierz root VisualElement z UIDocument
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
        // ZnajdŸ wszystkie elementy typu Button w hierarchii UI Toolkit
        var buttons = rootVisualElement.Query<Button>().ToList();
        audioSource.volume = 0.2f;
        // Dla ka¿dego przycisku dodaj obs³ugê najechania
        foreach (var button in buttons)
        {
            button.RegisterCallback<MouseEnterEvent>(ev => PlayHoverSound());
            //button.RegisterCallback<ClickEvent>(ev => PlayHoverSound());
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
