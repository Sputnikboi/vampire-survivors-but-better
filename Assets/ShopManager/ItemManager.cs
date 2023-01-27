using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ItemManager/Item")]
public class ItemManager : ScriptableObject {

    //Item information
    public string itemName = "";
    
    //Tweaking values from GunControl
    //damage of individual bullets
    public float itemDamage;
    //How many times per second, you can shoot
    public float ItemAttackSpeed;
    //How many bullets spawn
    public float ItemBulletCount;
    //Size of bullet
    public float ItemBulletSize;
    //speed of bullet
    public float ItemBulletSpeed;
    //How many enemies, you can hit at a time
    public float ItemPierce;
    //Bullet lifespan
    public float ItemLifespan;
    //WIP - What kind of mode your gun is
    public int ItemMode;
    
    //Tweaking values from PlayerScripts
    public int ItemHpMax;
    public float ItemMovespeedX, ItemMovespeedY;

    //define gameobjects
    public GameObject Gun;
    private GunControl _gunScript;
    public GameObject player;
    private PlayerScript _playerScript;
    
    public void Start()
    {
        Gun = GameObject.Find("gun");
        _gunScript = Gun.GetComponent<GunControl>();

        player = GameObject.Find("player");
        _playerScript = player.GetComponent<PlayerScript>();
        
    }

    public void BuyItem(ItemManager item)
    {
        _gunScript.dmg += itemDamage;
        _gunScript.atkSpd += ItemAttackSpeed;
        _gunScript.bulletCount += ItemBulletCount;
        _gunScript.bulletSize += ItemBulletSize;
        _gunScript.bulletSpeed += ItemBulletSpeed;
        _gunScript.pierce += ItemPierce;
        _gunScript.lifespan += ItemLifespan;
        _gunScript.mode += ItemMode;
        _playerScript.hpMax += ItemHpMax;
        _playerScript.movespeedX += ItemMovespeedX;
        _playerScript.movespeedY += ItemMovespeedY;


    }
    

}
