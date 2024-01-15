using UnityEngine;

public class DestroyOnTimer : MonoBehaviour
{
    [SerializeField] private float DestroyTime;

    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    void Update()
    {
        
    }
}
