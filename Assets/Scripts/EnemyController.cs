using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float timeToFirstDrop;
    public float dropInterval;
    public int scoreOnKill = 10;
    public GameObject projectile;
    public GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        // Set Random Time for first Drop and
        SetNewRandomDropInterval();
        // Start dropping Bombs
        Invoke("DropProjectile", dropInterval);

    }

    // Update is called once per frame
    void Update()
    {
        // Move the Object
        // transform.Translate(Vector3.left * Time.deltaTime * controller.movementSpeed * controller.moveDirection);

        // Check if ground level is reached
        if (transform.position.y < 2)
        {
            controller.GameOver();
        }
    }

    // Drop a bomb and set a new interval to the next bomb drop
    void DropProjectile()
    {
        Instantiate(projectile, transform.position, transform.rotation);
        SetNewRandomDropInterval();
        Invoke("DropProjectile", dropInterval);
    }

    // Increase Gamescore
    private void OnDestroy()
    {
        controller.IncreaseGameScore(scoreOnKill);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }

    void SetNewRandomDropInterval()
    {
        dropInterval = Random.Range(3f, 30f);
    }
}
