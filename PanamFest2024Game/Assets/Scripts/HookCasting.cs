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

    private GameObject Bobber;

    void Start()
    {
        Controls = new MasterInput();
        Controls.Enable();
        movement = GetComponent<PlayerMovement>();
        
    }

    void Update()
    {
        if(Bobber == null)
        {
            movement.enabled = true;
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
        }
        else
        {
            if (!Hooking.HasHookedFish)
            {
                Destroy(Bobber);
            }
        }
    }

    public void OnCastLine()
    {
        Cast();
    }
}
