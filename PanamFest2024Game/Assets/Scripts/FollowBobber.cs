using UnityEngine;
using UnityEngine.InputSystem;

public class FollowBobber : MonoBehaviour
{
    MasterInput Controls;
    private Transform FollowPoint;

    void Start()
    {
        Controls = new MasterInput();
        Controls.Enable();
    }

    void Update()
    {
        try
        {
            transform.position = FollowPoint.position;
        }
        catch
        {

        }
    }

    public void OnCastLine()
    {
        FindPoint();
    }

    private void FindPoint()
    {
        try
        {
            FollowPoint = GameObject.FindWithTag("Bobber").transform;
        }
        catch
        { 
        
        }
    }


}
