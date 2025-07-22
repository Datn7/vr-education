using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public enum MatterType { Matter, NotMatter }

[RequireComponent(typeof(AudioSource))]
public class MatterChecker : MonoBehaviour
{
    public MatterType type;

    [Header("Feedback")]
    public GameObject correctEffectPrefab;
    public GameObject incorrectEffectPrefab;
    public AudioClip correctSound;
    public AudioClip incorrectSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void CheckMatter()
    {
        if (type == MatterType.Matter)
        {
            if (correctEffectPrefab)
                Instantiate(correctEffectPrefab, transform.position, Quaternion.identity);

            if (correctSound)
                audioSource.PlayOneShot(correctSound);
        }
        else
        {
            if (incorrectEffectPrefab)
                Instantiate(incorrectEffectPrefab, transform.position, Quaternion.identity);

            if (incorrectSound)
                audioSource.PlayOneShot(incorrectSound);
        }
    }
}
