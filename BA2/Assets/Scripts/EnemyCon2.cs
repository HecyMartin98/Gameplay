using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCon2 : MonoBehaviour {

    public float moveForce = 0f;
    public float maxDistFromWall;
    public float lookRadius = 15f;
    public float jumpSpeed;

    public Vector3 moveDir;
    public LayerMask whatIsWall;
    
    public int hP = 3;

    private bool grounded = false;

    GameObject enemyPrefab;
    private float knockBackForce = 100000f;
    private float attackRadius = 3f;
    private Rigidbody rbody;

    Transform player;

	// Use this for initialization
	void Start ()
    {
        player = Manager.instance.player.transform;
        rbody = GetComponent<Rigidbody>();
        //moveDir = ChooseDirection();
        //transform.rotation = Quaternion.LookRotation(moveDir);
        
        if( hP == 3)
        {
            enemyPrefab = GameObject.Find("enemyPrefab2");
        }
        if (hP == 2)
        {
            enemyPrefab = GameObject.Find("enemyPrefab3");
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(KnockBackRoutine());
        }
    }

    // Update is called once per frame
    void Update ()
    {
        //rbody.velocity = moveDir * moveForce;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= lookRadius)
        {
            FaceTarget();
            MoveToTarget();
        }
        if (distance <= attackRadius)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (hP == 3)
                {
                    GameObject clone1 = (GameObject)Instantiate(enemyPrefab);
                    GameObject clone2 = (GameObject)Instantiate(enemyPrefab);

                    EnemyCon2 cs1 = clone1.GetComponent<EnemyCon2>();
                    EnemyCon2 cs2 = clone1.GetComponent<EnemyCon2>();

                    clone1.transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z - 1.5f);
                    clone2.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z + 1.5f);

                    cs1.hP = 1;
                    cs2.hP = 1;

                    Destroy(this.gameObject);
                }

                if (hP == 2)
                {
                    GameObject clone1 = (GameObject)Instantiate(enemyPrefab);
                    GameObject clone2 = (GameObject)Instantiate(enemyPrefab);
                    GameObject clone3 = (GameObject)Instantiate(enemyPrefab);

                    EnemyCon2 cs1 = clone1.GetComponent<EnemyCon2>();
                    EnemyCon2 cs2 = clone1.GetComponent<EnemyCon2>();
                    EnemyCon2 cs3 = clone1.GetComponent<EnemyCon2>();

                    clone1.transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z - 1.5f);
                    clone2.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z + 1.5f);
                    clone3.transform.position = transform.position;

                    cs1.hP = 1;
                    cs2.hP = 1;
                    cs3.hP = 1;

                    Destroy(this.gameObject);
                }
                if (hP == 1)
                {
                    Destroy(this.gameObject);
                }
            }
        }
        //else if (distance >= lookRadius)
        //{
        //    Patrol();
        //}
       
	}

    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    //void Patrol()
    //{
    //     if (Physics.Raycast(transform.position, transform.forward, maxDistFromWall, whatIsWall))
    //            {
    //                moveDir = ChooseDirection();
    //                transform.rotation = Quaternion.LookRotation(moveDir);
    //            }
    //}

    //Vector3 ChooseDirection()
    //{
    //    System.Random ran = new System.Random();
    //    int i = ran.Next(0, 3);
    //    Vector3 temp = new Vector3();

    //    if (i == 0)
    //    {
    //        temp = transform.forward;
    //    }
    //    else if (i == 1)
    //    {
    //        temp = -transform.right;
    //    }
    //    else if (i == 2)
    //    {
    //        temp = transform.forward;
    //    }
    //    else if (i == 3)
    //    {
    //        temp = -transform.right;
    //    }
    //    return temp;
    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    void MoveToTarget()
    {

        if (grounded)
        {
            rbody.AddForce(transform.up * jumpSpeed);
            grounded = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime);
    }

    IEnumerator KnockBackRoutine()
    {
        Vector3 dir = (transform.position - player.position);
        rbody.AddForce(dir * knockBackForce);
        yield return null;
    }

}
