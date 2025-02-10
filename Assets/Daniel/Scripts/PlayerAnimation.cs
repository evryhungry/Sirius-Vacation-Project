using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;
    private Animator playeranimator;
    public bool isCrouched = false;
    [SerializeField] bool isHurt = false;
    [SerializeField] bool isDamaged = false;
    float moveX = 0f;
    
    void Awake()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();  
        playeranimator = GetComponent<Animator>();
    }

    void Update()
    {
        //좌우 반전
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
        
            playerSpriteRenderer.flipX = false;
            moveX = +1f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
            playerSpriteRenderer.flipX = true;     
        }

        //점프 전 움츠리기 
        if (Input.GetKey(KeyCode.Space))
        {
            isCrouched = true;
            playeranimator.SetBool("Crouched", isCrouched);
        }
        else if (Input.GetKeyUp(KeyCode.Space)) //점프
        {
            isCrouched = false;
            playeranimator.SetBool("Crouched", isCrouched);
        }

        Vector3 moveDir = new Vector3(moveX, 0).normalized;
        transform.position += moveDir * 1 * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Triggered Hurt");
            isHurt = true;
            playeranimator.SetBool("Hurted", isHurt);
        }

        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Triggered Ground");
            CastDeath();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("UnTriggered");
            isHurt = false;
            playeranimator.SetBool("Hurted", isHurt);
        }
    }

    public void CastDeath()
    {
        playeranimator.SetTrigger("DeathCast");
    }
}
