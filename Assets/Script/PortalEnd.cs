using UnityEngine;

public class PortalEnd : MonoBehaviour
{
    [SerializeField] private GameObject _splashEffect;

    private void OnTriggerEnter(Collider other)
    {
        //empecher une boucle inf de changement portal
        if (other.tag == "Player")
        {
            other.GetComponent<playerMouvement>().enabled = true;
            _splashEffect.SetActive(true);
        }
    }
}
