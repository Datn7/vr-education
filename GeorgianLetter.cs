using UnityEngine;
using TMPro;

public class GeorgianLetter : MonoBehaviour
{
    public string letterName; // e.g., 
    public string letterPronunciationName; // e.g., "Ani"
    public string wordExample; // e.g.,
    public AudioClip pronunciationAudio;

    private AudioSource audioSource;
    private GameObject infoPanel;
    private TextMeshPro infoText;

    void Start()
    {
        // Setup audio source
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = pronunciationAudio;

        // Create floating info panel
        infoPanel = new GameObject("InfoPanel");
        infoPanel.transform.SetParent(transform);
        infoPanel.transform.localPosition = new Vector3(0, 1f, 0);
        infoText = infoPanel.AddComponent<TextMeshPro>();
        infoText.alignment = TextAlignmentOptions.Center;
        infoText.fontSize = 2;
        infoText.text = "";
    }

    void OnMouseDown()
    {
        // Show letter info
        infoText.text = $"{letterName}\n({letterPronunciationName})\n{wordExample}";
        audioSource.Play();
    }

    void OnMouseExit()
    {
        // Hide text when not interacting
        infoText.text = "";
    }
}
