using UnityEngine;

public class DestroyWhenFarAway : MonoBehaviour
{
    [SerializeField] private float DestroyDistance;
    private Transform PlayerPos;

    void Start()
    {
        PlayerPos = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, PlayerPos.position) > DestroyDistance)
        {
            Destroy(gameObject);
        }
    }
}
