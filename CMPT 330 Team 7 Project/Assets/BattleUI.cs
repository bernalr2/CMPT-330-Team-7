using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public Text nameText;
    public Text stressText;
    public Slider stressSlider;

    public void SetUI(Unit unit)
    {
        nameText.text = unit.unitName;
        stressText.text = "Stress: " + unit.currentStress.ToString() + "%";
        stressSlider.maxValue = unit.maxStress;
        stressSlider.value = unit.currentStress;

    }

    public void SetStress(int stress)
    {
        stressSlider.value = stress;
        stressText.text = "Stress: " + stress.ToString() + "%";
    }
}
