using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunControl : MonoBehaviour
{   
    public Transform PlayerPos;
    public float dmg;
    public float atkSpd;
    public float bulletCount;
    public float bulletSize;
    public float bulletSpeed;
    public float pierce;
    public int mode;
    double angleToCursor;
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
        angleToCursor=Mathf.Atan2(mousePos[1]-Screen.height/2,mousePos[0]-Screen.width/2);//angle to cursor works 

        //transform.rotation = new Vector3()
    }
}
