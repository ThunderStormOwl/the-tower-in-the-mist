using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TowerScript : MonoBehaviour{
    
    [SerializeField]
    GameObject emptyRoomPrefab;
    
    int maxRooms = 13 * 4;
    
    void Start(){

        SetUpTower();
        
    }

    void SetUpTower(){

        int counter = 0;

        double curX = 1.2;
        double curY = 0.8;

        Vector3 pos = new Vector3((float)curX, (float)curY, 0);
        
        GameObject newRoom;

        for(int i = 0; i < maxRooms; i++){
            if(counter >= 4){
                curY += 1.2;
                curX = 1.2;
                pos.x = (float)curX;
                pos.y = (float)curY;
                counter = 0;
            }
            
            if(counter == 2)
                curX += 3.4;
            else if(counter != 0)
                curX += 2.1;
            pos.x = (float)curX;

            newRoom = Instantiate(emptyRoomPrefab, pos, Quaternion.identity) as GameObject;

            counter += 1;
        }
    }

    void Update(){
        
    }
}
