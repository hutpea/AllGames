using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BelowWall : MonoBehaviour
{
    private bool isLose = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(isLose == false)
        {
            if (other.gameObject.tag == "Brick")
            {
                isLose = true;
                Debug.Log("thua");
                SceneManager.LoadScene("Gameplay");
            }
        }
    }
}
