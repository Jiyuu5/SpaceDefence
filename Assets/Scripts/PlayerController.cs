using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10.0f;
    [SerializeField] InputAction moveLeft;
    [SerializeField] InputAction moveRight;
    [SerializeField] InputAction fireLaser;
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

    private void OnEnable() {
        moveLeft.Enable();
        moveRight.Enable();
        fireLaser.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input and move the player
        if(moveLeft.IsPressed()){
            transform.Translate(Vector3.left * Time.deltaTime * movementSpeed );
        }
        if(moveRight.IsPressed()){
            transform.Translate(Vector3.right * Time.deltaTime * movementSpeed );
        }

        

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
        if (fireLaser.IsPressed() && fireRateCounter <= 0)
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
