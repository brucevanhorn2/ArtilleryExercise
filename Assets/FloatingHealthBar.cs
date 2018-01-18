using UnityEngine;
using System.Collections;

public class FloatingHealthBar : MonoBehaviour
{
    private Transform _cameraTarget;
	// Use this for initialization
	void Start ()
	{
	    _cameraTarget = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
        //transform.LookAt(_cameraTarget);
        transform.rotation = Camera.main.transform.rotation;
    }
}
