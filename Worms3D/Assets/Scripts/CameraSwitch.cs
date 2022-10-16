using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player1Cam;
    public GameObject Player2Cam;
    public int currentPlayerTurn;

    // currentPlayerIndex is the current players turn


    void Start()
    {
        /*GameObject TurnManager = GameObject.Find("TurnManger");
        TurnManager turnManagerScript = TurnManager.GetComponent<TurnManager>();
        turnManagerScript.currentPlayerIndex = currentPlayerTurn;
        currentPlayerTurn = turnManagerScript.currentPlayerIndex;*/
    }

    // Update is called once per frame
    void Update()
    {


        if (TurnManager.GetInstance().currentPlayerIndex == 1)
        {
            Player1Cam = GameObject.Find("PlayerOneCameraPoint").GetComponent<Transform>();
        }
        else if (TurnManager.GetInstance().currentPlayerIndex == 2)
        {
            Player2Cam = GameObject.Find("PlayerTwoCameraPoint ").GetComponent<UnityEngine.AI.NavMeshAgent>();
        }

        changeCamera();





    }


    public void changeCamera()
    {
        if (currentPlayerTurn == 1)
        {
            Debug.Log("Player 1 camera");
        }

        if (currentPlayerTurn == 2)
        {
            Debug.Log("Player 2 camera");
        }
    }


}
