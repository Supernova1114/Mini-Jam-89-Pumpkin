using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public Slider staminaBar;
    private int maxStamina = 1000;
    private int currentStamina;
    private Coroutine regen;

    public static StaminaController instance;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }
    public int CheckStamina() 
    {
        return currentStamina;
    }
    public void SprintCost(int cost) 
    {
        if (currentStamina - cost >= 0)
        {
            currentStamina -= cost;
            staminaBar.value = currentStamina;

            if (regen != null) {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(RegenStamina());
        }
    }
    private IEnumerator RegenStamina() 
    {
        yield return new WaitForSeconds(1);

        while (currentStamina < maxStamina) 
        {
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            yield return new WaitForSeconds(0.1f);
        }
        regen = null;
    }
}
