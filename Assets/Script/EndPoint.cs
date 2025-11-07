using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] MenuManager _menuManager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //empecher une boucle inf de changement portal
        if (other.tag == "Player")
        {
            other.GetComponent<playerMouvement>().enabled = false;
            _menuManager.EndGame();

        }
    }
}
