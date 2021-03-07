using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicRoomScript : MonoBehaviour{

    protected long resourceCost;
    protected TowerScript tower;
    
    public void Initialize(int builtRoomsLength, TowerScript t){

        resourceCost = (long)Mathf.Pow(30, builtRoomsLength);
        tower = t;

    }

    public void BuildMe(){
        tower.BuildNewRoom(gameObject);
    }

    public long getResourceCost(){
        return resourceCost;
    }

    public void ReCalculateResources(int builtRoomsLength){
        resourceCost = (long)Mathf.Pow(30, builtRoomsLength);
    }

}
