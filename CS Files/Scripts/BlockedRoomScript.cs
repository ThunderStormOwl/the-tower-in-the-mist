using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedRoomScript : MonoBehaviour{
    long resourceCost;
    TowerScript tower;
    
    public void Initialize(int builtRoomsLength, TowerScript t){
        ReCalculateResources(builtRoomsLength);
        tower = t;
    }

    public void BuildMe() => tower.BuildNewRoom(gameObject);

    public long getResourceCost() => resourceCost;

    public void ReCalculateResources(int builtRoomsLength) => resourceCost = (long)Mathf.Pow(30, 0.3f * builtRoomsLength);
}
