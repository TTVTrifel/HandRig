using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed;
    public float actSpeed;
    public float accel;
    public float drag;
    public float rotationSpeed;
    public float airDrag;
    Rigidbody rb;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {  
        actSpeed = rb.velocity.magnitude;

        direction();
        Move();
    }


    void Move()
    {
        /*
        bool grounded = (Physics.Raycast(transform.position, Vector3.down + new Vector3(0,1,0), 3f, LayerMask.NameToLayer("Ground")));
        if (!grounded)
        {
            rb.drag = drag;
            print("no ground");
        }
        */

        if(Input.GetKey(KeyCode.W))
        {
            if (rb.velocity.magnitude < maxSpeed)
            {
                rb.AddForce(transform.forward, ForceMode.Impulse);
            }
            else
            {
                rb.velocity = Vector3.forward * maxSpeed;
            }
        }
        
    }


    void direction()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0,100* Time.deltaTime,0) * transform.rotation;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, -100 * Time.deltaTime, 0) * transform.rotation;
        }
    }
}
