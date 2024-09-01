using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LetterCollector : MonoBehaviour
{
    public InventoryUI inventoryUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) 
    { 
        Debug.Log(collision.gameObject.tag);
        if(collision.transform.tag == "Letters")
        {
            SpriteRenderer spriterender = collision.gameObject.GetComponent<SpriteRenderer>();
            Sprite sprite = spriterender.sprite;
            Items item = new Items(sprite.name, sprite, 0, "LetterSerhii");
            inventoryUI.AddItem(item);

            Debug.Log(sprite.name);
            Debug.Log("COLLISION");

            Destroy(collision.gameObject);
        }
    } 
}
