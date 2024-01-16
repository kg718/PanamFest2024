using Cinemachine;
using UnityEngine;

public class CamerShake : MonoBehaviour
{
    private CinemachineVirtualCamera VCam;
    private float CurrentShakeTime;

    void Start()
    {
        VCam = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        CurrentShakeTime -= Time.deltaTime;
        if(CurrentShakeTime < 0)
        {
            CinemachineBasicMultiChannelPerlin CBMCP = VCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            CBMCP.m_AmplitudeGain = 0f;
        }
    }

    public void ShakeCamera(float _intensity, float _time)
    {
        CurrentShakeTime = _time;
        CinemachineBasicMultiChannelPerlin CBMCP = VCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        CBMCP.m_AmplitudeGain = _intensity;
    }
}
