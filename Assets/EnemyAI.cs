using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAI : MonoBehaviour
{
    public float enemyMoveSpeed= 1f;
    public float enemyDamage=10f;
    public float enemyHp=1f;
    public float imunity;
    public GameObject Player;
    public Transform PlayerPos;
    double angleToPlayer;
    Vector2 PlayerVec;
    Vector2 EnemyVec;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("player");
        PlayerPos=Player.transform;
        //angleToPlayer= Vector2.SignedAngle(new Vector2(transform.position.x, transform.position.y),new Vector2(PlayerPos.position.x,PlayerPos.position.y));
    }

    // Update is called once per frame
    void Update()
    { 
        angleToPlayer = Mathf.Atan2(PlayerPos.transform.position.y-transform.position.y,PlayerPos.transform.position.x-transform.position.x); // angle to player in radians

        transform.position += new Vector3((float)(Math.Cos(angleToPlayer))*enemyMoveSpeed*Time.deltaTime,(float)(Math.Sin(angleToPlayer))*enemyMoveSpeed*Time.deltaTime,0); // move towards player 
        transform.eulerAngles=new Vector3(0,0,0);

        if(enemyHp <= 0){
            Destroy(gameObject);
        }
    }   


    public double DegToRad(float angle){ //simple function to convert from degrees to radians
    
        return Math.PI * angle / 180.0;
    }
    public double RadToDeg(float angle){ //simple function to convert from radians to degrees
        return angle* (180/Math.PI);
    } 
}
