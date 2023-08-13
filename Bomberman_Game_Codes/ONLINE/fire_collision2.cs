using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System;
using Random=UnityEngine.Random;
public class fire_collision2 : MonoBehaviourPunCallbacks
{
    private Vector2 bombapos2,posit,yikilan_pos;
    public static int yikilx2=0,yikily2=0,carpisma=1;
    
    [PunRPC]
    public void  OnTriggerEnter2D(Collider2D duvar2) {
        if(duvar2.gameObject.tag == "yikilan"){
            carpisma=1;
            int yikilx =(int)(duvar2.gameObject.transform.position.x);
            int yikily =(int)(duvar2.gameObject.transform.position.y);
            if(Bomb_Player2.artik_yikilsol==1 || Bomb_Player2.artik_yikilsag==1) {
                yikilx2 = yikilx;
            }
            if(Bomb_Player2.artik_yikilasagi==1 || Bomb_Player2.artik_yikilyukari==1) {
                yikily2 =yikily;
            }
            for (var i = 1; i <= carpisma_photon2.ates_boyut; i++){
                if(Bomb_Player2.bomba_all_pos.x+i==yikilx){
                    if(yikilx == Bomb_Player2.yikilan_sag_pos.x && Bomb_Player2.artik_yikilsag==1){
                        Bomb_Player2.artik_yikilsag=0;
                        int pos =Bomb_Player2.yikilacaksag;
                        PhotonNetwork.Instantiate("yikil_online",duvar2.gameObject.transform.position,Quaternion.identity);
                        GameObject.FindWithTag("PlayerOne").GetComponent<PhotonView>().RPC("yikil",RpcTarget.All,pos);
                        StartCoroutine(yikilan_yoket());
                        int random_sayi=random_create();
                        GameObject.FindWithTag("PlayerOne"). GetComponent<PhotonView>().RPC("gift_create",RpcTarget.All,duvar2.gameObject.transform.position,random_sayi);
                        //photonView.RPC("gift_create",RpcTarget.All,duvar2.gameObject.transform.position,random_sayi);
                    }
                }
            }
            for (var i = 1; i <= carpisma_photon2.ates_boyut; i++){
                if(Bomb_Player2.bomba_all_pos.x-i==yikilx){
                    if(yikilx== Bomb_Player2.yikilan_sol_pos.x && Bomb_Player2.artik_yikilsol==1){
                        Bomb_Player2.artik_yikilsol=0;
                        int pos =Bomb_Player2.yikilacaksol;
                        PhotonNetwork.Instantiate("yikil_online",duvar2.gameObject.transform.position,Quaternion.identity);
                        GameObject.FindWithTag("PlayerOne").GetComponent<PhotonView>().RPC("yikil",RpcTarget.All,pos);
                        StartCoroutine(yikilan_yoket());
                        int random_sayi=random_create();
                        GameObject.FindWithTag("PlayerOne"). GetComponent<PhotonView>().RPC("gift_create",RpcTarget.All,duvar2.gameObject.transform.position,random_sayi);
                       // photonView.RPC("gift_create",RpcTarget.All,duvar2.gameObject.transform.position,random_sayi);
                    }
                }
            }
            for (var i = 1; i <= carpisma_photon2.ates_boyut; i++){
                if(Bomb_Player2.bomba_all_pos.y+i==yikily){
                    if(yikily== Bomb_Player2.yikilan_yukari_pos.y && Bomb_Player2.artik_yikilyukari==1){
                        Bomb_Player2.artik_yikilyukari=0;
                        int pos =Bomb_Player2.yikilacakyukari;
                        PhotonNetwork.Instantiate("yikil_online",duvar2.gameObject.transform.position,Quaternion.identity);
                        GameObject.FindWithTag("PlayerOne").GetComponent<PhotonView>().RPC("yikil",RpcTarget.All,pos);
                        StartCoroutine(yikilan_yoket());
                        int random_sayi=random_create();
                        GameObject.FindWithTag("PlayerOne"). GetComponent<PhotonView>().RPC("gift_create",RpcTarget.All,duvar2.gameObject.transform.position,random_sayi);
                       // photonView.RPC("gift_create",RpcTarget.All,duvar2.gameObject.transform.position,random_sayi);
                    }
                }
            }
            for (var i = 1; i <= carpisma_photon2.ates_boyut; i++){
                if(Bomb_Player2.bomba_all_pos.y-i==yikily){
                    if(yikily== Bomb_Player2.yikilan_asagi_pos.y && Bomb_Player2.artik_yikilasagi==1){
                        Bomb_Player2.artik_yikilasagi=0;
                        int pos =Bomb_Player2.yikilacakasagi;
                        PhotonNetwork.Instantiate("yikil_online",duvar2.gameObject.transform.position,Quaternion.identity);
                        GameObject.FindWithTag("PlayerOne").GetComponent<PhotonView>().RPC("yikil",RpcTarget.All,pos);
                        StartCoroutine(yikilan_yoket());
                        int random_sayi=random_create();
                        GameObject.FindWithTag("PlayerOne"). GetComponent<PhotonView>().RPC("gift_create",RpcTarget.All,duvar2.gameObject.transform.position,random_sayi);
                       // photonView.RPC("gift_create",RpcTarget.All,duvar2.gameObject.transform.position,random_sayi);
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
    public IEnumerator yikilan_yoket(){
        yield return new WaitForSeconds(0.5f);
    }
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