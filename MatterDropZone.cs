using UnityEngine;

public class MatterDropZone : MonoBehaviour
{
    public MatterType acceptedType; // Set in Inspector

    public GameObject correctVFX;
    public GameObject incorrectVFX;
    public AudioClip correctSound;
    public AudioClip incorrectSound;

    private void OnTriggerEnter(Collider other)
    {
        MatterChecker checker = other.GetComponent<MatterChecker>();
        if (checker == null) return;

        Vector3 pos = other.transform.position;

        bool isCorrect = checker.type == acceptedType;

        if (isCorrect)
        {
            if (correctVFX) Instantiate(correctVFX, pos, Quaternion.identity);
            if (correctSound) AudioSource.PlayClipAtPoint(correctSound, pos);
        }
        else
        {
            if (incorrectVFX) Instantiate(incorrectVFX, pos, Quaternion.identity);
            if (incorrectSound) AudioSource.PlayClipAtPoint(incorrectSound, pos);
        }

        // Optional: disable or destroy object after
        Destroy(other.gameObject);
    }
}
