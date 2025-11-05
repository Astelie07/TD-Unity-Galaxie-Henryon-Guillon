using UnityEngine;

public class HighlightOnHover : MonoBehaviour
{
    public GameObject childObj;

    void Start()
    {
        if (childObj == null)
        {
            Debug.LogError($"[HighlightOnHover] Aucun objet assigné à 'childObj' pour {gameObject.name} !");
            return;
        }

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
