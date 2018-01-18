using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour
{
    public float LeftLimit = -30;
    public float RightLimit = 30;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //if the rotation is less than -30 or more than 30 then stop rotating
        //set the rotation to the upper / lower boundary

        //Debug.Log(transform.rotation.y);  //since rotation is in quaternions, it isn't useful
	    //Debug.Log(transform.localEulerAngles.y);
	    var currentRotation = transform.localEulerAngles.y;
	    var convertedAngle = ConvertDegreesToPosNeg(currentRotation);
	    if (convertedAngle < LeftLimit)
	    {
	        var circleAngle = ConvertPosNegToCircle(LeftLimit);
	        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, circleAngle, transform.localEulerAngles.z);
	    }

	    if (convertedAngle > RightLimit)
	    {
	        var circleAngle = ConvertPosNegToCircle(RightLimit);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, circleAngle, transform.localEulerAngles.z);
        }

	    transform.Rotate(0, x, 0);
    }

    private float ConvertDegreesToPosNeg(float degrees)
    {
        if (degrees >= 0 && degrees <= 180)
        {
            return degrees;
        }
        else
        {
            return (degrees - 360);
        }

    }

    private float ConvertPosNegToCircle(float degrees)
    {
        if (degrees >= -180 && degrees < 0)
        {
            return Mathf.Abs(degrees + 360);
        }
        else
        {
            return degrees;
        }
    }
}
