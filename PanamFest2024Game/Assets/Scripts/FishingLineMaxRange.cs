using UnityEngine;

public class FishingLineMaxRange : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float MaxRange;
    [SerializeField] private float DrawbackSpeed;
    private Transform PlayerPos;

    private Vector3 Dir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerPos = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Dir = PlayerPos.position - transform.position;
    }

    private void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, PlayerPos.position) > MaxRange)
        {
            rb.AddForce(Dir.normalized * DrawbackSpeed, ForceMode.Force);
        }      
    }
}
