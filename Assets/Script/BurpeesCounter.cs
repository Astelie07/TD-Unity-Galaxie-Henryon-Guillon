using UnityEngine;

using TMPro;

public class BurpeesCounter : MonoBehaviour
  
{
    [SerializeField] private TextMeshProUGUI counter_text;

    int number_burpees = 0;


    void Start()
    {
    }

    void Update()
    {
    }

    public void BurpeeIncrement()
    {
        number_burpees = number_burpees + 1;
        counter_text.text = "Number of burpees : " + number_burpees;
    }
}
