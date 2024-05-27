using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour
{
	public event Action onHealthChanged;
	private int currentHealth;
    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = value;
            onHealthChanged();
        }
    }
    
    public int maxHealth = 2;
    public bool hasTresspassed = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void OnHealthChanged()
    {
        if(currentHealth < 1)
        {
            hasTresspassed = true;
        }
    }
}
