using UnityEngine;
using UnityEngine.Rendering;

public class SortingZone : MonoBehaviour
{
    public MatterState acceptedState;
    public Transform snapPosition;

    private void OnTriggerEnter(Collider other)
    {
        var matter = other.GetComponent<MatterObject>();
        if (matter && matter.state == acceptedState)
        {
            // Snap to position
            other.transform.position = snapPosition.position;
            other.transform.rotation = snapPosition.rotation;

            // Optional feedback
            Debug.Log($"Correct! {matter.displayName} is a {acceptedState}.");
        }
        else
        {
            Debug.Log("Oops! Try again.");
        }
    }
}
