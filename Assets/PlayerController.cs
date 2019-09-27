using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isGrounded = false;
    
    // Gravity Scale editable on the inspector
    // providing a gravity scale per object
 
    public float gravityScale = 1.0f;
 
    // Global Gravity doesn't appear in the inspector. Modify it here in the code
    // (or via scripting) to define a different default gravity for all objects.
 
    public static float globalGravity = -9.81f;
 
    Rigidbody m_rb;
    
    // Character Joystick Movement Variable
    private Transform m_Cam;
    private Vector3 m_CamForward;
    private Vector3 m_Move;
    private float movement_speed = 10f;
    Quaternion targetRotation;

    public bool m_Jump;
    public float HInput;
    public float VInput;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(m_rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGrounded && Input.GetKey(KeyCode.Space))
        {
            gravityScale = 0.00001f;
            Debug.Log(m_rb.velocity.y);
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");
            this.transform.Translate(h * 10, 0, v * 10);
        }
        else if (!isGrounded)
        {
            gravityScale = 1f;
        }

        if(!isGrounded && m_Jump == true){
            Debug.Log("masuk");
            isGrounded = true;
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 400f);
        }
    
    }
    void OnEnable ()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.useGravity = false;
    }
 
    void FixedUpdate ()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        m_rb.AddForce(gravity, ForceMode.Acceleration);

        // Character Movement
        if(m_Cam != null){
            // Calculate camera realative direction to move:
            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = VInput * m_CamForward + HInput * m_Cam.right;
        }
        else{
            //we use world-relative directions in the case of no main camera
            m_Move = VInput * Vector3.forward + HInput * Vector3.right;
        }

        Vector3 targetDirection = new Vector3(HInput, 0f, VInput);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        targetDirection.y = 0.0f;
        if(HInput != 0f || VInput != 0f){
            targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        }
        this.transform.rotation = targetRotation;
        this.transform.position += Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up) * VInput * Time.deltaTime * movement_speed;
        this.transform.position += Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up) * HInput * Time.deltaTime * movement_speed;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Cube"){
            isGrounded = false;
        }
    }
}
