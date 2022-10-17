using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using IMPro;

public class GunManager : MonoBehaviour
{
    //Bullet
    public GameObject bullet;
    
    //Bullet Force
    public float shootForce;
    public float upwardForce;
    
    //Gun Stats
    public float timeBetweenShoting;
    public float spread;
    public float reloadTime;
    public float timeBetweenShots;

    public int maganizeSize;
    public int bulletPerTap;
    public bool allowButtonHold;

    private int bulletsLeft;
    private int bulletsShot;

    private bool shooting;
    private bool readyToShoot;
    private bool reloading;

    public int gunCurrentPlayer;

    public Transform attackPoint;
    public Transform attackPoint2;

    private void Awake()
    {
        //Make sure magazine is full
        bulletsLeft = maganizeSize;
        readyToShoot = true; 
    }
    

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        //Check if allowed to hold down buttton, if enables it causes the gun to "spar and pray"
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse1);
        else shooting = Input.GetKeyDown(KeyCode.Mouse1);

        //Shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //Set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
        {
            readyToShoot = false; //OBS THIS ONE MIGHT BE NEEDED!

            //Creates some time between shots
            Invoke("ResetShot", timeBetweenShoting);

            //Spawns the bullet/projectile
            GameObject currentBullet = Instantiate(bullet, attackPoint.transform.position, attackPoint.transform.rotation);

            //Adds forces to the bullet
            currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
            currentBullet.GetComponent<Rigidbody>().AddForce(transform.up * upwardForce);
            
            bulletsLeft--;
            bulletsShot++;
            
            // If more that one bulletsPerTap then repeat the shoot function
            if (bulletsShot < bulletPerTap && bulletsLeft > 0)
                Invoke("Shoot", timeBetweenShots);


        }

    private void ResetShot()
    {
        readyToShoot = true;
    }


    public void GunPlayerTurn()
    {
        GameObject.Find("TurnManager").GetComponent<TurnManager>().currentPlayerIndex = gunCurrentPlayer;
    }
    
}
