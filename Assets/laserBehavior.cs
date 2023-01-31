using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class laserBehavior : MonoBehaviour
{
    public GameObject Gun;
    private GunControl gunScript;
    public GameObject PlayerObj;
    public Transform Player;
    public float dmgScaleLaser;
    float dmg;
    float bulletSize;
    float bulletSpeed;
    float pierce;
    float lifespan;
    float timeAlive;
    float atkSpd;
    double angleToCursor;
    Vector2 Rotation;
    Vector3 mousePos;
    GameObject enemy;
    private EnemyAI enemyScript;
    float immunity = 1;
    // Start is called before the first frame update
    void Start()
    {
        dmgScaleLaser = 0.33f;
        PlayerObj=GameObject.Find("player");
        Player=PlayerObj.transform;
        Gun = GameObject.Find("gun");
        mousePos=Input.mousePosition;
        gunScript = Gun.GetComponent<GunControl>();
        dmg= gunScript.dmg;
        bulletSize=gunScript.bulletSize;
        pierce= gunScript.pierce;
        lifespan=gunScript.lifespan;
        atkSpd =gunScript.atkSpd;
        bulletSpeed= gunScript.bulletSpeed;
        angleToCursor=Mathf.Atan2(mousePos[1]-Screen.height/2,mousePos[0]-Screen.width/2);
        transform.localScale=new Vector3(bulletSize*1f,bulletSize*1f,1); 
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if(gunScript.mode == 0){
            if(Input.GetMouseButton(0)){
                mousePos=Input.mousePosition;
                angleToCursor=Mathf.Atan2(mousePos[1]-Screen.height/2,mousePos[0]-Screen.width/2);
                GetComponent<SpriteRenderer>().enabled = true;
                transform.rotation = Quaternion.Euler(0,0,(float)(RadToDeg((float)(angleToCursor))+90));
                transform.position = new Vector3((float)(Math.Cos(angleToCursor))*2+Player.transform.position.x,(float)(Math.Sin(angleToCursor))*2+Player.transform.position.y,0);
                transform.localScale=new Vector3(bulletSize*0.2f,1*bulletSpeed/20,1);
            }else {
                GetComponent<SpriteRenderer>().enabled = false;
            }
        } 

    }

    void OnTriggerStay2D(Collider2D collider)
    {   
        if(collider.gameObject.tag != "Environment" && collider.gameObject != PlayerObj){
            enemy = collider.gameObject;
            enemyScript = enemy.GetComponent<EnemyAI>();
            enemyScript.TakeDamage(dmg*dmgScaleLaser,1,"fuck",atkSpd);
        }

    }

    public double RadToDeg(float angle){ //simple function to convert from radians to degrees
        return angle* (180/Math.PI);
    } 
}
