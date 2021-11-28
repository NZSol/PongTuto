using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] players;
    GameObject scorer;
    [SerializeField]
    GameObject ballPrefab;
    public bool timer;
    float timerVal = 0, timerMax = 2;

    [SerializeField]
    Text scoreText = null;

    int P1Score = 0, P2Score = 0;


    void Start()
    {
        scoreText.text = ($"P1 Score: {P1Score} || P2 Score: {P2Score}");
        scorer = players[Random.Range(0, 2)];
        SetBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer)
        {
            timerVal += Time.deltaTime;
            if (timerVal >= timerMax)
            {
                timer = false;
                timerVal -= timerMax;
                SetBall();
            }
        }
    }

    void SetBall()
    {
        BallScript ball = Instantiate(ballPrefab, Vector3.zero, Quaternion.Euler(Vector3.zero)).GetComponent<BallScript>();
        ball.manager = this;
        ball.SetDirection(scorer.transform.position);
        foreach (GameObject player in players)
        {
            player.GetComponent<Paddle>().ball = ball;
        }
    }

    public void GetPos(Vector3 position)
    {
        if (position.x > 0)
        {
            scorer = players[0];
            P1Score++;
        }
        else
        {
            scorer = players[1];
            P2Score++;
        }
        UpdateText();
    }

    void UpdateText()
    {
        scoreText.text = ($"P1 Score: {P1Score} || P2 Score: {P2Score}");
    }
}
