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
        print("hi");
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

        immunity=-1;
        enemy = collider.gameObject;
        enemyScript = enemy.GetComponent<EnemyAI>();
        if( collider.gameObject.tag == "EnemyOne"&& immunity < 0){
            enemyScript.enemyHp -= dmg;
            immunity= enemyScript.immunity;
            pierce -=1;

        } else {
            immunity -= Time.deltaTime;
        }
    }
}
