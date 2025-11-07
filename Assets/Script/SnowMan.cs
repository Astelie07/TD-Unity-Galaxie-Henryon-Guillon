using UnityEngine;

public class SnowMan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.AddComponent<Rigidbody>();
    }
}
