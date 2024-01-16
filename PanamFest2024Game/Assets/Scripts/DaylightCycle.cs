using UnityEngine;

public class DaylightCycle : MonoBehaviour
{
    [SerializeField] private float RevolutionSpeed;
    private float CurrentRotation;

    private void Update()
    {
        CurrentRotation += RevolutionSpeed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(CurrentRotation, CurrentRotation, 0);
    }
}
