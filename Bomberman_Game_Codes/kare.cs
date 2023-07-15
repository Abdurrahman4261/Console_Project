using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class kare : MonoBehaviourPunCallbacks
{
    PhotonView pv;
    [SerializeField]
    private void Awake() {
        pv=GetComponent<PhotonView>();
        Vector2 offset = Random.insideUnitCircle*3f;
        Vector3 position  = new Vector3(-10,2 + offset.y,0);
        if(pv.IsMine){
            PhotonNetwork.Instantiate("aa",position,Quaternion.identity);
        }
    }
}
