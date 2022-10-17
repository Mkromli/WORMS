using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float damage;
    public float lifeSpawn;
    public float bulletSize;
    public float areoOfEffect;

    //public PlayerHealth script;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestoryAfterSeconds();


    }

    private void DestoryAfterSeconds()
    {
        Destroy(gameObject, lifeSpawn);
    }

    // HEY BOI PUT THIS IN THE PICKUP SCRIPT LATER
    public void SizeOfTheBullet()
    {
        gameObject.transform.localScale = gameObject.transform.localScale * bulletSize;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().health -= damage;
            Debug.Log("CORGI HURT");
            Destroy(gameObject);
        }
        SizeOfTheBullet();
        
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        
    }*/

}
