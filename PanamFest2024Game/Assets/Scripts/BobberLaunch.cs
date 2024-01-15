using UnityEngine;

public class BobberLaunch : MonoBehaviour
{
    MasterInput Controls;

    [HideInInspector] public Vector3 TargetPosition;
    private bool Casting;

    void Start()
    {
        Controls = new MasterInput();
        Controls.Enable();
        Casting = true;
    }

    void FixedUpdate()
    {
        if(TargetPosition != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, 0.1f);
        }
        if(!Casting)
        {
            MoveBobber();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Casting = false;
    }

    private void MoveBobber()
    {

    }
}
