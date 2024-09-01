using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health = 3;

    public Image[] hearts;
    public Sprite fullHeart; 
    public Sprite emptyHeart;
    private int maxHealth = 0;

    void Start() 
    {
        // Update all hearts to empty initially
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }

        maxHealth = hearts.Length; 
    }

    // Update is called once per frame
    void Update()
    {
        // Set the correct number of hearts to full
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
        // Set the correct number of hearts to empty
        for(int i = health; i < maxHealth; i++) 
        {
            hearts[i].sprite = emptyHeart;
        }
    }
}
