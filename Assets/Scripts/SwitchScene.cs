using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnButtonClick(int levelId) 
    {
        PlayerPrefs.SetInt("Level", levelId);
        SceneManager.LoadScene(sceneName:"GameScene");
    }

    public void ReturnToScene(int levelId) 
    {
        Debug.Log("dsdekjd");
        SceneManager.LoadScene(sceneName:"MainScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
