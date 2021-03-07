using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour{
    [SerializeField]
    GameObject blockedRoomPrefab;
    [SerializeField]
    GameObject clearedRoomPrefab;

    public List<GameObject> blockedRooms = new List<GameObject>();
    List<GameObject> builtRooms = new List<GameObject>();
    List<GameObject> roomsPool = new List<GameObject>();
    
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

            newRoom = Instantiate(blockedRoomPrefab, pos, Quaternion.identity) as GameObject;
            newRoom.GetComponent<BlockedRoomScript>().Initialize(2 + builtRooms.Count, this);
            blockedRooms.Add(newRoom);

            counter += 1;
        }
    }

    void Update(){
        
    }

    public void BuildNewRoom(GameObject room){
        GameObject newRoom = Instantiate(clearedRoomPrefab, room.transform.position, Quaternion.identity) as GameObject;

        builtRooms.Add(newRoom);
        blockedRooms.Remove(room);
        Destroy(room);

        foreach(GameObject o in blockedRooms){
            o.GetComponent<BlockedRoomScript>().ReCalculateResources(builtRooms.Count);
        }

        print(blockedRooms[0].GetComponent<BlockedRoomScript>().getResourceCost());
    }
}
