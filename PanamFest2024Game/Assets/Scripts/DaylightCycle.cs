using UnityEngine;

public class DaylightCycle : MonoBehaviour
{
    [SerializeField] private float RevolutionSpeed;
    private float CurrentRotation;
    [HideInInspector] public bool Day;
    [HideInInspector] public bool Night;

    private void Update()
    {
        CurrentRotation += RevolutionSpeed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(CurrentRotation, CurrentRotation, 0);

        if(CurrentRotation > 180)
        {
            Night = true;
            Day = false;
        }
        else
        {
            Day = true;
            Night = false;
        }

        if(CurrentRotation > 360)
        {
            CurrentRotation = 0;
        }
    }
}
