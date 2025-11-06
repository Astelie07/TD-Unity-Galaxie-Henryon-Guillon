using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleOrbit : MonoBehaviour
{
    public Orbit orbitScript;
    public Key toggleKey = Key.Space;

    // Appuyer sur espace arrete / relance le script Orbit

    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current[toggleKey].wasPressedThisFrame)
        {
            if (orbitScript != null)
                orbitScript.enabled = !orbitScript.enabled;
        }
    }
}
