using UnityEngine;

public class SeaMine : MonoBehaviour
{
    [SerializeField] private GameObject ExplosionVFX;
    private Animator TransitionAnimator;
    private PlayerMovement movement;
    private CamerShake shake;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            movement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
            shake = GameObject.FindWithTag("MainCam").GetComponent<CamerShake>();
            shake.ShakeCamera(5f, 1f);
            Destroy(movement);
            TransitionAnimator = GameObject.Find("TransitionPanel").GetComponent<Animator>();
            Instantiate(ExplosionVFX, transform.position, Quaternion.identity);
            Invoke("AnimateOut", 1f);
            Debug.Log("Game Over");
        }
    }

    private void AnimateOut()
    {
        TransitionAnimator.Play("Transition_Out");
    }
}
