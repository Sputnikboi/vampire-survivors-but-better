using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerScript : MonoBehaviour
{
    //remember public variables can only be changed in the unity editor

    //player variables
    public int hpMax=10;
    float hp = 10;
    float posX=1f, posY=1f; //floats that discribe the location of the player
    public float movespeedX=5f, movespeedY=5f; //floats that determine the speed of the player
    float level=1;
    float exp=0;
    float expToLvl = 100;
    public GameObject healthBar;

    //cam variables
    public int camMode= 0; //dictates the mode of the camera
    float camX,camY; //current locations of the camera
    public Transform Cam; //the camera transform
    public float panStrengthBase=10.0f; // the pan strength higher = higher pan strength remember its also dependant on frame rate
    float panStrength; //used in code
    //public float camSize=1;


    void Start()
    {
        healthBar = GameObject.Find("foreground");
        //resets the camera position on game start kinda works
        Cam = GameObject.Find("Main Camera").transform;
        camX=transform.position.x; 
        camY=transform.position.y;
        Cam.position = new Vector3(camX, camY, -10);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){ //basic movement code dependent on delta time
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ){ // check to see if the player is moving diagonal and if they are reduce movespeed by sqrt(2)
                posY+=(movespeedY*Time.deltaTime)/(float)(Math.Sqrt(2f));
            } else{
                posY+=movespeedY*Time.deltaTime;
            }
        }
        if(Input.GetKey(KeyCode.S)){ //same as above
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ){
                posY-=(movespeedY*Time.deltaTime)/(float)(Math.Sqrt(2f));
            } else{
                posY-=movespeedY*Time.deltaTime;
            }
           
        }
        if(Input.GetKey(KeyCode.A)){ //same as above
            if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) ){
                posX-=(movespeedX*Time.deltaTime)/(float)(Math.Sqrt(2f));
            } else{
                posX-=movespeedX*Time.deltaTime;
            }
            
        }
        if(Input.GetKey(KeyCode.D)){ //same as above
            if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) ){
                posX+=(movespeedX*Time.deltaTime)/(float)(Math.Sqrt(2f));
            } else{
                posX+=movespeedX*Time.deltaTime;
            }
        }
        //transform.GetComponent<Rigidbody2D>().velocity = new Vector2(movespeedx*Time.deltaTime/(float)(Math.Sqrt(2f)),movespeedx*Time.deltaTime/(float)(Math.Sqrt(2f)));
        transform.position = new Vector3(posX,posY,10); // updates the player position based on changes to posX and posY, z value seems to change the view order of objects
        transform.eulerAngles=new Vector3(0,0,0);

        //Exp handling
        if(exp > expToLvl){
            LevelUp();
        }


        void LevelUp() { //function that runs on level up
            exp-=expToLvl;
            level++;
            if(level <10){ //scales the exp requirment 
                expToLvl+=10;
            } else if(level < 20){
                expToLvl+=20;
            } else {
                expToLvl+=35;
            }
        }



        //camera code cause unity bad
        if(camMode==0){ //fixed camera mode can be changed through the camMode setting
            camX= transform.position.x;
            camY= transform.position.y;
        }

        if(camMode==1){ //paning camera mode needs tuning before final version
            if(panStrengthBase*Time.deltaTime<0.2f){ //code to make pan strength dependant on deltatime to prevent inconcistency through inconsistant frame rate 
                panStrength=1-(panStrengthBase*Time.deltaTime); //most of the time
            } else{
                panStrength=0.2f; //in case of low framerate
            }
            camX-= panStrength*(camX-transform.position.x); //updates cam location based on calculated panstrength
            camY-= panStrength*(camY-transform.position.y);
        }


        Cam.position = new Vector3(camX,camY,-10); //updates cam pos through camX and camY, cam seems to break if z is changed too much
        //Cam.localScale = new Vector3(camSize,camSize,camSize);

        //Health bar
        healthBar.GetComponent<Image>().fillAmount = hp/hpMax;

        //debug


    }

    //collisions dectections
    void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.tag == "EnemyOne")
        {
            hp = hp - 1 * Time.deltaTime;
        }
    }



    public double DegToRad(float angle) //simple function to convert from degrees to radians
    {
        return Math.PI*angle / 180.0;
    }
    public double RadToDeg(float angle){ //simple function to convert from radians to degrees
        return angle* (180/Math.PI);
    } 
}
