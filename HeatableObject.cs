using UnityEngine;

public class HeatableObject : MonoBehaviour
{
    public MatterState currentState;
    public GameObject solidForm;
    public GameObject liquidForm;
    public GameObject gasForm;

    private float heatLevel = 0f;
    public float meltThreshold = 3f;
    public float boilThreshold = 6f;

    public void ApplyHeat(float amount)
    {
        heatLevel += amount;
        CheckState();
    }

    private void CheckState()
    {
        if (heatLevel >= boilThreshold && currentState != MatterState.Gas)
        {
            SwitchState(MatterState.Gas);
        }
        else if (heatLevel >= meltThreshold && currentState == MatterState.Solid)
        {
            SwitchState(MatterState.Liquid);
        }
    }

    private void SwitchState(MatterState newState)
    {
        solidForm.SetActive(newState == MatterState.Solid);
        liquidForm.SetActive(newState == MatterState.Liquid);
        gasForm.SetActive(newState == MatterState.Gas);

        currentState = newState;
        Debug.Log($"Changed to: {newState}");
    }
}
