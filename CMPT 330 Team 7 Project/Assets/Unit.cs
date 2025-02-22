using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;

    public int damage;

    public int maxStress;
    public int currentStress;

    public bool TakeDamage(int damage)
    {
        currentStress += damage;

        if (currentStress == maxStress)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    public void Heal(int amount)
    {
        currentStress -= amount;
        if(currentStress <= 0)
        {
            currentStress = 0;
        }


    }

}
