using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera PlayerCam;
    public ParticleSystem Lightning;
    public Transform PlayerTransform;
    private Vector3 _cameraOffset;

    public int PScore;

    public bool isGrounded;
    public bool speedBoost;
    public bool RoatateAroundPlayer = true;
    public bool LookAtPlayer = false;

    public float RotationSpeed = 5.0f;
    public float RotateSpeed;
    public float JumpHight;
    public float SmoothFactor = 0.5f;

    private float Speed;
    private float w_speed;
    private float r_speed;
    
    private int KeyCounter = 0;

    Animator anim;
    Rigidbody rb;
    CapsuleCollider col_size;
    
    // Use this for initialization
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col_size = GetComponent<CapsuleCollider>();
        PScore = 0;
        w_speed = 0.05f;
        r_speed = 2.5f;
        
        isGrounded = true;
        PlayerCam.enabled = true;
        speedBoost = false;
        Lightning.Stop();
    }

    void Update()
    {
        Movement();
        GetInput();
        Jumping();
        SpeedBoost();

        var z = Input.GetAxis("Vertical") * Speed;
        var y = Input.GetAxis("Horizontal") * RotateSpeed;

        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);
        if (speedBoost == true)
        {
            Lightning.Play();
        }
    }

    void Movement()
    {
        if (isGrounded == true)
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.E) ||
                Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.W))
            {
                Speed = w_speed;
                anim.SetBool("Forward", false);
                anim.SetBool("Backwards", false);
                anim.SetBool("Idle", false);
                anim.SetBool("FStrafeRight", true);
                anim.SetBool("FStrafeLeft", false);
                anim.SetBool("StrafeRight", false);
                anim.SetBool("StrafeLeft", false);
                anim.SetBool("Sprint", false);
                anim.SetBool("TurnRight", false);
                anim.SetBool("TurnLeft", false);
            }
            //strafe forwards left
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Q) ||
                Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.W))
            {
                Speed = w_speed;
                anim.SetBool("Forward", false);
                anim.SetBool("Backwards", false);
                anim.SetBool("Idle", false);
                anim.SetBool("FStrafeRight", false);
                anim.SetBool("FStrafeLeft", true);
                anim.SetBool("StrafeRight", false);
                anim.SetBool("StrafeLeft", false);
                anim.SetBool("Sprint", false);
                anim.SetBool("TurnRight", false);
                anim.SetBool("TurnLeft", false);
            }
            //Walking forwards
            else if (Input.GetKey(KeyCode.W))
            {
                Speed = w_speed;
                anim.SetBool("Forward", true);
                anim.SetBool("Backwards", false);
                anim.SetBool("Idle", false);
                anim.SetBool("FStrafeRight", false);
                anim.SetBool("FStrafeLeft", false);
                anim.SetBool("StrafeRight", false);
                anim.SetBool("StrafeLeft", false);
                anim.SetBool("Sprint", false);
                anim.SetBool("TurnRight", false);
                anim.SetBool("TurnLeft", false);
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                Speed = r_speed;
                anim.SetBool("Forward", false);
                anim.SetBool("Backwards", false);
                anim.SetBool("Idle", false);
                anim.SetBool("FStrafeRight", false);
                anim.SetBool("FStrafeLeft", false);
                anim.SetBool("StrafeRight", false);
                anim.SetBool("StrafeLeft", false);
                anim.SetBool("Sprint", true);
                anim.SetBool("TurnRight", false);
                anim.SetBool("TurnLeft", false);
            }
            // walking backwards
            else if (Input.GetKey(KeyCode.S))
            {
                Speed = w_speed;
                anim.SetBool("Forward", false);
                anim.SetBool("Backwards", true);
                anim.SetBool("Idle", false);
                anim.SetBool("FStrafeRight", false);
                anim.SetBool("FStrafeLeft", false);
                anim.SetBool("StrafeRight", false);
                anim.SetBool("StrafeLeft", false);
                anim.SetBool("Sprint", false);
                anim.SetBool("TurnRight", false);
                anim.SetBool("TurnLeft", false);
            }
            //strafe right
            else if (Input.GetKey(KeyCode.E))
            {
                Speed = w_speed;
                anim.SetBool("Forward", false);
                anim.SetBool("Backwards", false);
                anim.SetBool("Idle", false);
                anim.SetBool("FStrafeRight", false);
                anim.SetBool("FStrafeLeft", false);
                anim.SetBool("StrafeRight", true);
                anim.SetBool("StrafeLeft", false);
                anim.SetBool("Sprint", false);
                anim.SetBool("TurnRight", false);
                anim.SetBool("TurnLeft", false);
            }
            //strafe left
            else if (Input.GetKey(KeyCode.Q))
            {
                Speed = w_speed;
                anim.SetBool("Forward", false);
                anim.SetBool("Backwards", false);
                anim.SetBool("Idle", false);
                anim.SetBool("FStrafeRight", false);
                anim.SetBool("FStrafeLeft", false);
                anim.SetBool("StrafeRight", false);
                anim.SetBool("StrafeLeft", true);
                anim.SetBool("Sprint", false);
                anim.SetBool("TurnRight", false);
                anim.SetBool("TurnLeft", false);
            }
            //Strafe forwards right

            else if (Input.GetKey(KeyCode.D))
            {
                Speed = w_speed;
                anim.SetBool("Forward", false);
                anim.SetBool("Backwards", false);
                anim.SetBool("Idle", false);
                anim.SetBool("FStrafeRight", false);
                anim.SetBool("FStrafeLeft", false);
                anim.SetBool("StrafeRight", false);
                anim.SetBool("StrafeLeft", false);
                anim.SetBool("Sprint", false);
                anim.SetBool("TurnRight", true);
                anim.SetBool("TurnLeft", false);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Speed = w_speed;
                anim.SetBool("Forward", false);
                anim.SetBool("Backwards", false);
                anim.SetBool("Idle", false);
                anim.SetBool("FStrafeRight", false);
                anim.SetBool("FStrafeLeft", false);
                anim.SetBool("StrafeRight", false);
                anim.SetBool("StrafeLeft", false);
                anim.SetBool("Sprint", false);
                anim.SetBool("TurnRight", false);
                anim.SetBool("TurnLeft", true);
            }
            //idle
            else
            {
                anim.SetBool("Forward", false);
                anim.SetBool("Backwards", false);
                anim.SetBool("Idle", true);
                anim.SetBool("FStrafeRight", false);
                anim.SetBool("FStrafeLeft", false);
                anim.SetBool("StrafeRight", false);
                anim.SetBool("StrafeLeft", false);
                anim.SetBool("Sprint", false);
                anim.SetBool("TurnRight", false);
                anim.SetBool("TurnLeft", false);
            }
        }
        if (!isGrounded)
        {
            anim.SetTrigger("Falling");
        }
    }
        

    void Jumping()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(0, JumpHight, 0);
            anim.SetTrigger("isJumping");
            StartCoroutine(JumpComplete());
            isGrounded = false;
        }
        if (isGrounded == false)
        {
            anim.SetTrigger("Falling");
        }
        else if (isGrounded == true)
        {
            anim.SetBool("Falling", false);
            //anim.SetBool("Idle", true);
        }
    }

    void GetInput()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            KeyCounter++;
        }
        if (KeyCounter == 1)
        {
            Attack2();
            KeyCounter++;
        }
        if(KeyCounter == 2)
        {
            Attack3();
        }
    }

    void Attack()
    {
        anim.SetTrigger("isAttacking");
        StartCoroutine(AttackRoutine());
    }
    void Attack2()
    {
        anim.SetTrigger("isAttacking2");
        StartCoroutine(AttackRoutine());
    }
    void Attack3()
    {
        anim.SetTrigger("isAttacking3");
        StartCoroutine(AttackRoutine());
        if (KeyCounter < 3)
           {
             KeyCounter = 0;
           }
    }
    IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(1.5f);
    }
    IEnumerator JumpComplete()
    {
        yield return new WaitForSeconds(2.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
    void SpeedBoost()
    {
        if (speedBoost == true)
        {
            Speed = 1.0f;
            StartCoroutine(BoostTime());
        }
    }
    IEnumerator BoostTime()
    {
        yield return new WaitForSeconds(5.0f);
        speedBoost = false;
    }
}
