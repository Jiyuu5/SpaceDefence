using UnityEngine;

public class DestroyOutOfScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 15 || transform.position.y < -1)
        {
            Destroy(gameObject);
        }
    }
}
