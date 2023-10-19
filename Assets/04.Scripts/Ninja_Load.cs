using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_Load : MonoBehaviour
{
    public GameObject item_scroll;
    public GameObject ui_manager;


    public void ScrollOn()
    {
        ui_manager.GetComponent<LoadSceneManager>().ItemScrollShow();
    }
    
}
