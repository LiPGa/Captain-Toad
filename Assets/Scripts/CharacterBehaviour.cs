using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BasicController))]
public class CharacterBehaviour : MonoBehaviour {

    BasicController controller = null;
    public GameObject behaviourRoot = null;
    public AnimationCurve scaleCurve;
    public AnimationCurve rotationCurve;
    public float totalTime = 1.0f;
    private float time = 0.0f;
    public float inMoveSpeed = 2.0f;
    public bool rotateInMove = false;
	// Use this for initialization
	void Start () {
		controller = GetComponent<BasicController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(behaviourRoot == null)
            return;

        if(controller.inMove)
        {
            time += Time.deltaTime * inMoveSpeed;
        }else
        {
            time += Time.deltaTime;
        }

        time = Mathf.Repeat(time , totalTime);
        float scale = scaleCurve.Evaluate(time/totalTime);
        behaviourRoot.transform.localScale = Vector3.one * scale;

        if(rotateInMove )
        {
            if (controller.inMove)
            {
                float z = rotationCurve.Evaluate(time / totalTime);
                Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, z);
                behaviourRoot.transform.localRotation = rotation;
            }
            else
            {
                behaviourRoot.transform.localRotation = Quaternion.identity;
            }
        }
        
	}
    
}
