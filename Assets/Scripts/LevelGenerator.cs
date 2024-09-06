using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;


public class LevelGenerator : MonoBehaviour
{
    public GameObject groundPreFab; 
    public GameObject wallPreFab;
    public int countBlocks = 5;
    private Vector2 size = Vector2.zero;
    public GameObject letterPreFab;
    public GameObject exitLevelPreFab;
    public GameObject player;

    public Sprite[] letterSprites;

    Levels levels = new Levels();

    public Level currentLevel;
 

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer renderer = groundPreFab.GetComponent<SpriteRenderer>();
        size = renderer.bounds.size;
        // createGround();
        // createWalls();
        // createLetters();
        // CreateExit();
        System.Random rnd = new System.Random();
        int levelFromPreviousScene = PlayerPrefs.GetInt("Level");
        currentLevel = levels.GetLevel(levelFromPreviousScene);
        CreateLevelStr(currentLevel.level);
    }

    void CreateLevelStr(string levelStr)
    {
        float defaultX = 0;
        float defaultY = 0;
        //--
        float startX = defaultX;
        float startY = defaultY;

        for(int i = 0; i < levelStr.Length; i++)
        {
            if(levelStr[i] == '#')
            {
                Instantiate(wallPreFab, new Vector3(startX, startY, 0), Quaternion.identity);
                startX = startX + size.x; 
            }
            else if(levelStr[i] == ' ')
            {
                Instantiate(groundPreFab, new Vector3(startX, startY, 0), Quaternion.identity);
                startX = startX + size.x;
            }
            else if(levelStr[i] == 'P') 
            {
                player.transform.position = new Vector3(startX, startY, 0);
                player.SetActive(true);
                startX = startX + size.x; 
                Instantiate(groundPreFab, new Vector3(player.transform.position.x, player.transform.position.y, 0), Quaternion.identity);
            }
            else if(levelStr[i] == 'E')
            {
                Instantiate(exitLevelPreFab, new Vector3(startX, startY, 0), Quaternion.identity);
                startX = startX + size.x;
            }
            else if((levelStr[i] - '0') >= 49 && (levelStr[i] - '0') <= ('z' - '0'))
            {
                // ASCII a = 49
                int levelStrASCII = levelStr[i] - '0';
                int diff = levelStrASCII - 49;
                GameObject letter = Instantiate(letterPreFab, new Vector3(startX, startY, 0), Quaternion.identity);
                SpriteRenderer letterSp = letter.GetComponent<SpriteRenderer>();
                letterSp.sprite = letterSprites[diff];
                Instantiate(groundPreFab, new Vector3(startX, startY, 0), Quaternion.identity);
                //
                startX = startX + size.x;
            }
            else if(levelStr[i] == '\n')
            {
                startY = startY + size.y;
                startX = defaultX;
            }
        }
    }

    public string ArrayReverseString(string stringToReverse)
    {
        var charArray = stringToReverse.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    void createGround() 
    { 
        SpriteRenderer renderer = groundPreFab.GetComponent<SpriteRenderer>();
        Vector2 size = renderer.bounds.size;


        // for(int i = -countBlocks/2; i < countBlocks/2; i++)
        // {
        //     Instantiate(groundPreFab, new Vector3(i * size.x, 0, 0), Quaternion.identity);
        // }

        //
        int localCountBlocks = countBlocks * 2;

        float startX = -(localCountBlocks * size.x)/2;
        float startY = -(localCountBlocks * size.y)/2;

        for(int i = 0; i < localCountBlocks; i++)
        {
            for(int j =  0; j < localCountBlocks; j++) 
            {
                Instantiate(groundPreFab, new Vector3(startX, startY, 0), Quaternion.identity);
                startX = startX + size.x;
            }
            startY = startY + size.y; 
            startX = -(localCountBlocks * size.x)/2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createWalls() 
    {   
        //daun wall
        float startX = -(countBlocks * size.x)/2;
        float startY = -(countBlocks * size.y)/2;
    
        for(int j =  0; j < countBlocks; j++) 
        {
            Instantiate(wallPreFab, new Vector3(startX, startY, 0), Quaternion.identity);
            startX = startX + size.x;
        }
        
        //upa wall 
        startY = (countBlocks * size.y)/2;
        startX = -(countBlocks * size.x)/2;
        for(int j =  0; j < countBlocks; j++) 
        {
            Instantiate(wallPreFab, new Vector3(startX, startY, 0), Quaternion.identity);
            startX = startX + size.x;
        }

        //lift wall
        startX = -startX; 
        startY = -startY;
        for(int j =  0; j < countBlocks; j++) 
        {
            Instantiate(wallPreFab, new Vector3(startX, startY, 0), Quaternion.identity);
            startY = startY + size.y;
        }
        //NoRightsForWomen wall 
        startX = (countBlocks * size.x)/2;
        startY = -startY;
        for(int j =  0; j < countBlocks; j++) 
        {
            Instantiate(wallPreFab, new Vector3(startX, startY, 0), Quaternion.identity);
            startY = startY + size.y;
        }


    }

    void createLetters () 
    {
        CityCountryRandom cityCountryRandom = new CityCountryRandom();
        string cityCountry = cityCountryRandom.GetRandomCityOrCountry();

        for(int i = 0; i < cityCountry.Length; i++)
        {
            int cityCountryInt = cityCountry[i] - '0';
            int diff = cityCountryInt - 49;
            GameObject letter = Instantiate(letterPreFab, new Vector3(i+1, 1, 0), Quaternion.identity);
            SpriteRenderer letterSp = letter.GetComponent<SpriteRenderer>();
            letterSp.sprite = letterSprites[diff];
        }
    }

    void CreateExit () 
    {
        // float startX = -(countBlocks * size.x)/2;
        // float startY = -(countBlocks * size.y)/2;  
        // startX = startX + (countBlocks/2) * size.x;
        // Instantiate(exitLevelPreFab, new Vector3(startX, startY, 0), Quaternion.identity);

        System.Random rnd = new  System.Random();
        int orientation  = rnd.Next(0,10);

        //BikiniBottom
        {
            float startX = -(countBlocks * size.x)/2;
            float startY = -(countBlocks * size.y)/2;   

            int randomBlockNumber = rnd.Next(1, countBlocks-2);
            Instantiate(exitLevelPreFab, new Vector3(startX + randomBlockNumber * size.x, startY, 0), Quaternion.identity);
        }
        //RightOfLolMen
        {
            float startX = -(countBlocks * size.x)/2;
            float startY = -(countBlocks * size.y)/2;   

            int randomBlockNumber = rnd.Next(1, countBlocks-2);
            Instantiate(exitLevelPreFab, new Vector3(-startX, startY + randomBlockNumber * size.y, 0), Quaternion.identity);
        }
        
        //leftParty
        {
            float startX = -(countBlocks * size.x)/2;
            float startY = -(countBlocks * size.y)/2;   

            int randomBlockNumber = rnd.Next(1, countBlocks-2);
            Instantiate(exitLevelPreFab, new Vector3(startX, startY + randomBlockNumber * size.y, 0), Quaternion.identity);
        }
        
        //Upper
        {
            float startX = -(countBlocks * size.x)/2;
            float startY = -(countBlocks * size.y)/2;   

            int randomBlockNumber = rnd.Next(1, countBlocks-2);
            Instantiate(exitLevelPreFab, new Vector3(startX + randomBlockNumber * size.x, -startY, 0), Quaternion.identity);
        }
    }
}
