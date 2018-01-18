using UnityEngine;
using System.Collections;

public class GenericArtillery : MonoBehaviour {
    public Transform ShotSpawn;
    public float ShotSpeed = 60;
    public GameObject ShotPrefab;
    private float _nextFireTime = 0;
    private float _fireDelay = 5;
    // Use this for initialization
    void Start () {
       
    }

    // Update is called once per frame
    void Update () {
        Vector3 forward = ShotSpawn.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(ShotSpawn.position, forward, Color.red);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > _nextFireTime)
            {
                _nextFireTime = Time.time + _fireDelay;
                var shot = Instantiate(ShotPrefab, ShotSpawn.position, Quaternion.identity) as GameObject;
                shot.GetComponent<Rigidbody>().velocity = ShotSpawn.forward*ShotSpeed;
            }
        }
        
    }
}
