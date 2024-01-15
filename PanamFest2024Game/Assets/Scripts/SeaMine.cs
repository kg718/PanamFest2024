using UnityEngine;

public class SeaMine : MonoBehaviour
{
    [SerializeField] private GameObject ExplosionVFX;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(ExplosionVFX, transform.position, Quaternion.identity);
            Debug.Log("Game Over");
        }
    }
}
