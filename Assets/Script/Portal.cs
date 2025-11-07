using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform _otherPortalPos;

    private void OnTriggerEnter(Collider other)
    {
        //empecher une boucle inf de changement portal
        if (other.tag == "Player")
        {
            Debug.Log("player tp");
            other.GetComponent<playerMouvement>().enabled = false;
            other.transform.position = _otherPortalPos.position;
        }
    }

}
