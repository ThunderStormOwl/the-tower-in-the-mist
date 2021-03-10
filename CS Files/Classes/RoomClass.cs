using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomClass : MonoBehaviour{
    [SerializeField]
    GameObject buildButton;
    [SerializeField]
    GameObject invisibleButton;
    void Start(){
        
    }

    void Update(){
        
    }

    public void ShowUI(){
        buildButton.SetActive(true);
        invisibleButton.SetActive(false);
    }
    public void HideUI(){
        buildButton.SetActive(false);
        invisibleButton.SetActive(true);
    }
}
