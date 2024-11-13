using Unity.VisualScripting;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float horizontalInput;
    public float fireRate = 1.0f;
    public GameObject projectile;
    private float movementBorder = 12f;
    public GameController gameController;
    private float fireRateCounter;


    // Start is called before the first frame update
    void Start()
    {
        fireRateCounter = 0f;
        gameController = FindFirstObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input and move the player
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // Prevent movement out of scene
        if (transform.position.x < -movementBorder)
        {
            transform.position = new Vector3(-movementBorder, 0, 0);
        }
        if (transform.position.x > movementBorder)
        {
            transform.position = new Vector3(movementBorder, 0, 0);
        }

        // Fire a projectile and reset fire rate interval
        if (Input.GetButton("Fire1") && fireRateCounter <= 0)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            fireRateCounter = fireRate;
        }

        // Reduce counter for fire rate latency
        fireRateCounter = fireRateCounter - Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameController.LoseOneLife();
        }
    }
}
