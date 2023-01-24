using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletBehavior : MonoBehaviour
{   
    public GameObject Gun;
    private GunControl gunScript;
    float dmg;
    float bulletSize;
    float bulletSpeed;
    float pierce;
    double angleToCursor;
    Vector2 Rotation;
    Vector3 mousePos;
    
    // Start is called before the first frame update
    void Start()
    {   
        Gun = GameObject.Find("gun");
        mousePos=Input.mousePosition;
        gunScript = Gun.GetComponent<GunControl>();
        dmg= gunScript.dmg;
        bulletSize=gunScript.bulletSize;
        bulletSpeed=gunScript.bulletSpeed;
        pierce= gunScript.pierce;
        angleToCursor=Mathf.Atan2(mousePos[1]-Screen.height/2,mousePos[0]-Screen.width/2);
        transform.localScale=new Vector3(bulletSize*0.1f,bulletSize*0.1f,1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3((float)(Math.Cos(angleToCursor))*bulletSpeed*Time.deltaTime,(float)(Math.Sin(angleToCursor))*bulletSpeed*Time.deltaTime,0);
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        
    }
}
