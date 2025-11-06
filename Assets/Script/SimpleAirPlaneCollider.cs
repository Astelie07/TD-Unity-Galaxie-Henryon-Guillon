using UnityEngine;

namespace HeneGames.Airplane
{
    public class SimpleAirPlaneCollider : MonoBehaviour
    {
        [HideInInspector] public SimpleAirPlaneController controller;
        [HideInInspector] public bool collideSometing;

        private void OnTriggerEnter(Collider other)
        {
            // Tu peux laisser ça vide, ou déclencher un effet visuel si tu veux
            collideSometing = true;
        }
    }
}
