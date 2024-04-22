using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class SpawnPlayerCard :Spawner
{
    public List<GameObject> posList;
    void Awake()
    {
        this.Refab = Resources.Load<GameObject>("Player Card");

        this.parentViewID = photonView.ViewID;
    }
    protected void AddPlayerToGrid()
    {
        this.Parent = gameObject;
        this.positionSpawn = Vector3.zero;
        if (this.photonView.ViewID == 0) return;
        
        this.SpawnRefabs();
    }

    //Pun CallBacks
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        AddPlayerToGrid();
    }
}
