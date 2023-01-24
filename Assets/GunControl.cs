using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunControl : MonoBehaviour
{   
    public GameObject Bullet;
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
    public double angleToCursor;
    Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        mousePos=Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {   
        
        mousePos=Input.mousePosition;
        if(Input.GetMouseButtonDown(0) && curCooldown<0){ //same as above
            curCooldown = 1/atkSpd;
            Instantiate(Bullet,PlayerPos.position,transform.rotation);
        } else {
            curCooldown -= Time.deltaTime;
        }
        
        
    }

    //Code to get the angle to the cursor from the player: angleToCursor=Mathf.Atan2(mousePos[1]-Screen.height/2,mousePos[0]-Screen.width/2);   //angle to cursor works
}
