using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InterfaceUI : MonoBehaviour
{
    public Text countText;
    public Text instructions;
    private int collectible;

    public AudioClip soundClip;

    private InputAction destroyAction;

    private InputAction escapeAction;

    public GameObject victoire;

    private void Awake()
    {
        destroyAction = new InputAction("DestroyInstructions", InputActionType.Button, "<Keyboard>/leftShift");
        destroyAction.performed += OnDestroyActionPerformed;
        destroyAction.Enable();

        escapeAction = new InputAction("Escape", InputActionType.Button, "<Keyboard>/escape");
        escapeAction.performed += OnEscapePressed;
        escapeAction.Enable();
    }

    private void Start()
    {
        collectible = 0;
        UpdateCountText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("star"))
        {
             if (!other.gameObject.activeSelf) return;

            PlayCollectSound();
            other.gameObject.SetActive(false);
            collectible++;
            UpdateCountText();
            if (collectible == 10)
            {
                victoire.gameObject.SetActive(true);
            }
        }

    }

    private void PlayCollectSound()
    {
        GameObject tempAudio = new GameObject("TempAudio");
        AudioSource aSource = tempAudio.AddComponent<AudioSource>();
        aSource.clip = soundClip;
        aSource.volume = 0.5f;
        aSource.priority = 10;
        aSource.spatialBlend = 0f;
        aSource.Play();
        Destroy(tempAudio, soundClip.length);
    }


    private void UpdateCountText()
    {
        if (countText != null)
            countText.text = "Stars: " + collectible + " / 10";
    }

    private void OnDestroyActionPerformed(InputAction.CallbackContext ctx)
    {
        DestroyInstructions();
    }

    private void DestroyInstructions()
    {
        if (instructions != null)
        {
            Destroy(instructions.gameObject);
            instructions = null;
        }
    }

    private void OnDestroy()
    {
        if (destroyAction != null)
        {
            destroyAction.performed -= OnDestroyActionPerformed;
            destroyAction.Disable();
            destroyAction.Dispose();
        }
    }

    private void OnEscapePressed(InputAction.CallbackContext ctx)
    {
        if (collectible >= 10)
        {
            Debug.Log("Fermeture");
            Application.Quit();

            #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }

}
