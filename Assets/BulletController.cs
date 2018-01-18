using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    public int Damage = 10;
	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        var thingThatWasHit = other.gameObject;
        if (thingThatWasHit.tag == "Player" || thingThatWasHit.tag == "Enemy")
        {
            Debug.Log(gameObject.name + " hit the "+ thingThatWasHit.name + "!  I hope it hurt!");
            var otherGuysHP = thingThatWasHit.GetComponent<HitPointSystem>();
            otherGuysHP.TakeDamage(Damage);
        }

        Destroy(this.gameObject, 0.5f);
    }
    void OnCollisionEnter(Collision other)
    {
        
    }
}
