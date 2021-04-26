using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour{
    [SerializeField]
    GameObject blockedRoomPrefab;
    [SerializeField]
    GameObject clearedRoomPrefab;
    [SerializeField]
    GameObject powerRoomPrefab;
    [SerializeField]
    GameObject waterRoomPrefab;
    [SerializeField]
    GameObject foodRoomPrefab;
    
    GameObject roomWithUIOn;

    List<GameObject> blockedRooms = new List<GameObject>();
    List<GameObject> builtRooms = new List<GameObject>();
    List<GameObject> roomsPool = new List<GameObject>();
    
    int maxRooms = 13 * 4;
    
    void Start(){
        SetUpTower();
    }

    void SetUpTower(){
        int counter = 0;
        int floorCounter = 13;

        double curX = 8.8;
        double curY = 15.2;

        Vector3 pos = new Vector3((float)curX, (float)curY, 0);
        
        GameObject newRoom;
        GameObject newFloor = new GameObject();
        newFloor.name = "Floor " + floorCounter;
        newFloor.transform.SetParent(gameObject.transform);
        floorCounter--;

        for(int i = 0; i < maxRooms; i++){
            if(counter >= 4){
                curY -= 1.2;
                curX = 8.8;
                pos.x = (float)curX;
                pos.y = (float)curY;
                counter = 0;
                newFloor = new GameObject();
                newFloor.name = "Floor " + floorCounter;
                newFloor.transform.SetParent(gameObject.transform);
                floorCounter--;
            }
            
            if(counter == 2)
                curX -= 3.4;
            else if(counter != 0)
                curX -= 2.1;
            pos.x = (float)curX;

            newRoom = Instantiate(blockedRoomPrefab, pos, Quaternion.identity) as GameObject;
            newRoom.transform.SetParent(newFloor.transform);
            newRoom.GetComponent<BlockedRoomScript>().Initialize(2 + builtRooms.Count, this);
            newRoom.name = "Room " + (maxRooms - blockedRooms.Count);
            blockedRooms.Add(newRoom);
            
            counter += 1;
        }
    }

    void Update(){
        
    }

    public void BuildNewRoom(int type, GameObject originRoom){
        GameObject newRoom = null;
        switch(type){
            case 0: newRoom = Instantiate(clearedRoomPrefab, originRoom.transform.position, Quaternion.identity) as GameObject; break;
            case 1: newRoom = Instantiate(powerRoomPrefab, originRoom.transform.position, Quaternion.identity) as GameObject; break;
            case 2: newRoom = Instantiate(waterRoomPrefab, originRoom.transform.position, Quaternion.identity) as GameObject; break;
            case 3: newRoom = Instantiate(foodRoomPrefab, originRoom.transform.position, Quaternion.identity) as GameObject; break;
        }
        newRoom.transform.name = originRoom.transform.name;
        newRoom.transform.parent = originRoom.transform.parent;
        newRoom.GetComponent<RoomClass>().Initialize(this);
        if(type == 0)
            originRoom.GetComponent<BlockedRoomScript>().HideUI();
        else
            originRoom.GetComponent<RoomClass>().HideUI();

        builtRooms.Add(newRoom);
        blockedRooms.Remove(originRoom);
        Destroy(originRoom);

        foreach(GameObject o in blockedRooms){
            o.GetComponent<BlockedRoomScript>().ReCalculateResources(builtRooms.Count);
        }
    }

    public void RoomUIOn(GameObject room){

        if(room != roomWithUIOn && roomWithUIOn != null){

            bool isBlocked = blockedRooms.Contains(roomWithUIOn);

            if(isBlocked)
                roomWithUIOn.GetComponent<BlockedRoomScript>().HideUI();
            else
                roomWithUIOn.GetComponent<RoomClass>().HideUI();
        }

        roomWithUIOn = room;
    }
}
