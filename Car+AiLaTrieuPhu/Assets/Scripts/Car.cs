using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip beepSound;

    public GameObject goodPurple;
    public GameObject goodBlue;
    public GameObject customerPurple;
    public GameObject customerBlue;

    public Sprite yellowCar;
    public Sprite purpleCar;
    public Sprite blueCar;

    public int currentNumber;

    public float moveSpeed;
    public float steerSpeed;
    public bool isHoldGood;

    private void Awake()
    {
        currentNumber = 0;
        isHoldGood = false;
    }

    //Xu ly logic
    private void Update()
    {
        Debug.Log(transform.up);
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(- transform.up * moveSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, steerSpeed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, - steerSpeed * Time.deltaTime));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Good")
        {
            audioSource.clip = beepSound;
            audioSource.Play();

            if(currentNumber == 0)
            {
                //Chuyen xe sang mau vang
                GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else if(currentNumber == 1)
            {
                GetComponent<SpriteRenderer>().color = Color.magenta;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.blue;
            }
            isHoldGood = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Customer")
        {
            if(isHoldGood == true)
            {
                currentNumber++;
                if(currentNumber == 1)
                {
                    //hien goi hang/khach hang tim
                    goodPurple.SetActive(true);
                    customerPurple.SetActive(true);
                }
                else if(currentNumber == 2)
                {
                    //hien goi hang/khach hang xanh
                    goodBlue.SetActive(true);
                    customerBlue.SetActive(true);
                }
                else
                {
                    Debug.Log("WIN!");
                    SceneManager.LoadScene("SampleScene");
                }
                Destroy(other.gameObject);
            }
        }
    }
}
