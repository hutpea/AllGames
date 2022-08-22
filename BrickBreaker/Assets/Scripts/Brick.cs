using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public TextMesh textMesh;
    public int numberToDestroy; //giong maxHP (mau toi da)
    private int currentNumber; //giong currentHP (mau hien tai)

    public void Init()
    {
        currentNumber = numberToDestroy;
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
    }

    private void Update()
    {
        textMesh.text = currentNumber.ToString();
    }

    public void DecreaseNumber(int amount)
    {
        currentNumber -= amount;
        if(currentNumber <= 0)
        {
            currentNumber = 0;
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
