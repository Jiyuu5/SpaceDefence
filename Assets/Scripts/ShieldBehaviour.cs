using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    public int shieldStrength = 5;
    private float widthPerShieldStrength = 0.05f;
    private float heightPerShieldStrength = 0.2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(shieldStrength * widthPerShieldStrength, transform.localScale.y, shieldStrength * heightPerShieldStrength);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            shieldStrength--;
            Destroy(other.gameObject);
            if (shieldStrength < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
