using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelActivator : MonoBehaviour
{
    [SerializeField] private GameObject CatchPanel;
    [SerializeField] private Image FishNameImage;
    [SerializeField] private Image FishSpriteImage;
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
        WeightText.text = _Weight.ToString("F2") + "KG";
        LengthText.text = _Length.ToString("F2") + "CM";
    }

}
