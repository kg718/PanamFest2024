using UnityEngine;

public class CatchFish : MonoBehaviour
{
    private FishMovement Movement;
    private Rigidbody rb;

    private GameObject BobberObject;
    private bool Hooked = false;
    private BobberHooking Hooking;
    private HookCasting Casting;

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
            BobberObject = other.gameObject;
            if(!BobberObject.GetComponent<BobberHooking>().HasHookedFish)
            {
                rb.velocity = Vector3.zero;
                Movement.enabled = false;
                Hooking = BobberObject.gameObject.GetComponent<BobberHooking>();
                Casting = GameObject.FindWithTag("Player").GetComponent<HookCasting>();
                Hooking.HasHookedFish = true;
                Hooked = true;
            }
        }

        if(other.gameObject.tag == "Player" && Hooked)
        {
            Hooking.HasHookedFish = false;
            Casting.RetractLine();
            Destroy(gameObject);
        }
    }
}
