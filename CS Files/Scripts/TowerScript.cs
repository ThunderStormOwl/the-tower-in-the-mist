using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerScript : MonoBehaviour
{
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

    [SerializeField]
    Text resourceText;

    int maxRooms = 13 * 4;
    int costPowerRoom = 100;
    int costWaterRoom = 100;
    int costFoodRoom = 100;
    int resources = 300;

    void Start()
    {
        SetUpTowerFromScratch();
        SetupRoomCosts();
    }

    void SetUpTowerFromScratch()
    {
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
        UpdateUI();

        for (int i = 0; i < maxRooms; i++)
        {
            if (counter >= 4)
            {
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

            if (counter == 2)
                curX -= 3.4;
            else if (counter != 0)
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

    void SetupRoomCosts()
    {
        int powerRoomCount = 0;
        int waterRoomCount = 0;
        int foodRoomCount = 0;
        foreach (GameObject room in builtRooms)
        {
            int roomType = room.GetComponent<RoomClass>().GetRoomType();

            switch (roomType)
            {
                case 1:
                    powerRoomCount++;
                    break;
                case 2:
                    waterRoomCount++;
                    break;
                case 3:
                    foodRoomCount++;
                    break;
            }
        }

        costPowerRoom += (int)(10.3 * powerRoomCount);
        costWaterRoom += (int)(10.3 * waterRoomCount);
        costFoodRoom += (int)(10.3 * foodRoomCount);
    }

    void Update()
    {

    }

    private void UpdateUI() { resourceText.text = "RESOURCES: " + resources; }

    public void BuildNewRoom(int type, GameObject originRoom)
    {
        GameObject newRoom = null;
        switch (type)
        {
            case 0: newRoom = Instantiate(clearedRoomPrefab, originRoom.transform.position, Quaternion.identity) as GameObject; break;
            case 1: newRoom = Instantiate(powerRoomPrefab, originRoom.transform.position, Quaternion.identity) as GameObject; break;
            case 2: newRoom = Instantiate(waterRoomPrefab, originRoom.transform.position, Quaternion.identity) as GameObject; break;
            case 3: newRoom = Instantiate(foodRoomPrefab, originRoom.transform.position, Quaternion.identity) as GameObject; break;
        }
        newRoom.transform.name = originRoom.transform.name;
        newRoom.transform.parent = originRoom.transform.parent;
        newRoom.GetComponent<RoomClass>().Initialize(this);
        if (type == 0)
            originRoom.GetComponent<BlockedRoomScript>().HideUI();
        else
            originRoom.GetComponent<RoomClass>().HideUI();

        builtRooms.Add(newRoom);
        blockedRooms.Remove(originRoom);
        Destroy(originRoom);

        foreach (GameObject room in blockedRooms)
        {
            room.GetComponent<BlockedRoomScript>().ReCalculateResources(builtRooms.Count);
        }
        SetupRoomCosts();
    }

    public void RoomUIOn(GameObject room)
    {

        if (room != roomWithUIOn && roomWithUIOn != null)
        {

            bool isBlocked = blockedRooms.Contains(roomWithUIOn);

            if (isBlocked)
                roomWithUIOn.GetComponent<BlockedRoomScript>().HideUI();
            else
                roomWithUIOn.GetComponent<RoomClass>().HideUI();
        }

        roomWithUIOn = room;
    }

    public void AddResources(){
        resources += 300;
        UpdateUI();
    }
}
