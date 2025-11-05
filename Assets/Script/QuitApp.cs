using UnityEngine;
using UnityEngine.InputSystem; 

public class QuitApp : MonoBehaviour
{
    private InputAction quitAction;

    void OnEnable()
    {
        quitAction = new InputAction(binding: "<Keyboard>/escape");
        quitAction.Enable();
    }

    void OnDisable()
    {
        quitAction.Disable();
    }

    void Update()
    {
        if (quitAction.WasPressedThisFrame())
        {
            Quit();
        }
    }

    void Quit()
    {
        Debug.Log("Fermeture");
        Application.Quit();

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
