using TMPro;
using UnityEngine;

public class PanelActivator : MonoBehaviour
{
    [SerializeField] private GameObject CatchPanel;
    [SerializeField] private TextMeshProUGUI WeightText;
    [SerializeField] private TextMeshProUGUI LengthText;

    void Start()
    {
        CatchPanel.SetActive(false);
    }

    public void DisplayCatchPanel()
    {
        CatchPanel.SetActive(true);
    }

    public void SetValues(float _Weight, float _Length)
    {
        WeightText.text = _Weight.ToString();
        LengthText.text = _Length.ToString();
        Debug.Log(_Weight.ToString() + "   " + _Length.ToString());
    }

}
