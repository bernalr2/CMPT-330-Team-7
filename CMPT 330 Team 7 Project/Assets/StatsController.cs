using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour
{
    public Slider stressBar;
    public Slider energyBar;
    public GameObject playerReference;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Unit player = playerReference.GetComponent<Unit>();
        stressBar.maxValue = player.maxStress;
        stressBar.value = player.currentStress;

        energyBar.maxValue = player.maxEnergy;
        energyBar.value = player.currentEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
