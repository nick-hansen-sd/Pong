using UnityEngine;
using TMPro;
using System;

public class BallController : MonoBehaviour
{
    
    public float speed = 0f;
    private Rigidbody rb;
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    private int leftScore;
    private int rightScore;
    private float defaultSpeed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftScore = 0;
        rightScore = 0;
        defaultSpeed = speed;
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.right * -speed;

    }

    void FixedUpdate()
    {
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }

    void SetLeftScoreText()
    {
        leftScoreText.text = "Score: " + leftScore.ToString();
    }

    void SetRightScoreText()
    {
        rightScoreText.text = "Score: " + rightScore.ToString();
    }

    void ResetScore()
    {
        leftScore = 0;
        SetLeftScoreText();
        rightScore = 0;
        SetRightScoreText();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            speed = speed * 1.1f;
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            if (transform.position.x < 0)
            {
                rightScore++;
                SetRightScoreText();
                Debug.Log("Right scored! (" + leftScore.ToString() + ":" + rightScore.ToString());
            } else
            {
                leftScore++;
                SetLeftScoreText();
                Debug.Log("Left scored! (" + leftScore.ToString() + ":" + rightScore.ToString());
            }

            if (leftScore >= 11)
            {
                Debug.Log("Game Over, left paddle wins!");
                ResetScore();
            } else if (rightScore >= 11)
            {
                Debug.Log("Game Over, right paddle wins!");
                ResetScore();
            }

            transform.position = new Vector3(0f, 0.26f, 0f);
            speed = defaultSpeed;

        }
    }

}
