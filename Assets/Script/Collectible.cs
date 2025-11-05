using UnityEngine;

public class Collectible : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("player detected");
            this.enabled = false;
        }
    }
}
