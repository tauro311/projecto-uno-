using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    private Rigidbody2D characterRigidbody;
    private float horizintalInput; 
  

    [SerializeField]private float characterSpeed = 4.5f;
    [SerializeField]private float jumpForce = 10f;

    

    void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
          
    }

    // Start is called before the first frame update
    void Start()
    {
      //  characterRigidbody.AddForce(Vector2.up * jumpForce);
 

    }
    void Update()
    {
        horizintalInput = Input.GetAxis("Horizontal");

        if(horizintalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if(horizintalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if(Input.GetButtonDown("Jump") && GroundSensor.isGrounded)
        {
            characterRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);



        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        characterRigidbody.velocity = new Vector2(horizintalInput *characterSpeed, characterRigidbody.velocity.y);


    }
}
