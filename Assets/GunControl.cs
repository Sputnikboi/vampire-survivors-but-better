using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunControl : MonoBehaviour
{   
    public GameObject Bullet;
    public GameObject Laser;
    public Transform PlayerPos;
    public float dmg;
    public float atkSpd;
    double curCooldown = 0;
    public float bulletCount;
    public float bulletSize;
    public float bulletSpeed;
    public float pierce;
    public float lifespan;
    public int mode;
    public double id;
    Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        Laser = GameObject.Find("Laser");
        mousePos=Input.mousePosition;
        dmg = 1;
        atkSpd = 2;
        bulletCount = 1;
        bulletSize = 5;
        bulletSpeed = 20;
        pierce = 1;
        lifespan = 4;
        mode =1;

    }

    // Update is called once per frame
    void Update()
    {
        if (mode == 1 && Laser.activeSelf)
        {
            Laser.SetActive(false);
        }
        
        mousePos=Input.mousePosition;
        if(Input.GetMouseButton(0)){
            if(mode==1&& curCooldown<0){
                curCooldown = 1/atkSpd;
                Instantiate(Bullet,PlayerPos.position,transform.rotation);
                id++;
            } else {
                curCooldown -= Time.deltaTime;
            } 
        }else if(mode == 2){
            print("fuck you");
        } else {
                curCooldown -= Time.deltaTime;
        } 
       
        
        
        
    }

    //Code to get the angle to the cursor from the player: angleToCursor=Mathf.Atan2(mousePos[1]-Screen.height/2,mousePos[0]-Screen.width/2);   //angle to cursor works
}
