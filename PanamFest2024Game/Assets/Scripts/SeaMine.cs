using Unity.VisualScripting;
using UnityEngine;

public class SeaMine : MonoBehaviour
{
    [SerializeField] private GameObject ExplosionVFX;
    private Animator TransitionAnimator;
    private PlayerMovement movement;
    private CamerShake shake;
    private GameOver GameOverScene;


    private void Start()
    {
        GameOverScene = GameObject.FindWithTag("Canvas").transform.Find("GameOver").GetComponent<GameOver>();
        GameOverScene.gameObject.SetActive(false);
    }
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
            GameOverScene.GameOverScreen();
            Cursor.visible = true;
            
        }
        if(collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }

    private void AnimateOut()
    {
        TransitionAnimator.Play("Transition_Out");
       
    }
    
    
}
