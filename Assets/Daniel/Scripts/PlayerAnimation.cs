using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;
    private Animator playeranimator;
    public bool isCrouched = false;
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
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
        
            playerSpriteRenderer.flipX = true;     
        }

        //점프 전 움츠리기 
        if (Input.GetKey(KeyCode.Space))
        {
            isCrouched = true;
            playeranimator.SetBool("Crouched", isCrouched);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isCrouched = false;
            playeranimator.SetBool("Crouched", isCrouched);
        }
    }
}
