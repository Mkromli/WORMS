using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DeathCheck();
        
        
    }


    public void DeathCheck()
    {
        if (health <= 0)
        {
            print("Owie, good bye");
            Destroy(gameObject);
        }
    }
    
    
}