using UnityEngine;

public class MoleculeViewToggle : MonoBehaviour
{
    private bool showParticles = false;

    public void Toggle()
    {
        showParticles = !showParticles;

        foreach (var matter in FindObjectsOfType<MatterObject>())
        {
            matter.ShowParticles(showParticles);
        }

        Debug.Log("Particle view " + (showParticles ? "ON" : "OFF"));
    }
}
