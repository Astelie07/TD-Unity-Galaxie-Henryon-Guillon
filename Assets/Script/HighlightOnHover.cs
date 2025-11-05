using UnityEngine;

public class HighlightOnHover : MonoBehaviour
{
    public GameObject childObj;

    void Start()
    {
        childObj.SetActive(false);
    }
    
    public void OnMouseOverPublic()
    {
        if (childObj != null)
            childObj.SetActive(true);
    }

    public void OnMouseExitPublic()
    {
        if (childObj != null)
            childObj.SetActive(false);
    }
}
