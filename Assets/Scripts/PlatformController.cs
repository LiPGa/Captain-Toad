using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    
    public Vector3 endOffset;
    public AnimationCurve moveCurve;
    private bool doOnce;
    public float moveTime = 1.0f;
    private float moveTimer = 0.0f;
    private float moveDirection = 0.0f;
    private Vector3 startPos;
    private Vector3 endPos;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
        endPos = transform.position + endOffset;
	}
	
	// Update is called once per frame
	void FixedUpdate() {

        moveTimer = moveTimer + moveDirection * Time.deltaTime;
        moveTimer = Mathf.Clamp(moveTimer, 0.0f, moveTime);
        float mix = moveCurve.Evaluate(moveTimer / moveTime);
        transform.position = Vector3.Lerp(startPos, endPos, mix);
	}

    public void MoveForward()
    {
        moveDirection = 1.0f;
    }

    public void MoveBackward()
    {
        moveDirection = -1.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        BasicController controller = other.GetComponentInParent<BasicController>();
        if ( controller != null)
        {
            controller.transform.parent = transform;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        BasicController controller = other.GetComponentInParent<BasicController>();
        if (other.GetComponentInParent<BasicController>() != null)
        {
            controller.transform.parent = null;
            
        }
    }
}
