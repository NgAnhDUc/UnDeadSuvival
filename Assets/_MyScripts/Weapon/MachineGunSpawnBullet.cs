using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MachineGunSpawnBullet : Spawner
{
    [SerializeField] protected string bulletName;
    private void Reset()
    {
        bulletName = "MachineGunBullet";
        this.Refab = Resources.Load<GameObject>(bulletName);
        this.Parent = GameObject.Find("Bullet Clone");
    }

    private void Start()
    {
        if (Refab.GetComponent<BulletStatus>() != null)
        {
            spawnTime = Refab.GetComponent<BulletStatus>().reloadTime;
        }
        else
        {
            Debug.LogError("Refab GameObject is missing BulletStatus component");
        }
    }
    private void Update()
    {
        this.Timer();
        this.positionSpawn = transform.position;
        if (Input.GetAxis("Fire1") == 0) return;
        if (!PhotonNetwork.InRoom)
        {
            this.SpawnRefabsInTimer();
        }
        if (this.photonView.ViewID != 0 && this.photonView.IsMine)
            this.SpawnRefabsInTimer();

    }
}