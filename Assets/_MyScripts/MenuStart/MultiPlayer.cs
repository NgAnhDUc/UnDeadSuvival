using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class MultiPlayer : MonoBehaviour
{
    [SerializeField] string stateServer;
    [SerializeField] GameObject inputForm;
    [SerializeField] GameObject playForm;


    private void Start()
    {
    }
    void Update()
    {
        this.stateServer = PhotonNetwork.NetworkClientState.ToString();
        Debug.Log(stateServer);
    }

    public void clickMultiPlayer()
    {
        inputForm.SetActive(true);
        playForm.SetActive(false);
    }
}