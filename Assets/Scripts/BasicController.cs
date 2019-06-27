using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicController : MonoBehaviour
{

    public float speed;

    protected Camera mainCamera;

    private string hor = "Horizontal";
    private string ver = "Vertical";

    public bool inMove = false;
	// Use this for initialization
	void Start () {
        mainCamera = Camera.main;
    }

    public Vector2 ReadInput()
    {
        float h = Input.GetAxis(hor);
        float v = Input.GetAxis(ver);

        return new Vector2(h, v);
    }

    public Vector3 GetMoveDir(Vector2 inputDir)
    {
        return new Vector3(inputDir.x, 0.0f, inputDir.y);
    }

    public Vector3 GetMoveDirInWorldSpace(Vector2 inputDir)
    {
        Vector3 cameraSpaceMoveDir = new Vector3(inputDir.x, 0.0f, inputDir.y);
        Vector3 up = Vector3.up;
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = Vector3.Cross(up,forward);
        forward = Vector3.Cross(right, up);

        return right * inputDir.x + forward * inputDir.y;

    }



    // Update is called once per frame
    void FixedUpdate () 
    {

        Vector2 inputValue = ReadInput();

        Vector3 moveDir = GetMoveDirInWorldSpace(inputValue);

        transform.Translate(moveDir * speed * Time.deltaTime , Space.World);

        if(moveDir.magnitude > 0.01f)
        {
            transform.forward = moveDir;
            inMove = true;
        }else
        {
            inMove = false;
        }
        

	}

    
}
