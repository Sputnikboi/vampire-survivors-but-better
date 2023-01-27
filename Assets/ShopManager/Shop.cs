using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ItemManager", order = 1)]
public class Shop : MonoBehaviour {

    // define variables
    public int tempItemId;
    public int itemAmount = 1;
    private static GameObject _canvas;
    private static GameObject _healthbar;
    private static GameObject _buttonLeft;
    private static GameObject _buttonMid;
    private static GameObject _buttonRight;
    private string ItemId = "";
    
    // Start is called before the first frame update
    public void Start()
    {
        _buttonLeft = GameObject.Find("Button(1)");
        _buttonMid = GameObject.Find("Button(2)");
        _buttonRight = GameObject.Find("Button(3)");
        _healthbar = GameObject.Find("background");
        _canvas = GameObject.Find("Scroll View");
        _canvas.SetActive(false);
        _healthbar.SetActive(true);
    }

    
    
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            ToggleShop();
            InitializeItem();
        }
    }
    void InitializeItem(){
        //initialize item
        tempItemId = Random.Range(0, itemAmount+1);

        ItemId = "Item" + tempItemId + "";
        
        //Get ItemID from item list
        
        //Add Values from List to AddItem Script
        
        //Make sure that you dont chose between same items.
        
        //show shop

        //_buttonLeft.AddComponent<>()
    }



    public static void ToggleShop(){
        // show shop if inactive and vice versa
        _canvas.SetActive(!_canvas.activeSelf);
        //_healthbar.enabled = true;
        if (_healthbar.activeSelf)
        {
            Time.timeScale = 0;
            _healthbar.SetActive(false);
        } else if (!_healthbar.activeSelf)
        {
            Time.timeScale = 1;
            _healthbar.SetActive(true);
        }
    }

}
