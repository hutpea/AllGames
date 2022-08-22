using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text question;
    public Button buttonA;
    public Button buttonB;
    public Button buttonC;
    public Button buttonD;
    public Text notifyText;
    public Text countdownText;
    private float countdown = 10f;
    private bool enableClickOnButton = true;

    List<Data> allQuestions = new List<Data>();
    Data currentData;
    int currentQuestion = 0;

    // Start is called before the first frame update
    void Awake()
    {
        allQuestions.Add(new Data("Thu do nuoc My?", "A. Cairo", "B. Washington D.C", "C. London", "D.Paris", "B"));
        allQuestions.Add(new Data("Thu do nuoc Anh?", "A. Washington D.C", "B. Cairo", "C. London", "D.Paris", "C"));
        allQuestions.Add(new Data("Thu do nuoc Ai Cap?", "A. Cairo", "B. London", "C. Washington D.C", "D.Paris", "A"));

        buttonA.onClick.AddListener(() => OnClickButtonAnswer("A"));
        buttonB.onClick.AddListener(() => OnClickButtonAnswer("B"));
        buttonC.onClick.AddListener(() => OnClickButtonAnswer("C"));
        buttonD.onClick.AddListener(() => OnClickButtonAnswer("D"));
    }

    private void Start()
    {
        ShowNextQuestion();
    }

    bool enableCountdown = false;

    private void Update()
    {
        if (enableCountdown == true)
        {
            countdown -= Time.deltaTime;
            countdownText.text = Mathf.RoundToInt(countdown).ToString();
            if(countdown <= 0)
            {
                enableCountdown = false;
                notifyText.text = "Run out of time !";
                StartCoroutine(ShowQuestionCoroutine());
            }
        }
    }

    public IEnumerator ShowQuestionCoroutine()
    {
        enableClickOnButton = false;
        yield return new WaitForSeconds(2);
        enableClickOnButton = true;
        ShowNextQuestion();
    }

    public void ShowNextQuestion()
    {
        enableCountdown = true;
        countdown = 10;

        notifyText.text = "";

        currentData = allQuestions[currentQuestion];
        question.text = currentData.question;
        buttonA.transform.GetChild(0).GetComponent<Text>().text = currentData.answerA;
        buttonB.transform.GetChild(0).GetComponent<Text>().text = currentData.answerB;
        buttonC.transform.GetChild(0).GetComponent<Text>().text = currentData.answerC;
        buttonD.transform.GetChild(0).GetComponent<Text>().text = currentData.answerD;
    }

    public void OnClickButtonAnswer(string answer)
    {
        if (!enableClickOnButton)
        {
            return;
        }
        if(answer == currentData.correctAnswer)
        {
            notifyText.text = "You are right !";
            notifyText.color = Color.green;
        }
        else
        {
            notifyText.text = "You are wrong ! Right answer is " + currentData.correctAnswer;
            notifyText.color = Color.red;
        }

        currentQuestion++;
        if (currentQuestion > allQuestions.Count - 1)
        {
            currentQuestion = 0;
        }
        StartCoroutine(ShowQuestionCoroutine());
    }
}

public class Data
{
    public string question;
    public string answerA;
    public string answerB;
    public string answerC;
    public string answerD;
    public string correctAnswer;

    public Data(string question, string answerA, string answerB, string answerC, string answerD, string correctAnswer)
    {
        this.question = question;
        this.answerA = answerA;
        this.answerB = answerB;
        this.answerC = answerC;
        this.answerD = answerD;
        this.correctAnswer = correctAnswer;
    }
}
