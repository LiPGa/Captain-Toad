using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YingBi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,1,0));
    }
    void OnTriggerEnter(Collider other)
    {
        //当碰到玩家时销毁自己
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
