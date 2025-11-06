using UnityEngine;

public class Collectible : MonoBehaviour
{
    private FrostManager _frostManager; 
    void Start()
    {
        _frostManager = FindAnyObjectByType<FrostManager>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("player detected");
            _frostManager.StartFrost();
            this.gameObject.SetActive(false);
        }
    }
}
