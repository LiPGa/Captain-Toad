using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZuanShi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
