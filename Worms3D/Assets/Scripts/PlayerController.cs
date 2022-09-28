using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
{
    public float RotateSpeed = 30f;
    
    public Camera cam;

    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Checks if the left mouse button is down
        {
            
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); //Takes the mouse postions and converts it into a ray
            RaycastHit hit; //Used to store the Raycast information

            if (Physics.Raycast(ray, out hit)) //If hitting something is True, it runs this code
            {
                agent.SetDestination(hit.point);
            }
        }

       /* if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
        }*/
        
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("Q was pressed");
            gameObject.GetComponent<NavMeshAgent>().enabled = false; //disables the NavMeshAgent to allow for manual turning
            transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("E was pressed");
            gameObject.GetComponent<NavMeshAgent>().enabled = false; //disables the NavMeshAgent to allow for manual turning
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
        }

    }
    
}
