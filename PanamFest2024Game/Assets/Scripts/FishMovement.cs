using UnityEngine;

public class FishMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Transform CenterPoint;
    [SerializeField] private Transform FrontPoint;
    private Transform BoatPoint;

    [SerializeField] private float MoveSpeed;
    [SerializeField] private float RotateSpeed;

    Vector3 Dir;
    Vector3 TurnDir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BoatPoint = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Dir = CenterPoint.position - FrontPoint.position;
        TurnDir = new Vector3(CenterPoint.position.x, 0f, CenterPoint.position.z) - new Vector3(BoatPoint.position.x, 0f, BoatPoint.position.z);

    }

    private void FixedUpdate()
    {
        Swim();
        if (TurnDir != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(TurnDir, Vector3.up), RotateSpeed);
        }
    }

    private void Swim()
    {
        rb.AddForce(Dir.normalized * MoveSpeed, ForceMode.Force); 
    }
}
