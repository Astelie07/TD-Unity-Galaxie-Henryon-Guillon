using UnityEngine;
using UnityEngine.UI;


public class FrostManager : MonoBehaviour
{
    [SerializeField] private float _fillValue = 0;
    [SerializeField] private Material _frostUi;

    void Start()
    {
        //_filler = _frostUi.;
    }

    void Update()
    {
        _frostUi.SetFloat("_Fill",_fillValue);
    }

    public void StartFrost()
    {
        Debug.Log("start frost");
        //actionner l'ui + l'effet de post process, start un timer
    }
}
