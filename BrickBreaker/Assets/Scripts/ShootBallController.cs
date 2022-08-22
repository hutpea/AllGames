using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBallController : MonoBehaviour
{
    public Transform ballPrefab;

    public float shootDelay;
    public float shootPower;
    public int ballsCount;

    private bool enableMove = true;
    private bool waitShoot = false;

    private void Start()
    {
        Time.timeScale = 0.5f;    
    }

    private void Update()
    {
        if(enableMove == true)
        {
            Move();
        }

        //Click de khoa di di chuyen va vao trang thai Cho de ban
        if (waitShoot == false && Input.GetMouseButtonDown(0))
        {
            enableMove = false;
            waitShoot = true;
            return; //de bao dam lan kiem tra Input tiep theo se dung
        }
        //Neu truoc do da Cho de ban, thi se doi hanh dong CLick chuot de ban luon !
        if (waitShoot == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Click chuot trong khi cho ban !");
                ShootBall();
            }
        }
    }

    private void Move()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.y = -4.42f;
        if(mousePosition.x < -2.25f)
        {
            mousePosition.x = -2.25f;
        }
        if (mousePosition.x > 2.25f)
        {
            mousePosition.x = 2.25f;
        }
        transform.position = mousePosition;
    }

    public void ShootBall()
    {
        StartCoroutine(ShootBallCoroutine());
    }

    private IEnumerator ShootBallCoroutine()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shootDirection = mousePosition - (Vector2)transform.position; //Huong qua bong se dc ban (= dich - dau)

        for (int i = 1; i <= ballsCount; i++)
        {
            Transform ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().AddForce(shootDirection.normalized * shootPower, ForceMode2D.Impulse);
            yield return new WaitForSeconds(shootDelay);
        }
    }
}
