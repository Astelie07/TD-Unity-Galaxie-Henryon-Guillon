using UnityEngine;

public class Collectibles : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(0, 0.5f, 0);
    }

    private void OnTriggerEnter(Collider other) {   
        if (other.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }
}
