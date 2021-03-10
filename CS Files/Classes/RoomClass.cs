using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomClass : MonoBehaviour{
    [SerializeField]
    GameObject buildButton;
    [SerializeField]
    GameObject invisibleButton;

    TowerScript tower;

    public void Initialize(TowerScript t){
        tower = t;
    }

    public void ShowUI(){
        buildButton.SetActive(true);
        invisibleButton.SetActive(false);
        tower.RoomUIOn(gameObject);
    }
    public void HideUI(){
        buildButton.SetActive(false);
        invisibleButton.SetActive(true);
    }
}
