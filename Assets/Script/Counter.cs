using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private Image _counterCircle = null;
    [SerializeField] private TextMeshProUGUI _counterText = null;
    private float _currentCounter = 0;

    [SerializeField, Tooltip("Max counter time in secondes")] private int _maxTime = 10;
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _currentCounter += Time.deltaTime;

        if(_currentCounter <= _maxTime)
        {
            _counterCircle.fillAmount = (_currentCounter - 0) / (_maxTime - 0); //normalize data
            _counterText.text = Mathf.Round(_currentCounter).ToString();

        }
    }

    public void StartCounter()
    {
        _counterCircle.fillAmount = 0;
        _counterText.text = string.Empty;
        _currentCounter = 0;
        gameObject.SetActive(true);
    }

    public void StopCounter()
    {
        gameObject.SetActive(false);
    }
}
