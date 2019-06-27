using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterTrigger : MonoBehaviour {

    public UnityEvent enterEvent;
    public UnityEvent exitEvent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        BasicController controller = other.GetComponentInParent<BasicController>();
        if (controller != null)
        {
            enterEvent.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        BasicController controller = other.GetComponentInParent<BasicController>();
        if (controller != null)
        {
            exitEvent.Invoke();
        }
    }
}
