using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Collision : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("벽에 닿음!");
            float speed = rb.velocity.magnitude; // 현재 속도 계산
            Debug.Log($"현재 속도: {speed}");
        }
    }
}
