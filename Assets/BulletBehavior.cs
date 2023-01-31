using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletBehavior : MonoBehaviour
{   
    public GameObject Gun;
    public GameObject Player;
    private GunControl gunScript;
    string id;
    float dmg;
    float bulletSize;
    float bulletSpeed;
    float pierce;
    float lifespan;
    float timeAlive;
    double angleToCursor;
    Vector2 Rotation;
    Vector3 mousePos;
    GameObject enemy;
    private EnemyAI enemyScript;
    float immunity;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("player");
        Gun = GameObject.Find("gun");
        mousePos=Input.mousePosition;
        gunScript = Gun.GetComponent<GunControl>();
        dmg= gunScript.dmg;
        bulletSize=gunScript.bulletSize;
        bulletSpeed=gunScript.bulletSpeed;
        pierce= gunScript.pierce;
        lifespan=gunScript.lifespan;
        angleToCursor=Mathf.Atan2(mousePos[1]-Screen.height/2,mousePos[0]-Screen.width/2);
        transform.localScale=new Vector3(bulletSize*0.1f,bulletSize*0.1f,1);
        id = ""+gunScript.id;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3((float)(Math.Cos(angleToCursor))*bulletSpeed*Time.deltaTime,(float)(Math.Sin(angleToCursor))*bulletSpeed*Time.deltaTime,0);
        if(pierce <=0 || lifespan < 0){
            Destroy(gameObject);
        }

        lifespan -= Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag != "Environment" && collider.gameObject != Player)
        {
            enemy = collider.gameObject;
            enemyScript = enemy.GetComponent<EnemyAI>();
            if(enemyScript.TakeDamage(dmg,0,id,gunScript.atkSpd)==true){
                pierce--;
            }
        }


    }
}
