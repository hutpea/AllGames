using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 lastVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        if(transform.position.y < -4.42f)
        {
            GameObject.FindObjectOfType<WaveController>().CheckThereIsAnyBallsLeft();
            Destroy(gameObject);
        }
        lastVelocity = rb.velocity; //luu lai van toc moi lan Update()
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Va cham vien gach -mau
        if(other.gameObject.tag == "Brick")
        {
            other.gameObject.GetComponent<Brick>().DecreaseNumber(1);
        }
        //Xu ly dap phan lai
        if(other.gameObject.tag == "Brick" || other.gameObject.tag == "Wall")
        {
            float speed = lastVelocity.magnitude; //do dai cua vector van toc
            Vector2 normal = other.contacts[0].normal; //contacts[0] la diem dau tien, normal la vector normal cua diem va cham
            Vector2 newVelocity = Vector2.Reflect(lastVelocity.normalized, normal); //tinh vector phan luc
            rb.velocity = newVelocity * Mathf.Max(speed, 0f); //Max de bao dam gia tri khong am
        }
    }
}
