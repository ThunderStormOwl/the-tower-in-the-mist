using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedRoomScript : MonoBehaviour{
    long resourceCost;
    TowerScript tower;
    [SerializeField]
    GameObject myUI;
    [SerializeField]
    GameObject invisibleButton;
    
    public void Initialize(int builtRoomsLength, TowerScript t){
        ReCalculateResources(builtRoomsLength);
        tower = t;
    }

    public void ClearMe() => tower.BuildNewRoom(0, gameObject);

    public long getResourceCost() => resourceCost;

    public void ReCalculateResources(int builtRoomsLength) => resourceCost = (long)Mathf.Pow(30, 0.3f * builtRoomsLength);

    public void ShowUI(){
        myUI.SetActive(true);
        invisibleButton.SetActive(false);
        tower.RoomUIOn(gameObject);
    }
    public void HideUI(){
        myUI.SetActive(false);
        invisibleButton.SetActive(true);
    }
}
