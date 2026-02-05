using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float paddleSpeed = 1f;
    public float maxZ = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((Keyboard.current.wKey.isPressed && transform.position.x < 0) || (Keyboard.current.upArrowKey.isPressed && transform.position.x > 0))
        {
            Vector3 newPosition = transform.position + new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
            newPosition.z = Mathf.Clamp(newPosition.z, -10f, maxZ);

            transform.position = newPosition;
            //transform.position += new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
        }

        if ((Keyboard.current.sKey.isPressed && transform.position.x < 0) || (Keyboard.current.downArrowKey.isPressed && transform.position.x > 0))
        {
            transform.position -= new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
        }

        Vector3 up = Vector3.up;
        Quaternion testRotation = Quaternion.Euler(60f, 0f, 0f);

        Vector3 rotatedVector = testRotation * up;

        Quaternion otherRotation = Quaternion.Euler(-60f, 0f, 0f);
        Vector3 otherRotatedVector = otherRotation * up;

    }
}
