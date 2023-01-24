using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ItemManager", order = 1)]
public class ItemManager : ScriptableObject {

    // define variables
    public int tempItemId;
    public int itemAmount = 1;
    // Start is called before the first frame update


    ItemManager(){
        ShowShop();
    }
    void InitializeItem(){
        //initialize item
        tempItemId = Random.Range(0, itemAmount);
        GenerateItem(tempItemId);

        //show shop

    }

    void GenerateItem(int tempItemId){
        //generate item

        switch (tempItemId){
            case 0:
                //generate item 0
               // var item1 = gameObject.AddComponent(typeof(Item1)) as Item1);
                break;
            case 1:
                //generate item 1
                break;
            default:
                //generate item 0
                break;
        }
        


    }

    public static void ShowShop(){

        //show shop
        
        

    }

}
