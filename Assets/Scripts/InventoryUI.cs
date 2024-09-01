using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject[] letters;
    public Inventory inventory;
    public GameObject inventoryPanel;
    public GameObject inventorySlotPrefab;
    public Transform slotContainer;
    private int lettersCount = 0;
    private int lettersUILimit = 10;
    public TMP_Text text; 

    private void Start()
    {
        inventoryPanel.SetActive(false); // Hide inventory panel at start
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf); // Toggle inventory panel
        }
    }

    public void setText(string str) {
        text.text = str;
    }

    public string GetStringInventar() {
        string result = "";

        for(int i = 0; i < letters.Length; i++) {
            GameObject letter = letters[i];
            SpriteRenderer sr = letter.GetComponent<SpriteRenderer>();  
            if(sr.sprite.name.Contains("_")) {
                string spriteName = sr.sprite.name.Split('_')[1].ToLower();
                result = result + spriteName;
            } else {
                //sresult = result + " ";
            }
            
        }

        return result;
    }

    public void AddItem(Items item)
    {
        inventory.AddItem(item);

        if(lettersCount < lettersUILimit)
        {
            GameObject letter = letters[lettersCount];
            SpriteRenderer sr = letter.GetComponent<SpriteRenderer>();
            sr.sprite = item.itemIcon;
            lettersCount = lettersCount + 1;
        }
    }

    public void OnIconClick1() {
        SwapLogic(0);
    }  

    public void OnIconClick2() {
SwapLogic(1);
    }

    public void OnIconClick3() {
SwapLogic(2);
    }

    public void OnIconClick4() {
SwapLogic(3);
    }

    public void OnIconClick5() {
SwapLogic(4);
    }

    public void OnIconClick6() {
SwapLogic(5);
    }

    public void OnIconClick7() {
SwapLogic(6);
    }

    public void OnIconClick8() {
SwapLogic(7);
    }

    public void OnIconClick9() {
SwapLogic(8);
    }

    public void OnIconClick10() {
        SwapLogic(9);
    }

    public void SwapLogic(int currentIndex) {
        int selectedIndex = -1;

        for(int i = 0; i < letters.Length; i++) 
        {
            if(IsInventoryLetterSelect(letters[i]))
            {
                selectedIndex = i;
                break;
            }
        }

        if(selectedIndex == -1) {
            SelectInventoryLetter(letters[currentIndex]);
        }
        else {
            SwapInventoryLetters(letters[currentIndex], letters[selectedIndex]);
            DeselectInventoryLetter(letters[selectedIndex]);
        }
    }

    public void SelectInventoryLetter(GameObject obj) {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        sr.material.color = Color.yellow;
    }

    public void DeselectInventoryLetter(GameObject obj) {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        sr.material.color = Color.white;
    }

    public bool IsInventoryLetterSelect(GameObject obj) {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        if(sr.material.color != Color.white)
        {
            Debug.Log("Letter is selected");
            return true;
        }
        else {
            return false;
        }

    }

    public void SwapInventoryLetters(GameObject firstObj, GameObject secondObj) {
        SpriteRenderer firstSr = firstObj.GetComponent<SpriteRenderer>();
        SpriteRenderer secondSr = secondObj.GetComponent<SpriteRenderer>();
        Sprite temp = firstSr.sprite;
        firstSr.sprite = secondSr.sprite;
        secondSr.sprite = temp;
    }
}
