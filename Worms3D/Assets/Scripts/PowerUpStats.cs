using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpStats : MonoBehaviour
{
    public BulletBehavior script;

    public float damageForBullet;
    public float lifeTiimeForBullet;
    public float scaleForBullet;
    

    //calls for what is in the GunManger script. Script 2 is the name, REMEBER TO PULL THE OBEJCT OR THE PREFAB INTO IT
    public GunManager script2;

    public int magazineSizeForGun;
    //public int maganizeSize;
    //public int bulletPerTap;
    // public float timeBetweenShoting;
    //public float shootForce;
    //public float upwardForce;

    
    // Start is called before the first frame update


    private void Awake()
    {
        damageForBullet = script.damage;
        lifeTiimeForBullet = script.lifeSpawn;
        scaleForBullet = script.bulletSize;
        
        

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
