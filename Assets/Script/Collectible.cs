using UnityEngine;

public class Collectible : MonoBehaviour
{
    private FrostManager _frostManager;
    [SerializeField] private GameObject _splashEffect;
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
            _splashEffect.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
