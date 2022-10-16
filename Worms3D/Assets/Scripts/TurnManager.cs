using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private float timeBetweenTurns;
    
    public int currentPlayerIndex;
    private bool waitingForNextTurn;
    private float turnDelay;
    private PlayerTurn currentPlayer;


    public Camera Player1Cam;
    public Camera Player2Cam;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 1;
            playerOne.SetPlayerTurn(1);
            playerTwo.SetPlayerTurn(2);
        }
        Debug.Log(currentPlayerIndex +" is the current players turn");
    }

    private void Update()
    {
        if (waitingForNextTurn)
        {
            turnDelay += Time.deltaTime;
            if (turnDelay >= timeBetweenTurns)
            {
                turnDelay = 0;
                waitingForNextTurn = false;
                ChangeTurn();
            }
        }

        ChangeCamera();
    }

    public bool IsItPlayerTurn(int index)
    {
        if (waitingForNextTurn)
        { 
            return false;
        }

        return index == currentPlayerIndex;
    }

    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void TriggerChangeTurn()
    {
        waitingForNextTurn = true;
    }

    public void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 2;
        }
        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 1;
        }
        Debug.Log(currentPlayerIndex + "extra"); 
    }

    public PlayerTurn GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public void ChangeCamera()
    {
        if (currentPlayerIndex == 1)
        {
            Player2Cam.gameObject.SetActive(false);
            Player1Cam.gameObject.SetActive(true);
            Debug.Log("camera 1");

        }
        else if (currentPlayerIndex == 2)
        {
            Player1Cam.gameObject.SetActive(false);
            Player2Cam.gameObject.SetActive(true);
            Debug.Log("camera 2");
        }
    }

}
