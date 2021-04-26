using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearedRoomScript : RoomClass{

    void Start(){}

    void Update(){}
    
    public void buildRoom(int type){
        tower.BuildNewRoom(type, gameObject);
        HideUI();
    }
}
