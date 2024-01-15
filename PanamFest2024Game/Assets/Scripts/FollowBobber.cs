using UnityEngine;

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
        FollowPoint = GameObject.FindWithTag("Bobber").transform;
    }


}
