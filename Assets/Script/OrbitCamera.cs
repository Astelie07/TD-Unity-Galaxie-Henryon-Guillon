using UnityEngine;
using UnityEngine.InputSystem; // nouveau Input System
public class OrbitCamera : MonoBehaviour
{
    public Transform sun;  // le Soleil
    private float distance = 10f;
    private float x = 0f;
    private float y = 20f;

    void LateUpdate()
    {
        if (sun == null) return;

        float horizontal = 0f;
        float vertical = 0f;

        // Flèches - rotation

        if (Keyboard.current != null)
        {
            if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) horizontal -= 1f;
            if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed) horizontal += 1f;
            if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed) vertical += 1f;
            if (Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed) vertical -= 1f;
        }

        x += horizontal * 120f * Time.deltaTime;
        y -= vertical * 120f * Time.deltaTime;
        y = Mathf.Clamp(y, -20f, 80f);

        // Zoom
        if (Mouse.current != null)
        {
            float scroll = Mouse.current.scroll.ReadValue().y;
            distance -= scroll * 0.5f; // vitesse du zoom
            distance = Mathf.Clamp(distance, 2f, 20f);
        }

        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 position = rotation * new Vector3(0, 0, -distance) + sun.position;

        transform.rotation = rotation;
        transform.position = position;
    }
}
