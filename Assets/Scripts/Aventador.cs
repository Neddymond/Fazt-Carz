using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Aventador : MonoBehaviour {

    public Rigidbody rigidbody;
    public float acceleration;
    public float acceleratingSpeedLimit;
    public float reverseSpeedLimit;
    public float maxTyreRotation;
    


    //Steering 
    public float SteeringSensitivity;

    //Tyres


    public GameObject FrontLeftTyre;
    public GameObject FrontRightTyre;
    public GameObject BackTyres;
     

    float yThrow, xThrow;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveFoward();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveBackward();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
           
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.Space)) acceleration = 0;

         
        
	}

    private void MoveFoward()
    {
        if (acceleration < acceleratingSpeedLimit) acceleration++;
        float position = this.transform.position.x + (acceleration * Time.deltaTime);
        this.transform.position = new Vector3(position, this.transform.position.y, this.transform.position.z);
    }

    private void MoveBackward()
    {
        if (acceleration > reverseSpeedLimit) acceleration--;
        float position = this.transform.position.x + (acceleration * Time.deltaTime);
        this.transform.position = new Vector3(position, this.transform.position.y, this.transform.position.z);
    }
 
    private void MoveLeft()
    {
        
        if ( FrontLeftTyre.transform.rotation.y < (-1 * maxTyreRotation)) return; 
        Quaternion CurrentTyreRotation = FrontLeftTyre.transform.rotation;
        FrontLeftTyre.transform.rotation = new Quaternion(CurrentTyreRotation.x, CurrentTyreRotation.y - (SteeringSensitivity * Time.deltaTime), CurrentTyreRotation.z, CurrentTyreRotation.w);
       
    }

    private void MoveRight()
    {
        if (FrontRightTyre.transform.rotation.y < (-1 * maxTyreRotation)) return;
        Quaternion CurrentTyreRotation = FrontRightTyre.transform.rotation;
        FrontRightTyre.transform.rotation = new Quaternion(CurrentTyreRotation.x, CurrentTyreRotation.y - (SteeringSensitivity * Time.deltaTime), CurrentTyreRotation.z, CurrentTyreRotation.w);


    }


}
