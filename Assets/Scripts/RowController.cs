using Unity.VisualScripting;
using UnityEngine;

public class RowController : MonoBehaviour
{
    public float borderValue = 12f;
    public GameController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Change move direction of enemy row at border contact
        ChangeDirection();

        // Move the row
        transform.Translate(Vector3.left * Time.deltaTime * controller.movementSpeed * controller.moveDirection);

        if (transform.childCount < 1)
        {
            Destroy(gameObject);
        }
    }

    
    void ChangeDirection()
    {
        if (transform.position.x < -borderValue)
        {
            controller.SetMoveDirection(-1);
        }
        if (transform.position.x > borderValue)
        {
            controller.SetMoveDirection(1);
        }
    }
}
