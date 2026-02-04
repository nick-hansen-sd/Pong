using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float paddleSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Keyboard.current.dKey.isPressed)
        {
            transform.position += new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            transform.position -= new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
        }


    }
}
