using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearedRoomScript : RoomClass{

    void Start(){}

    void Update(){}
    //if this script does not get much ore complex than this then 
    //consider moving this function to the RoomClass sccript and making it private
    public void buildRoom(int type){
        tower.BuildNewRoom(type, gameObject);
        HideUI();
    }
}
