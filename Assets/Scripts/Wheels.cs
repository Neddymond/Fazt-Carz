
using UnityEngine;

class Wheels : MonoBehaviour
{
    public GameObject FrontLeftTyres;
    /*public GameObject FrontRightTyre;
    public GameObject BackleftTyre;
    public GameObject BackRightTyre;*/

    public WheelCollider FrontLeftTyre;
    public WheelCollider FrontRightTyre;
    public WheelCollider BackLeftTyre;
    public WheelCollider BackRightTyre;
    
    public float acceleration;
   
    public float clampTyreRotationLeft;
    public float clampTyreRotationRight; 


    //Specs
    [Header("Specs")]
    public float maxTyreRotation;
    public float SteeringSensitivity; 

    



    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {

           TurnFrontTiresLeft();
            /*flWheel.localEulerAngles = new Vector3(flWheel.localEulerAngles.x, flWheelCollider.steerAngle - flWheel.localEulerAngles.z, flWheel.localEulerAngles.z);
            frWheel.localEulerAngles = new Vector3(frWheel.localEulerAngles.x, frWheelCollider.steerAngle - frWheel.localEulerAngles.z, frWheel.localEulerAngles.z);

            flWheel.Rotate(flWheelCollider.rpm / 60 * 360 * Time.deltaTime, 0, 0);
            frWheel.Rotate(frWheelCollider.rpm / 60 * 360 * Time.deltaTime, 0, 0);
            rlWheel.Rotate(rlWheelCollider.rpm / 60 * 360 * Time.deltaTime, 0, 0);
            rrWheel.Rotate(rrWheelCollider.rpm / 60 * 360 * Time.deltaTime, 0, 0);*/

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {

            TurnFrontTiresRight();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            SpinFrontLeftTyreForward();
            SpinFrontRightTyreForward();
            SpinBackLeftTyreForward();
            SpinBackRightTyrForward();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            SpinFrontLeftTyreBackward();
            /*SpinFrontRightTyreBackward();
            SpinBackLeftTyreBackward();
            SpinBackRightTyreBackward();*/
        }
    }

    private void TurnFrontTiresLeft()
    {
        
        Quaternion CurrentTyreRotation = FrontLeftTyre.transform.rotation;
        float yRotation = CurrentTyreRotation.y - (SteeringSensitivity * Time.deltaTime);
        if (yRotation <= clampTyreRotationLeft) return;
     
        FrontLeftTyre.transform.rotation = new Quaternion(CurrentTyreRotation.x, yRotation, CurrentTyreRotation.z, CurrentTyreRotation.w);
        FrontRightTyre.transform.rotation = new Quaternion(CurrentTyreRotation.x, CurrentTyreRotation.y - (SteeringSensitivity * Time.deltaTime), CurrentTyreRotation.z, CurrentTyreRotation.w);
    }

    private void TurnFrontTiresRight()
    {
        Quaternion CurrentTyreRotation = FrontRightTyre.transform.rotation;
        float yRotation = CurrentTyreRotation.y + (SteeringSensitivity * Time.deltaTime);
        if (yRotation >= clampTyreRotationRight) return;
        FrontRightTyre.transform.rotation = new Quaternion(CurrentTyreRotation.x, yRotation, CurrentTyreRotation.z, CurrentTyreRotation.w);
        FrontLeftTyre.transform.rotation = new Quaternion(CurrentTyreRotation.x, CurrentTyreRotation.y + (SteeringSensitivity * Time.deltaTime), CurrentTyreRotation.z, CurrentTyreRotation.w);
    }

    private void SpinFrontLeftTyreForward()
    {
        FrontLeftTyre.transform.Rotate (0, 0, 60 * 360 * Time.deltaTime);
    }
    private void SpinFrontRightTyreForward()
    {
        FrontRightTyre.transform.Rotate(0, 0, 60 * 360 * Time.deltaTime);
    }
    private void SpinBackLeftTyreForward()
    {
        BackLeftTyre.transform.Rotate(0, 0, 60 * 360 * Time.deltaTime);
    }
    private void SpinBackRightTyrForward()
    {
        BackRightTyre.transform.Rotate(0, 0, 60 *360 * Time.deltaTime);
    }

    private void SpinFrontLeftTyreBackward()
    {
        FrontLeftTyre.transform.Rotate(0, 0, -(60 * 360 * Time.deltaTime));
    }
    private void SpinFrontRightyreBackward()
    {
        FrontLeftTyre.transform.Rotate(0, 0, -(60 * 360 * Time.deltaTime));
    }
    private void SpinBackLeftTyreBackward()
    {
        BackLeftTyre.transform.Rotate(0, 0, -(60 * 360 * Time.deltaTime));
    }
    private void SpinBackRightTyreBackward()
    {
        BackRightTyre.transform.Rotate(0, 0, -(60 * 360 * Time.deltaTime));
    }
}

