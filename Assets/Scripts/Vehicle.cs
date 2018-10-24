using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vehicle : MonoBehaviour
{
    public float acceleration;
    public float acceleratingSpeedLimit;
    public float reverseSpeedLimit;
    public float rotationSpeed;

    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip EngineAcceleration;

    AudioSource audioSource;

   


  
   
        //Tyres
    public GameObject FrontLeftTyre;
    public GameObject FrontRightTyre;
    public GameObject BackTyres;


    float yThrow, xThrow;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            AccelerateEngineSound();
            MoveFoward();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveBackward();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Move Left
            
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
          
        }

        if (Input.GetKey(KeyCode.Space))
        {
            StartEngine();
            acceleration = 0;
        }


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

   /* private void MoveLeft()
    {
        //float position = transform.position.y + (rotationSpeed * Time.deltaTime);
         Quaternion moveCarLeft = this.transform.rotation;
        this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.forward.y + (rotationSpeed * Time.deltaTime), this.transform.rotation.z, this.transform.rotation.w);
    }*/

    private void StartEngine()
    {
        if (!audioSource.isPlaying)
        {
            //On Idle State
            audioSource.PlayOneShot(mainEngine);
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void AccelerateEngineSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(EngineAcceleration);
        }
        else
        {
            audioSource.Stop();
        }
    }


}
