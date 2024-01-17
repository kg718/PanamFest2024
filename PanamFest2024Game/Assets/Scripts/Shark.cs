using UnityEngine;

public class Shark : MonoBehaviour
{
    private GameOver GameOverScene;
    private Animator TransitionAnimator;
    private PlayerMovement movement;

    void Start()
    {
        GameOverScene = GameObject.FindWithTag("Canvas").transform.Find("GameOver").GetComponent<GameOver>();
        GameOverScene.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            movement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
            TransitionAnimator = GameObject.Find("TransitionPanel").GetComponent<Animator>();
            Destroy(movement);
            Invoke("AnimateOut", 1f);
            GameOverScene.GameOverScreen();
            Cursor.visible = true;
        }
    }

    private void AnimateOut()
    {
        TransitionAnimator.Play("Transition_Out");

    }
}
