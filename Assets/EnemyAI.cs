using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAI : MonoBehaviour
{
    public float enemyMoveSpeed= 1f;
    public float enemyDamage=10f;
    public float enemyHp=10f;
    public Transform PlayerPos;
    double angleToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        angleToPlayer= Vector2.SignedAngle(new Vector2(transform.position.x, transform.position.y),new Vector2(PlayerPos.position.x,PlayerPos.position.y));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //angleToPlayer= Vector2.SignedAngle;
        //print(angleToPlayer);

        //transform.position -= new Vector3((float)(Math.Cos(angleToPlayer))*enemyMoveSpeed,transform.position.x-(float)(Math.Sin(angleToPlayer))*enemyMoveSpeed,0);
    }   


    public double DegToRad(float angle) //simple function to convert from degrees to radians
    {
        return Math.PI * angle / 180.0;
    }
}
