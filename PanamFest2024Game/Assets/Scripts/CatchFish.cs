using UnityEngine;

public class CatchFish : MonoBehaviour
{
    private FishMovement Movement;
    private Rigidbody rb;

    private GameObject BobberObject;
    private bool Hooked = false;

    void Start()
    {
        Movement = GetComponent<FishMovement>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Hooked)
        {
            transform.position = BobberObject.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bobber")
        {
            rb.velocity = Vector3.zero;
            Movement.enabled = false;
            BobberObject = other.gameObject;
            Hooked = true;
        }
    }
}
