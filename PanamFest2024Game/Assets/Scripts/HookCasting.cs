using UnityEngine;
using UnityEngine.InputSystem;

public class HookCasting : MonoBehaviour
{
    MasterInput Controls;

    private PlayerMovement movement;

    [SerializeField] private Transform HookPoint;
    [SerializeField] private GameObject BobberPrefab;

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
        if(Bobber == null)
        {
            Bobber = Instantiate(BobberPrefab, transform.position, Quaternion.identity);
            BobberLaunch Launcher = Bobber.GetComponent<BobberLaunch>();
            Launcher.TargetPosition = HookPoint.position;
        }
        else
        {
            Destroy(Bobber);
        }
    }

    public void OnCastLine()
    {
        Cast();
    }
}
