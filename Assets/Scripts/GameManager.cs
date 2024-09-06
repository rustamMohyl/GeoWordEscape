using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InventoryUI inventoryUI;

    public LevelGenerator levelGen;

    private void Start()
    {
        //
        //levelGen.currentLevel.city;
        
        
    }

    private void FixedUpdate() 
    {
        string inventarStr = inventoryUI.GetStringInventar();
        string cityStr = levelGen.currentLevel.city;

        if(cityStr == inventarStr) 
        {
            inventoryUI.setText("Correct");
        }
        else{
            inventoryUI.setText("Wrong");
        }
        //Debug.Log(inventarStr + " " + cityStr);
    }
}
