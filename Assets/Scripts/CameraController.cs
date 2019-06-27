using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cinemachine.CinemachineVirtualCamera)) ]
public class CameraController : MonoBehaviour {

    Cinemachine.CinemachineVirtualCamera virtualCamera;
    Cinemachine.CinemachineTransposer transposer;

    public float viewAngle = 45.0f;
    public float rotateSpeed = 1.0f;
    public float viewDistance = 10.0f;
    public float viewHeight = 10.0f;
	// Use this for initialization
	void Start () {
        virtualCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
        transposer = virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineTransposer>();
        viewDistance = transposer.m_FollowOffset.magnitude;
        viewHeight = transposer.m_FollowOffset.y;
    }

    public float ReadInput()
    {
        float left = Input.GetKey(KeyCode.Q)?1.0f:0.0f;
        float right = Input.GetKey(KeyCode.E)?-1.0f:0.0f;


        return left + right;
    }

    // Update is called once per frame
    void Update () {
        float rotateInput = ReadInput();
        viewAngle += rotateSpeed * rotateInput;

        transposer.m_FollowOffset.x = Mathf.Sin(viewAngle * Mathf.Deg2Rad) * viewDistance;
        transposer.m_FollowOffset.y = viewHeight;
        transposer.m_FollowOffset.z = Mathf.Cos(viewAngle * Mathf.Deg2Rad) * viewDistance;
	}
}
