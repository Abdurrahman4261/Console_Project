using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System;
using Random=UnityEngine.Random;
public class fire_collision : MonoBehaviourPunCallbacks
{
    public static int yikilx2=0,yikily2=0,carpisma=1;
    
    [PunRPC]
    public void  OnTriggerEnter2D(Collider2D duvar2) {
        if(duvar2.gameObject.tag == "yikilan"){
            carpisma=1;
            int yikilx =(int)(duvar2.gameObject.transform.position.x);
            int yikily =(int)(duvar2.gameObject.transform.position.y);
            if(Bomb_Asil.artik_yikilsol==1 || Bomb_Asil.artik_yikilsag==1) {
                yikilx2 = yikilx;
            }
            if(Bomb_Asil.artik_yikilasagi==1 || Bomb_Asil.artik_yikilyukari==1) {
                yikily2 =yikily;
            }
            for (var i = 1; i <= carpisma_photon.ates_boyut; i++){
            
                Debug.Log("yikilx:"+yikilx);
                if(Bomb_Asil.bomba_all_pos.x+i==yikilx){
                    Debug.Log("yikilx:"+yikilx);
                    if(yikilx== Bomb_Asil.yikilan_sag_pos.x && Bomb_Asil.artik_yikilsag==1){
                        Bomb_Asil.artik_yikilsag=0;
                        PhotonNetwork.Destroy(duvar2.gameObject);
                        PhotonNetwork.Instantiate("yikil_online",duvar2.gameObject.transform.position,Quaternion.identity);
                        var pos = duvar2.gameObject.transform.position; 
                        GameObject.FindWithTag("player2").GetComponent<PhotonView>().RPC("yikilacakobje",RpcTarget.All,pos);
                        StartCoroutine(yikilan_yoket());
                        int random_sayi=random_create();
                        photonView.RPC("gift_create",RpcTarget.All,duvar2.gameObject.transform.position,random_sayi);
                    }
                }
            }
            for (var i = 1; i <= carpisma_photon.ates_boyut; i++){

                if(Bomb_Asil.bomba_all_pos.x-i==yikilx){
                    if(yikilx == Bomb_Asil.yikilan_sol_pos.x && Bomb_Asil.artik_yikilsol==1){
                        Bomb_Asil.artik_yikilsol=0;
                        PhotonNetwork.Destroy(duvar2.gameObject);
                        PhotonNetwork.Instantiate("yikil_online",duvar2.gameObject.transform.position,Quaternion.identity);
                        var pos = duvar2.gameObject.transform.position; 
                        GameObject.FindWithTag("player2").GetComponent<PhotonView>().RPC("yikilacakobje",RpcTarget.All,pos);
                        StartCoroutine(yikilan_yoket());
                        int random_sayi=random_create();
                        photonView.RPC("gift_create",RpcTarget.All,duvar2.gameObject.transform.position,random_sayi);
                    }
                }
            }
            for (var i = 1; i <= carpisma_photon.ates_boyut; i++){
                if(Bomb_Asil.bomba_all_pos.y+i==yikily){
                    if(yikily== Bomb_Asil.yikilan_yukari_pos.y && Bomb_Asil.artik_yikilyukari==1){
                        Bomb_Asil.artik_yikilyukari=0;
                        PhotonNetwork.Destroy(duvar2.gameObject);
                        PhotonNetwork.Instantiate("yikil_online",duvar2.gameObject.transform.position,Quaternion.identity);
                        var pos = duvar2.gameObject.transform.position; 
                        GameObject.FindWithTag("player2").GetComponent<PhotonView>().RPC("yikilacakobje",RpcTarget.All,pos);
                        StartCoroutine(yikilan_yoket());
                        int random_sayi=random_create();
                        photonView.RPC("gift_create",RpcTarget.All,duvar2.gameObject.transform.position,random_sayi);
                    }
                }
            }
            for (var i = 1; i <= carpisma_photon.ates_boyut; i++){
                if(Bomb_Asil.bomba_all_pos.y-i==yikily){
                    if(yikily== Bomb_Asil.yikilan_asagi_pos.y && Bomb_Asil.artik_yikilasagi==1){
                        Bomb_Asil.artik_yikilasagi=0;
                        PhotonNetwork.Destroy(duvar2.gameObject);
                        PhotonNetwork.Instantiate("yikil_online",duvar2.gameObject.transform.position,Quaternion.identity);
                        var pos = duvar2.gameObject.transform.position; 
                        GameObject.FindWithTag("player2").GetComponent<PhotonView>().RPC("yikilacakobje",RpcTarget.All,pos);
                        StartCoroutine(yikilan_yoket());
                        int random_sayi=random_create();
                        photonView.RPC("gift_create",RpcTarget.All,duvar2.gameObject.transform.position,random_sayi);
                    }
                }
            }
        }
        carpisma=0;
    }
    
    public int random_create(){
        int random = Random.Range(0,6);
        return random;
    }
    [PunRPC]
    
    public IEnumerator yikilan_yoket(){
        yield return new WaitForSeconds(0.5f);
    }
    // public IEnumerator yoket2(){
    //     PhotonNetwork.Destroy(duvar2.gameObject);
    // }
    [PunRPC]
    private IEnumerator gift_create(Vector3 bomba_pos,int random_sayi){
        if (photonView.IsMine){
            yield return new WaitForSeconds(0.45f);
            if(random_sayi==0){
                PhotonNetwork.Instantiate("hediye_bomb_online",bomba_pos,Quaternion.identity); 
            }
            else if(random_sayi==1){
                PhotonNetwork.Instantiate("hediye_ates_online",bomba_pos,Quaternion.identity);
            }
            else if(random_sayi==2){
                PhotonNetwork.Instantiate("hediye_hiz_online",bomba_pos,Quaternion.identity); 
            } 
            else if(random_sayi==3){
                PhotonNetwork.Instantiate("hediye_tekme_online",bomba_pos,Quaternion.identity); 
            } 
            else if(random_sayi==4){
                PhotonNetwork.Instantiate("hediye_bilinmeyen_online",bomba_pos,Quaternion.identity); 
            } 
            else if(random_sayi==5){
                PhotonNetwork.Instantiate("hediye_ates_az_online",bomba_pos,Quaternion.identity); 
            } 
        }
    }
}

// if(Bomb_Asil.artik_yikilyukari==1){
//     Bomb_Asil.artik_yikilyukari=0;
//     Destroy(duvar2.gameObject);
// }
// if(Bomb_Asil.artik_yikilasagi==1){
//     Bomb_Asil.artik_yikilasagi=0;
//     Destroy(duvar2.gameObject);
// }
// if(Bomb_Asil.artik_yikilsol==1){
//     Bomb_Asil.artik_yikilsol=0;
//     Destroy(duvar2.gameObject);
// }
// if(Bomb_Asil.artik_yikilsag==1){
//     Bomb_Asil.artik_yikilsag=0;
//     Destroy(duvar2.gameObject);
// }