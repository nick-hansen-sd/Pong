using UnityEngine;
using TMPro;
using System;
using UnityEngine.AI;

public class BallController : MonoBehaviour
{
    
    public float speed = 0f;
    public float maxSpeed = 0f;
    private Rigidbody rb;
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    private int leftScore;
    private int rightScore;
    private float defaultSpeed;
    private Renderer rend;
    AudioSource audioSource;
    public AudioClip impact;
    public GameObject powerUp1;
    private int powerUpSpawnAttempt;
    public int powerUpSpawnChance = 10; //Chance to spawn power-up is 1 in powerUpSpawnChance
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftScore = 0;
        rightScore = 0;
        defaultSpeed = speed;
        rb = GetComponent<Rigidbody>();

        //Start ball movement facing left at a random angle
        float maxAngle = 10f;
        float randomAngle = UnityEngine.Random.Range(-maxAngle, maxAngle);
        Vector3 direction = Quaternion.AngleAxis(randomAngle, Vector3.up) * -transform.right;
        rb.linearVelocity = direction * speed;

        rend = GetComponent<Renderer>();
    }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
        if (speed >= maxSpeed)
        {
            speed = maxSpeed; //Limits how fast the ball can go
        }
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
        leftScoreText.color = Color.white;
        rightScoreText.color = Color.white;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            speed = speed * 1.1f;
            audioSource.pitch = audioSource.pitch * 1.01f;
            //Change ball to a random color after each paddle collision
            rend.material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
            audioSource.PlayOneShot(impact);

            //Attempt to spawn power-up after every paddle collision
            System.Random rng = new System.Random();
            powerUpSpawnAttempt = rng.Next(0, powerUpSpawnChance + 1);
            if (powerUpSpawnAttempt == powerUpSpawnChance && !powerUp1.activeInHierarchy)
            {
                powerUp1.SetActive(true);
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("SpeedBoost"))
        {
            speed = speed * 2;
            powerUp1.SetActive(false);
        } else if (other.gameObject.CompareTag("Goal"))
        {
            if (powerUp1.activeInHierarchy)
            {
                powerUp1.SetActive(false);
            }
            if (transform.position.x < 0)
            {
                rightScore++;
                SetRightScoreText();
                Debug.Log("Right scored! (" + leftScore.ToString() + ":" + rightScore.ToString());
                audioSource.pitch = 1;
            } else
            {
                leftScore++;
                SetLeftScoreText();
                Debug.Log("Left scored! (" + leftScore.ToString() + ":" + rightScore.ToString());
                audioSource.pitch = 1;
            }

            //Change score text color based on score
            if (leftScore < 7)
            {
                leftScoreText.color = Color.white;
            } else if (leftScore >= 7 && leftScore < 10)
            {
                leftScoreText.color = Color.yellow;
            } else if (leftScore >= 10)
            {
                leftScoreText.color = Color.red;
            }

            if (rightScore < 7)
            {
                rightScoreText.color = Color.white;
            } else if (rightScore >= 7 && rightScore < 10)
            {
                rightScoreText.color = Color.yellow;
            } else if (rightScore >= 10)
            {
                rightScoreText.color = Color.red;
            }

            bool gameReset = false;
            if (leftScore >= 11)
            {
                Debug.Log("Game Over, left paddle wins!");
                ResetScore();
                gameReset = true;
            } else if (rightScore >= 11)
            {
                Debug.Log("Game Over, right paddle wins!");
                ResetScore();
                gameReset = true;
            }
            
            transform.position = new Vector3(0f, 0.26f, 0f);
            speed = defaultSpeed;
            
            if (gameReset)
            {
                //Start ball movement facing left at a random angle
                float maxAngle = 10f;
                float randomAngle = UnityEngine.Random.Range(-maxAngle, maxAngle);
                Vector3 direction = Quaternion.AngleAxis(randomAngle, Vector3.up) * -transform.right;
                rb.linearVelocity = direction * speed;
                audioSource.pitch = 1;
            }

            

        }
    }

}
