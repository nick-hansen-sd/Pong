using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public float paddleSpeed = 10f;
    public float maxZ = 3.75f;
    public float minZ = -3.75f;

    void FixedUpdate()
    {
        
        if ((Keyboard.current.wKey.isPressed && transform.position.x < 0) || (Keyboard.current.upArrowKey.isPressed && transform.position.x > 0))
        {
            Vector3 newPosition = transform.position + new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
            newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

            transform.position = newPosition;
        }

        if ((Keyboard.current.sKey.isPressed && transform.position.x < 0) ||(Keyboard.current.downArrowKey.isPressed && transform.position.x > 0))
        {
            Vector3 newPosition = transform.position - new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime;
            newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

            transform.position = newPosition;
        }

    }
}
