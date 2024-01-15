using UnityEngine;

public class BobberHooking : MonoBehaviour
{
    [HideInInspector] public bool HasHookedFish;

    void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<HookCasting>().Hooking = this;
    }

    void Update()
    {
        
    }
}
