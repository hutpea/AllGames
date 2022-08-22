using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaveController : MonoBehaviour
{
    public Transform squareBrick;
    public Transform triangleBrick;

    private bool isEndTurn = false;

    void Start()
    {
        CreateABrickRow(new List<int>() { 1, 3, 10, 5 });
    }

    private void Update()
    {
    }

    public void CreateABrickRow(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            //toan tu ba ngoi
            int randomNumber = Random.Range(0, 100);
            Transform brick = Instantiate((randomNumber < 50) ? squareBrick : triangleBrick, new Vector3(-2.1f + 0.75f * i, -3.5f, 0), Quaternion.identity);
            brick.GetComponent<Brick>().numberToDestroy = list[i];
            brick.GetComponent<Brick>().Init();
        }
    }

    public void CheckThereIsAnyBallsLeft() //true: neu con //false: k con
    {
        StartCoroutine(DelayCheck());
    }

    private IEnumerator DelayCheck()
    {
        yield return new WaitForSeconds(1f);
        if (isEndTurn == false)
        {
            var balls = GameObject.FindGameObjectsWithTag("Ball");
            if (balls.Length == 0) //tat ca qua bong deu da roi xuong
            {
                Debug.Log("End turn");
                isEndTurn = true;
                AllBricksGoDown();
            }
            else
            {

            }
        }
    }

    private void AllBricksGoDown()
    {
        GameObject[] allBricks = GameObject.FindGameObjectsWithTag("Brick"); //tim tat ca cac object co tag = "Brick"
        if (allBricks.Length == 0)
        {
            Debug.Log("thang");
            return;
        }
        for (int i = 0; i < allBricks.Length; i++)
        {
            int tempI = i;
            GameObject[] tempAllBricks = new GameObject[allBricks.Length];
            for (int k = 0; k < allBricks.Length; k++)
            {
                tempAllBricks[k] = allBricks[k];
            }
            allBricks[tempI].transform.DOMove(allBricks[i].transform.position - new Vector3(0, 0.75f, 0), 1.25f).OnComplete(
                () =>
                {
                    Debug.Log("Di chuyen xong");
                    if (tempI == tempAllBricks.Length - 1)
                    {
                            //ham viet trong day se dc goi khi DOMove hoan thanh quang duong
                        List<int> brickList = new List<int>();

                        int brickCount = Random.Range(1, 7);//so luong gach trong 1 hang
                        Debug.Log("brickCount:" + brickCount);
                        for (int j = 1; j <= brickCount; j++)
                        {
                            brickList.Add(Random.Range(1, 10)); //ngau nhien mau cua vien gach
                        }
                        CreateABrickRow(brickList);
                        isEndTurn = false; //reset de co the check tiep
                    }

                }
            );
        }
    }
}
