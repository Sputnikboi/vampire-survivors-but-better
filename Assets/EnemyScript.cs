using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform[] spawnPositions;
    public GameObject[] enemys;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            int randomSpawn= Random.Range(0,spawnPositions.Length);
            Instantiate(enemys[0],spawnPositions[randomSpawn].position,transform.rotation);
        }
    }
}
