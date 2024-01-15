using UnityEngine;
using UnityEngine.InputSystem;

public class BobberLaunch : MonoBehaviour
{
    MasterInput Controls;

    private Rigidbody rb;
    private Vector2 InputDir;
    private LineRenderer Line;
    private BobberHooking Hooking;

    [HideInInspector] public Vector3 TargetPosition;
    private bool Casting;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float CastDelay;
    private float CurrentCastDelay;
    private Transform CastPoint;

    void Start()
    {
        Controls = new MasterInput();
        Controls.Enable();
        rb = GetComponent<Rigidbody>();
        Line = GetComponent<LineRenderer>();
        Hooking = GetComponent<BobberHooking>();
        Casting = true;
        CurrentCastDelay = CastDelay;
        CastPoint = GameObject.Find("CastPoint").transform;
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
        rb.AddForce(new Vector3(-InputDir.x, 0f, -InputDir.y) * MoveSpeed, ForceMode.Force);
    }

    public void OnMovement(InputValue _Value)
    {
        InputDir = _Value.Get<Vector2>();
    }
}
