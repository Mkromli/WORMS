using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
{
    public float RotateSpeed = 30f;
    
    public Camera cam;
    public Camera cam2;

    public NavMeshAgent agent;
    
    public int maxMoves;
    public int movesUsed;

    //OBS NEED TO MAKE SURE THE SWITCHING OF CAMERAS HAPPEN, CHANGE THE CAM VALUE TO WORK WITH CAM AND CAM 2. NEEDS REFERENCE FROM TURNMANAGER, "currentPlayerIndex"

    // Update is called once per frame
    void Update()
    {
        if (TurnManager.GetInstance().currentPlayerIndex == 1)
        {
            agent = GameObject.Find("CorgiTank").GetComponent<NavMeshAgent>();
        }
        else if (TurnManager.GetInstance().currentPlayerIndex == 2)
        {
            agent = GameObject.Find("CorgiTank 2").GetComponent<NavMeshAgent>();
        }

        


        
        if (Input.GetMouseButtonDown(0)) //Checks if the left mouse button is down
        {
            
            agent.enabled = true;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); //Takes the mouse postions and converts it into a ray
            RaycastHit hit; //Used to store the Raycast information

            if (Physics.Raycast(ray, out hit)) //If hitting something is True, it runs this code
            {
                agent.SetDestination(hit.point);
            }

            movesUsed++;

           if (movesUsed == maxMoves) //Changes turn ones all moves are done
           {
               TurnManager.GetInstance().ChangeTurn();
               //agent.ResetPath();
               movesUsed = 0;
           }
            print(movesUsed);
            
            
            
            
        }
        


       /* if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
        }*/
        
        // THS SHIT DOES NOT WORK ANYMORE, NEEEDS A REFERENCE TO THE CURRENT PLAYER NAV MESH AGENT
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("Q was pressed");
            agent.enabled = false; //disables the NavMeshAgent to allow for manual turning
            transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("E was pressed");
            agent.enabled = false; //disables the NavMeshAgent to allow for manual turning
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
        }

    }
    
}
