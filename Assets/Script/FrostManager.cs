using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FrostManager : MonoBehaviour
{
    [SerializeField] private float _fillValue = 0;
    [SerializeField] private Material _frostUi;
    [SerializeField] private Material _frozenScreen;

    private bool _frostAction = false;

    private float _currentCounter = 0;
    public float _maxTime = 10;

    private int _collectNb = 0;
    [SerializeField] TextMeshProUGUI _collectCounter;

    [SerializeField] AgentManager _agentManager;

    void Start()
    {
        //_filler = _frostUi.;
        _frozenScreen.SetFloat("_Strength", 0f);
        _collectNb = 0;
        _collectCounter.text = string.Empty;
        _frostUi.SetFloat("_Fill", 0f);
    }

    void Update()
    {

        if(_frostAction == true)
        {
            _currentCounter += Time.deltaTime;

            if (_currentCounter <= _maxTime)
            {
                _fillValue = (_currentCounter - 0) / (_maxTime - 0); //normalize data
                _frostUi.SetFloat("_Fill", _fillValue);
                _frozenScreen.SetFloat("_Strength", 1 - _fillValue);
                _agentManager.ChangeAgentsValues(_fillValue);
            }
            else
            {
                _frostAction = false;
            }
        }
    }

    public void StartFrost()
    {
        Debug.Log("start frost");
        //actionner l'ui + l'effet de post process, start un timer
        _fillValue = 0;
        _frostAction = true;
        _collectNb += 1;
        _collectCounter.text = _collectNb.ToString();

    }
}
