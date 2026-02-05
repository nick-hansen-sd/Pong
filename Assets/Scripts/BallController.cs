using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    
    public float thrust = 0f;
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    private int leftScore;
    private int rightScore;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftScore = 0;
        rightScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(transform.right * -thrust);
    }

    void SetLeftScoreText()
    {
        leftScoreText.text = "Score: " + leftScore.ToString();
    }

    void SetRightScoreText()
    {
        rightScoreText.text = "Score: " + rightScore.ToString();
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            if (transform.position.x < 0)
            {
                leftScore++;
                SetLeftScoreText();
            } else
            {
                rightScore++;
                SetRightScoreText();
            }
            transform.position = new Vector3(0f, 0.26f, 0f);
        }
    }

}
