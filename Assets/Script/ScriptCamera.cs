using UnityEngine;
using UnityEngine.InputSystem; 

public class ScriptCamera : MonoBehaviour
{
    private HighlightOnHover currentHover;

    void Update()
    {
        if (Mouse.current == null) return; 

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            HighlightOnHover hover = hit.collider.GetComponent<HighlightOnHover>();

            if (hover != null)
            {
                if (hover != currentHover)
                {
                    if (currentHover != null)
                        currentHover.OnMouseExitPublic();

                    currentHover = hover;
                    currentHover.OnMouseOverPublic();
                }
            }
            else if (currentHover != null)
            {
                currentHover.OnMouseExitPublic();
                currentHover = null;
            }
        }
        else if (currentHover != null)
        {
            currentHover.OnMouseExitPublic();
            currentHover = null;
        }
    }
}
