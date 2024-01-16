using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class HookCasting : MonoBehaviour
{
    MasterInput Controls;

    private PlayerMovement movement;

    [SerializeField] private Transform CastPoint;
    [SerializeField] private Transform HookPoint;
    [SerializeField] private GameObject BobberPrefab;
    [HideInInspector] public BobberHooking Hooking;

    [SerializeField] private CinemachineVirtualCamera VCam1;
    [SerializeField] private CinemachineVirtualCamera VCam2;
 
    private GameObject Bobber;

    void Start()
    {
        Controls = new MasterInput();
        Controls.Enable();
        movement = GetComponent<PlayerMovement>();
        VCam1.Priority = 1;
        VCam2.Priority = 0;
    }

    void Update()
    {
        if(Bobber == null)
        {
            try
            {
                movement.enabled = true;
            }
            catch
            {

            }
        }
        else
        {
            movement.enabled = false;
        }
    }

    public void Cast()
    {
        if (Bobber == null)
        {
            Bobber = Instantiate(BobberPrefab, CastPoint.position, Quaternion.identity);
            BobberLaunch Launcher = Bobber.GetComponent<BobberLaunch>();
            Launcher.TargetPosition = HookPoint.position;
            VCam1.Priority = 0;
            VCam2.Priority = 1;
        }
        else
        {
            if (!Hooking.HasHookedFish)
            {
                RetractLine();
            }
        }
    }

    public void OnCastLine()
    {
        Cast();
    }

    public void RetractLine()
    {
        Destroy(Bobber);
        VCam1.Priority = 1;
        VCam2.Priority = 0;
    }
}
