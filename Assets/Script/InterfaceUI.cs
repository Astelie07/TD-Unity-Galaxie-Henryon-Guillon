using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InterfaceUI : MonoBehaviour
{
    public Text countText;
    public Text instructions;
    public int collectible;

    private InputAction destroyAction;

    private void Awake()
    {
        destroyAction = new InputAction("DestroyInstructions", InputActionType.Button, "<Keyboard>/leftShift");
        destroyAction.performed += OnDestroyActionPerformed;
        destroyAction.Enable();
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
            other.gameObject.SetActive(false);
            collectible++;
            UpdateCountText();
        }
    }

    private void UpdateCountText()
    {
        if (countText != null)
            countText.text = "Count: " + collectible + " / X";
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
}
