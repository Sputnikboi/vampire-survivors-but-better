using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem2 : MonoBehaviour
{
    //Item information
    public string itemName = "";
    
    //Tweaking values from GunControl
    //damage of individual bullets
    private float _dmg;
    //How many times per second, you can shoot
    private float _atkSpd;
    //How many bullets spawn
    private float _bulletCount;
    //Size of bullet
    private float _bulletSize;
    //speed of bullet
    private float _bulletSpeed;
    //How many enemies, you can hit at a time
    private float _pierce;
    //Bullet lifespan
    private float _lifespan;
    //WIP - What kind of mode your gun is
    private int _mode;
    
    //Tweaking values from PlayerScripts
    private int _hpMax;
    private float _movespeedX, _movespeedY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
