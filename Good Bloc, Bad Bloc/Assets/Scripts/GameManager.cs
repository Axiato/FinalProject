using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool isGameOver = false;
    bool isMoving = true;
    int numGood;

    [SerializeField] float Timer = 3f;
    private float currentTimer;
    [SerializeField] float movementThreshold = 1.5f;

    [SerializeField] TextMeshProUGUI messageText;
    [SerializeField] TextMeshProUGUI gameOverText;

    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject mainMenuButton;
    [SerializeField] GameObject nextLevelButton;
    [SerializeField] GameObject mainMenuButton2;
    [SerializeField] GameObject restartButton2;


    // Start is called before the first frame update
    void Start()
    {
        currentTimer = Timer;
        numGood = GameObject.FindGameObjectsWithTag("Good").Length;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isMoving);
        if (GameObject.FindGameObjectsWithTag("Good").Length != numGood)
        {
            gameOver("You killed a Good Bloc");
        }
        if (GameObject.FindGameObjectsWithTag("Bad").Length == 0)
        {
            currentTimer -= Time.deltaTime;
            
            if (currentTimer > 0)
            {
                return;
            }
            else if (currentTimer <= 0 && !isGameOver && !isMoving)
            {
                gameWin("Level Cleared");
            }
            isMoving = false;
            foreach (GameObject bloc in GameObject.FindGameObjectsWithTag("Good"))
            {

                if (bloc.GetComponent<Rigidbody2D>().velocity.magnitude > movementThreshold)
                {
                    Debug.Log(bloc.GetComponent<Rigidbody2D>().velocity.magnitude > movementThreshold);
                    isMoving = true;
                    break;
                }

            }

            if (isMoving)
            {
                currentTimer = Timer;
            }

        }
    }



    public void gameOver(string message)
    {
        isGameOver = true;
        messageText.text = message;
        gameOverText.text = "Game Over";
        mainMenuButton.SetActive(true);
        restartButton.SetActive(true);
        mainMenuButton2.SetActive(false);
        restartButton2.SetActive(false);
    }

    public void gameWin(string message)
    {
        Debug.Log(message);
        isGameOver = true;
        messageText.text = message;
        gameOverText.text = "You Win";
        mainMenuButton.SetActive(true);
        nextLevelButton.SetActive(true);
        mainMenuButton2.SetActive(false);
        restartButton2.SetActive(false);
    }

    public void LevelSelect(int level) // main menu == 0
    {
        SceneManager.LoadScene(level);
    }
}
