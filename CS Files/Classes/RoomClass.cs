using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomClass : MonoBehaviour
{
    [SerializeField]
    GameObject myUI;
    [SerializeField]
    GameObject invisibleButton;

    protected TowerScript tower;
    protected int roomType;

    public void Initialize(TowerScript t)
    {
        tower = t;
    }

    public void ShowUI()
    {
        myUI.SetActive(true);
        invisibleButton.SetActive(false);
        tower.RoomUIOn(gameObject);
    }
    public void HideUI()
    {
        myUI.SetActive(false);
        invisibleButton.SetActive(true);
    }

    protected void SetRoomType(int type)
    {
        roomType = type;
    }

    public int GetRoomType()
    {
        return roomType;
    }
}
