using UnityEngine;
using UnityEngine.InputSystem;


public class blade_animation : MonoBehaviour
{
    public Animator bladeAnimator;
    private InputAction shiftPressed;

    void OnEnable()
    {
        shiftPressed = new InputAction(binding: "<Keyboard>/leftShift");
        shiftPressed.Enable();
    }

    void Update()
    {
        if (shiftPressed.WasPressedThisFrame())
        {
            print("turbo on");
            bladeAnimator.SetBool("is_turbo", true);
        }
        else
        {
            bladeAnimator.SetBool("is_turbo", false);
        }
    }

    void OnDisable()
    {
        shiftPressed.Disable(); 
    }


}
