using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public HealthManager healthManager;
    public GameObject inventoryPanel;
    void OnCollisionEnter2D(Collision2D collision) 
    {   
        if(collision.transform.tag == "EnemyAI")
        {
            healthManager.health--;
            if(healthManager.health <=0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }

        if(collision.transform.tag == "Exit")
        {
            Debug.Log("You want to exit game ");
            inventoryPanel.SetActive(true);
        }
        
    }
    IEnumerator GetHurt() 
    {
        Physics2D.IgnoreLayerCollision(6,3);
        yield return new WaitForSeconds(2);
        Physics2D.IgnoreLayerCollision(6,3, false );
    }
}
