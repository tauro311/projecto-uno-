using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D characterRigidbody;
    private float horizontalInput; 
    public static Animator characterAnimator; 


  

    [SerializeField]private float characterSpeed = 4.5f;
    [SerializeField]private float jumpForce = 10f;

    [SerializeField]private int healthPoints; 
    [SerializeField]private int maxHealthPoints = 5;

    private bool isAttacking; 
    [SerializeField]private Transform attackiHitBox; 
    [ SerializeField]private float attackRadius = 1;



    void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
           characterAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        healthPoints = maxHealthPoints;
        GameManager.instance.SetHealBar(maxHealthPoints);
      //  characterRigidbody.AddForce(Vector2.up * jumpForce);
 

    }
    void Movement()
    {
        if(isAttacking && horizontalInput == 0)
        {
            horizontalInput = 0; 
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
        if(horizontalInput < 0)
        {
            if(!isAttacking)
            {
                transform.rotation = Quaternion.Euler(0,180, 0);
            
            }
            characterAnimator.SetBool("IsRunning", true);

        }
        else if(horizontalInput > 0)
        {
            if(!isAttacking)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            
            }
            characterAnimator.SetBool("IsRunning", true);

        }
        else
        {
            characterAnimator.SetBool("IsRunning", false);
        }
    }

    void Update()
    {
        Movement();

        if(Input.GetButtonDown("Jump") && GroundSensor.isGrounded && !isAttacking)
        {
            characterRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            characterAnimator.SetBool("IsRunning", false);



        }
        if(Input.GetButtonDown("Attack") && GroundSensor.isGrounded && !isAttacking)
        {
           // Attack();
           StratAttack();

        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            GameManager.instance.Pause();
            
        }
        
       
    }
  
    
   /* void Attack()
    {
        StartCoroutine(AttackAnimation());
        characterAnimator.SetTrigger("Attack");             
    }
    IEnumerator AttackAnimation()
    {    
        isAttacking = true; 

        yield return new WaitForSeconds(0.1f);

        Collider2D[] collider = Physics2D.OverlapCircleAll(attackiHitBox.position, attackRadius);

        foreach(Collider2D enemy in collider)
        {
            if(enemy.gameObject.CompareTag("Mimico"))
            {
                //Destroy(enemy.gameObject);
                Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
                enemyRigidbody.AddForce( transform.right + transform.up * 2, ForceMode2D.Impulse);
                
                
            }
        }
        
    
        yield return new WaitForSeconds(0.4f);
        isAttacking = false ; 
    }*/

    void StratAttack()
    {
        isAttacking = true; 
        characterAnimator.SetTrigger("Attack");
    }

    void Attack()
    {
    
        Collider2D[] collider = Physics2D.OverlapCircleAll(attackiHitBox.position, attackRadius);

        foreach(Collider2D enemy in collider)
        {
             if(enemy.gameObject.CompareTag("Mimico"))
             {
                  //Destroy(enemy.gameObject);
                Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
                enemyRigidbody.AddForce( transform.right + transform.up * 2, ForceMode2D.Impulse);
                
                
             }
        }
           
    }

    void EndAttack()
    {
        isAttacking = false;

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        characterRigidbody.velocity = new Vector2(horizontalInput *characterSpeed, characterRigidbody.velocity.y);


    }

    void TakeDamage(int damage)
    {
        healthPoints -= damage; 
        GameManager.instance.UpdateHealBar(healthPoints);

      
        if(healthPoints <= 0)
        {
            Die();
            
        }
        else
        {
            characterAnimator.SetTrigger("IsHurt");
        }

    }
     public void AtHealth(int health)
    {
        healthPoints += health;

        if(healthPoints < maxHealthPoints)
        {
            healthPoints = maxHealthPoints;
        }
        
        GameManager.instance.UpdateHealBar(healthPoints);

    }
    
    void Die()
    {
        characterAnimator.SetBool("IsDead", true);
        Destroy(gameObject, 0.35f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            //characterAnimator.SetTrigger("IsHurt");
            //Destroy(gameObject, 0.3f);
          TakeDamage(1);
 

        }
    }
     void OnDrawGizmos()
     {
        Gizmos.color = Color.red; 
        Gizmos.DrawWireSphere(attackiHitBox.position,  attackRadius);
     }
}
