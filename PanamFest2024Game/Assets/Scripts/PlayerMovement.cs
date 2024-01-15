using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    MasterInput Controls;

    private Rigidbody rb;
    private Vector2 InputDir;
    [SerializeField] private float MoveSpeed;
    private bool Moving;

    private Vector3 AimDir;
    [SerializeField] private float RotateSpeed;

    void Start()
    {
        Controls = new MasterInput();
        Controls.Enable();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Controls.Player.Accelerate.IsInProgress())
        {
            Moving = true;
        }
        else
        {
            Moving = false;
        }

        AimDir = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (AimDir != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(AimDir, Vector3.up), RotateSpeed);
        }
    }

    void FixedUpdate()
    {
        if(Moving)
        {
            Accelerate();
        }
    }

    public void OnMovement(InputValue _Value)
    {
        InputDir = _Value.Get<Vector2>();
    }

    void Accelerate()
    {
        rb.AddForce(new Vector3(-InputDir.x, 0f, -InputDir.y) * MoveSpeed, ForceMode.Force);
    }
}
