using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform[] spawnPositions;
    public Transform Player;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            int randomSpawn= Random.Range(0,spawnPositions.Length);
            Instantiate(enemies[0],spawnPositions[randomSpawn].position,transform.rotation);
        }


        
        spawnPositions[0].transform.position = new Vector3(Player.transform.position.x+15f,Player.transform.position.y+7f,8);
        spawnPositions[1].transform.position = new Vector3(Player.transform.position.x-15f,Player.transform.position.y+7f,8);
        spawnPositions[2].transform.position = new Vector3(Player.transform.position.x+15f,Player.transform.position.y-7f,8);
        spawnPositions[3].transform.position = new Vector3(Player.transform.position.x-15f,Player.transform.position.y-7f,8);
        spawnPositions[4].transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y+7f,8);
        spawnPositions[5].transform.position = new Vector3(Player.transform.position.x+15f,Player.transform.position.y,8);
        spawnPositions[6].transform.position = new Vector3(Player.transform.position.x-15f,Player.transform.position.y,8);
        spawnPositions[7].transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y-7f,8);
        spawnPositions[8].transform.position = new Vector3(Player.transform.position.x-7.5f,Player.transform.position.y-7f,8);
        spawnPositions[9].transform.position = new Vector3(Player.transform.position.x+7.5f,Player.transform.position.y-7f,8);
        spawnPositions[10].transform.position = new Vector3(Player.transform.position.x-7.5f,Player.transform.position.y+7f,8);
        spawnPositions[11].transform.position = new Vector3(Player.transform.position.x+7.5f,Player.transform.position.y+7f,8);

    }
}
