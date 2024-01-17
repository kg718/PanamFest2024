using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class BobberLaunch : MonoBehaviour
{
    MasterInput Controls;

    private Rigidbody rb;
    private Vector2 InputDir;
    private LineRenderer Line;

    [HideInInspector] public Vector3 TargetPosition;
    private bool Casting;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float CaughtSpeed;
    [SerializeField] private float CastDelay;
    private float CurrentCastDelay;
    private Transform CastPoint;
    private BobberHooking Hooking;
    private HookCasting HCasting;


    float MouseX;
    float MouseY;

    void Start()
    {
        Controls = new MasterInput();
        Controls.Enable();
        rb = GetComponent<Rigidbody>();
        Line = GetComponent<LineRenderer>();
        Casting = true;
        CurrentCastDelay = CastDelay;
        CastPoint = GameObject.Find("CastPoint").transform;
        Hooking = GetComponent<BobberHooking>();
        HCasting = GameObject.FindWithTag("Player").GetComponent<HookCasting>();
    }

    private void Update()
    {
        CurrentCastDelay -= Time.deltaTime;
        if(CurrentCastDelay <= 0f)
        {
            Casting = false;
        }
        Line.SetPosition(0, transform.position);
        Line.SetPosition(1, CastPoint.position);
        MouseX = Controls.Player.MovementX.ReadValue<float>();
        MouseY = Controls.Player.MovementY.ReadValue<float>();
        InputDir = new Vector2(MouseX, MouseY);
        if(transform.position.y < -10f)
        {
            HCasting.RetractLine();
        }
    }

    void FixedUpdate()
    {
        MoveBobber();
        if(TargetPosition != null && Casting)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, 0.1f);
        }
    }

    private void MoveBobber()
    {
        if (!Hooking.HasHookedFish)
        {
            rb.AddForce(new Vector3(-InputDir.x, 0f, -InputDir.y).normalized * MoveSpeed, ForceMode.Force);
        }
        else
        {
            rb.AddForce(new Vector3(-InputDir.x, 0f, -InputDir.y).normalized * CaughtSpeed, ForceMode.Force);
        }
    }

    public void OnMovement(InputValue _Value)
    {
        //InputDir = _Value.Get<Vector2>();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player" && Hooking.HasHookedFish)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
