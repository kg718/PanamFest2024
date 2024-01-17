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

    float MouseX;
    float MouseY;

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
            MouseX = 0f;
            MouseY = 0f;
        }

        AimDir = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (AimDir != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(AimDir, Vector3.up), RotateSpeed);
        }
        //MouseX = Controls.Player.MovementX.ReadValue<float>();
        //MouseY = Controls.Player.MovementY.ReadValue<float>();
        MouseX += Input.GetAxis("Mouse X");
        MouseY += Input.GetAxis("Mouse Y");
        InputDir = new Vector2(MouseX, MouseY).normalized;
        //Debug.Log(InputDir.x + "" +  InputDir.y);
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
        //InputDir = _Value.Get<Vector2>();
    }

    void Accelerate()
    {
        rb.AddForce(new Vector3(-InputDir.x, 0f, -InputDir.y).normalized * MoveSpeed, ForceMode.Force);
    }
}
