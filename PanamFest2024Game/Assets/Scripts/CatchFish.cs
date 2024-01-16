using UnityEngine;

public class CatchFish : MonoBehaviour
{
    private FishMovement Movement;
    private Rigidbody rb;

    private GameObject BobberObject;
    private bool Hooked = false;
    private BobberHooking Hooking;
    private HookCasting Casting;
    FishSpawning Spawn;

    Vector3 TurnDir;
    [SerializeField] private Transform CenterPoint;
    private Transform BoatPoint;
    [SerializeField] private float RotateSpeed;

    void Start()
    {
        Movement = GetComponent<FishMovement>();
        rb = GetComponent<Rigidbody>();
        Spawn = GameObject.Find("FishSpawner").GetComponent<FishSpawning>();
        BoatPoint = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if(Hooked)
        {
            transform.position = BobberObject.transform.position;
            TurnDir = new Vector3(CenterPoint.position.x, 0f, CenterPoint.position.z) - new Vector3(BoatPoint.position.x, 0f, BoatPoint.position.z);
        }

        if (Hooked && TurnDir != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(TurnDir, Vector3.up), RotateSpeed);
        }
    }

    private void FixedUpdate()
    {

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
            Spawn.CurrentFishTotal -= 1;
            Destroy(gameObject);
        }
    }
}
