using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float speed = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
