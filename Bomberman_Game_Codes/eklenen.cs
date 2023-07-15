using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;
public class eklenen : MonoBehaviourPunCallbacks
{
    // public TextMeshProUGUI oyuncu1_ad;
    // public TextMeshProUGUI oyuncu2_ad;
    // public TextMeshProUGUI oyuncubekleniyor;

    void Start()
    {
        
    }
    // public void oda_giris(){
    
    //     if(PhotonNetwork.InLobby){
    //         PhotonNetwork.JoinOrCreateRoom ("oda", new RoomOptions {MaxPlayers = 4 , IsOpen = true , IsVisible = true},TypedLobby.Default);
    //         Vector3 pos = new Vector3(11,8,0);
    //         Vector3 pos2 = new Vector3(-15,8,0);
    //     }
    // }
    // public override void OnJoinedRoom()
    // {
    //     Debug.Log("odaya girildi");
    //     string oyuncuad = Random.Range(1,100)+" Misafir";
    //     GameObject nesne1 = PhotonNetwork.Instantiate("multi_1",Vector3.zero,Quaternion.identity,0,null);
    //     nesne1.GetComponent<PhotonView>().Owner.NickName = oyuncuad;
    //     InvokeRepeating("isimbilgikontrol",0,1f);
       
    // }
    // public override void OnPlayerLeftRoom(Player otherPlayer){
    //     InvokeRepeating("isimbilgikontrol",0,1f);
    // }
    // void isimbilgikontrol(){
        
    //     if(PhotonNetwork.PlayerList.Length==2){
    //         oyuncubekleniyor.text="";
    //         oyuncu1_ad.text=PhotonNetwork.PlayerList[0].NickName;
    //         oyuncu2_ad.text=PhotonNetwork.PlayerList[1].NickName;
    //         CancelInvoke("isimbilgikontrol");
    //     }
    //     else{
    //         oyuncubekleniyor.text="Oyuncu Bekleniyor";
    //         oyuncu1_ad.text=PhotonNetwork.PlayerList[0].NickName;
    //         oyuncu2_ad.text="...";
    //     }
    // }
    // void Update()
    // {
        
    // }
}

// if(PhotonNetwork.IsMasterClient==true){
        //     Debug.Log("master");
        //     GameObject nesne1 = PhotonNetwork.Instantiate("aa",pos,Quaternion.identity,0,null);
        //     Debug.Log("mas");
        // }
        // else{
        //     Debug.Log("sonradan");
        //     GameObject nesne2 = PhotonNetwork.Instantiate("aa",pos,Quaternion.identity);
        //     Debug.Log("kelek");
        // }
        //GameObject nesne1 = PhotonNetwork.Instantiate("aa",pos,Quaternion.identity);


        // if(PhotonNetwork.IsMasterClient==false){
        //     Debug.Log("sonradan");
        //     GameObject nesne1 = PhotonNetwork.Instantiate("multi_2",pos,Quaternion.identity);

        // }
        // else{
        //     Debug.Log("master");
        //     GameObject nesne2 = PhotonNetwork.Instantiate("multi_1",pos2,Quaternion.identity,0,null);
        // }