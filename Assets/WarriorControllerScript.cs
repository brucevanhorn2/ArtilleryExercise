using UnityEngine;
using System.Collections;
[RequireComponent(typeof (HitPointSystem))]
//TODO:  add the remainder of the required compontents!
public class WarriorControllerScript : MonoBehaviour {
    private Animator _animator;
    private NavMeshAgent _agent;
    public GameObject ShotPrefab;
    public GameObject EnemyTarget;
    public float WeaponsRange = 20.0f;
    public Transform ShotSpawn;
    public float ShotSpeed=60;
    public GameObject SmokePrefab;
    public GameObject ExplosionPrefab;

    private float _nextFireTime = 0;
    private float _fireDelay = 5;
    private GameObject _turret;
    private HitPointSystem _hitPoints;
    private bool _isDead = false;

	// Use this for initialization
	void Start ()
	{
	    _hitPoints = GetComponent<HitPointSystem>();
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();

        _agent.SetDestination(EnemyTarget.transform.position);
        _animator.SetFloat("Speed", 1.0f);

	    _turret = GameObject.FindGameObjectWithTag("Player");
	}

    void Update()
    {
        if (_hitPoints.IsDead && !_isDead)
        {
            _isDead = true;
            Die();
        }
    }
	
	// Update is called once per frame
	void LateUpdate ()
	{
	    Vector3 forward = ShotSpawn.TransformDirection(Vector3.forward)*10;
	    Debug.DrawRay(ShotSpawn.position, forward, Color.green);

	    var distanceToTarget = Vector3.Distance(transform.position, EnemyTarget.transform.position);
	    if (distanceToTarget < WeaponsRange && Time.time > _nextFireTime && !_hitPoints.IsDead)
	    {

	        transform.LookAt(_turret.transform);
	        _agent.Stop();
            _animator.SetFloat("Speed", 0.0f);
            _nextFireTime = Time.time + _fireDelay;
	        Debug.Log("target is in range");
	        _animator.SetTrigger("IsFiring");
	        var shot = Instantiate(ShotPrefab, ShotSpawn.position, Quaternion.identity) as GameObject;
	        shot.GetComponent<Rigidbody>().velocity = ShotSpawn.forward * ShotSpeed;
	    }
	}

    private void Die()
    {
        _agent.Stop();
        _animator.SetFloat("Speed", 0.0f);
        _animator.SetBool("IsDead", true);

        var explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity) as GameObject;
        Instantiate(SmokePrefab, transform.position, Quaternion.identity);
        //TODO:  destroy the object

        Destroy(explosion, 5.0f);
        Destroy(gameObject, 10.0f);
    }
}
