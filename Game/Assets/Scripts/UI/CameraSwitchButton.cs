using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchButton : MonoBehaviour
{
    [SerializeField] bool pointView = true;

    [SerializeField] Sound sound = new Sound();

    [SerializeField] Vector3 firstPersonPosition;
    [SerializeField] Vector3 thirdPersonPosition;

    [SerializeField] CinemachineVirtualCamera cinemachineCamera;

    public void Swap()
    {
        AudioManager.instance.Sound(sound.clips[0]);

        pointView = !pointView;

        if(pointView)
        {
            cinemachineCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = firstPersonPosition;
        }
        else
        {
            cinemachineCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = thirdPersonPosition;
        }
    }
}
