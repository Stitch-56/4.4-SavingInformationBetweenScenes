using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * The LevelManager from the Week 6 Lecture
 */
public class LevelManager : MonoBehaviour {

    public static LevelManager instance;

    public SpriteRenderer circleSpriteRenderer;

    public string currentLevel;
    public bool saveGameState;

    private void Awake()
    {
        // set the instance property/variable to this object
        instance = this;

        currentLevel = SceneManager.GetActiveScene().name;

        Color circleColor = Color.white;

        if (PlayerPrefs.HasKey("CircleRed") == true)
        {
            circleColor.r = PlayerPrefs.GetFloat("CircleRed");
        }

        if (PlayerPrefs.HasKey("CircleGreen") == true)
        {
            circleColor.g = PlayerPrefs.GetFloat("CircleGreen");
        }

        if (PlayerPrefs.HasKey("CircleBlue") == true)
        {
            circleColor.b = PlayerPrefs.GetFloat("CircleBlue");
        }

        circleSpriteRenderer.color = circleColor;
    }

    public void OnCircleTriggerEnter(Collider2D collision)
    {
        Debug.Log("OnCircleTriggerEnter");

        
        circleSpriteRenderer.color = Color.green;

        
    }

    public void OnPortalTriggerEnter(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene("Level2");
        }
        else
        {
            SceneManager.LoadScene("Level1");
        }

        if (saveGameState == true)
        {
            SaveGameState();
        }
    }

    private void SaveGameState()
    {
        PlayerPrefs.SetFloat("CircleRed", circleSpriteRenderer.color.r);
        PlayerPrefs.SetFloat("CircleGreen", circleSpriteRenderer.color.g);
        PlayerPrefs.SetFloat("CircleBlue", circleSpriteRenderer.color.b);
    }



}
