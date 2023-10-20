using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    bool isGameOver = false;
    bool badRemain = true;
    bool isMoving = true;

    [SerializeField] float Timer = 3f;
    private float currentTimer;
    [SerializeField] float movementThreshold;

    [SerializeField] TextMeshProUGUI messageText;
    [SerializeField] TextMeshProUGUI gameOverText;

    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving && GameObject.FindGameObjectsWithTag("Bad").Length == 0)
        {
            currentTimer -= Time.deltaTime;
            if (currentTimer > 0)
            {
                return;
            }
            else if (currentTimer <= 0)
            {
                gameWin("You cleared all the Bad Blocs");
            }
            isMoving = false;
            foreach (GameObject bloc in GameObject.FindGameObjectsWithTag("Good"))
            {

                if (bloc.GetComponent<Rigidbody2D>().velocity.magnitude > movementThreshold)
                {
                    isMoving = true;
                    break;
                }

            }

            if (!isMoving)
            {
                isMoving = true;
                currentTimer = Timer;
            }

        }
    }



    public void gameOver(string message)
    {
        isGameOver = true;
        messageText.text = message;
        gameOverText.text = "Game Over";
    }

    public void gameWin(string message)
    {
        isGameOver = true;
        messageText.text = message;
        gameOverText.text = "You Win";
    }


}
