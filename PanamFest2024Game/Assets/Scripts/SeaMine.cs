using Cinemachine;
using UnityEngine;

public class SeaMine : MonoBehaviour
{
    [SerializeField] private GameObject ExplosionVFX;
    private Animator TransitionAnimator;
    private PlayerMovement movement;
    private CinemachineVirtualCamera VCam;
    private float ShakeTimer = 1f;
    private float CurrentShakeTime;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            InvokeRepeating("DecrementShakeTime", 0f, 0.1f);
            //ShakeCamera();
            VCam = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
            movement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
            movement.enabled = false;
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

    private void ShakeCamera(float _intensity, float _time)
    {
        CinemachineBasicMultiChannelPerlin CBMCP = VCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        CBMCP.m_AmplitudeGain = _intensity;
    }

    private void DecrementShakeTime()
    {
        CurrentShakeTime -= 0.1f;
    }
}
