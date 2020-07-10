using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public GameObject cam;

    public Rigidbody rb;

    public float moveSpeed = 5;

    public float moveX;
    public float moveZ;
    public Vector3 moveDir;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

        Vector3 camForward = cam.transform.forward;
        Vector3 camRight = cam.transform.right;
        camForward = new Vector3(camForward.x, 0, camForward.z);

        moveDir = (camForward * moveZ) + (camRight * moveX);
        moveDir.Normalize();

        //MovePlayer(); 
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void HandleInput()
    {
        moveX = Input.GetAxisRaw("Horizontal"); //Forward/back
        moveZ = Input.GetAxisRaw("Vertical"); //Left/Right
        //moveDir = new Vector3(moveX, 0, moveZ);
        //moveDir.Normalize();


    }

    void MovePlayer()
    {
        //transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        rb.velocity = moveDir * moveSpeed;
    }
}
