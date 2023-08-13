using System.Collections;
using UnityEngine;
using Photon.Pun;
using Random=UnityEngine.Random;
using System;

public class Bomb_Asil : MonoBehaviourPunCallbacks
{
    public static int bombsayi = 2;
    private KeyCode input = KeyCode.Space;
    public GameObject bombprefab,atesprefab,oyuncu,hediye_ates,hediye_bomba,hediye_hiz,hediye_unknown,hediye_ball,hediye_tekme,hediye_ates_az,oyuncu1,oyuncu2;
    private float patlama = 3f,MesafeSag,MesafeSol,MesafeAsagi,MesafeYukari;
    public static float kesilecek_atessag=0,kesilecek_atessol=0,kesilecek_atesyukari=0,kesilecek_atesasagi=0,artik_yikilsag=0,artik_yikilsol=0,artik_yikilasagi=0,artik_yikilyukari=0;
    private Vector2 bombapos;
    public static Vector2 bomba_all_pos,bomba_all_pos2,yikilan_yukari_pos,yikilan_asagi_pos,yikilan_sol_pos,yikilan_sag_pos;
    PhotonView pw;
    public static GameObject shediye_ates,shediye_bomba,shediye_hiz,shediye_unknown,shediye_ball,shediye_tekme,shediye_ates_az;
    private int sol_kesil=0,sag_kesil=0,asagi_kesil=0,yukari_kesil=0,sag_indis=0,sol_indis=0,asagi_indis=0,yukari_indis=0;
    private static int sol_pos=0,yukari_pos=0;
    public AudioSource ses;
    public AudioClip clip;
    private void  Start(){
        pw=GetComponent<PhotonView>();
    }
    private void Update() {
        if (!photonView.IsMine) return;
        if(Input.GetKeyDown(input) && bombsayi>0){
            photonView.RPC("baslat_yadacik",RpcTarget.All,"baslat");
        }
        if(Input.GetKeyDown(KeyCode.F1)){
            photonView.RPC("baslat_yadacik",RpcTarget.All,"cik");
        }
    }
    [PunRPC]
    private void ates_size(float sag ,float sol , float yukari , float asagi){
        
        var atess2  = GameObject.FindWithTag("ates_online2");
        if(atess2 != null){
            atess2.transform.GetChild(1).transform.localScale+=new Vector3((sag)*(-1),0,0);
            atess2.transform.GetChild(1).transform.position+=new Vector3((sag)*(-0.5f),0,0); 
            atess2.transform.GetChild(2).transform.localScale+=new Vector3((sol)*(-1),0,0);
            atess2.transform.GetChild(2).transform.position+=new Vector3((sol)*0.5f,0,0);
            atess2.transform.GetChild(3).transform.localScale+=new Vector3((asagi)*(-1),0,0);
            atess2.transform.GetChild(3).transform.position+=new Vector3(0,(asagi)*(0.5f),0);
            atess2.transform.GetChild(4).transform.localScale+=new Vector3((yukari)*(-1),0,0);
            atess2.transform.GetChild(4).transform.position+=new Vector3(0,(yukari)*(-0.5f),0);
        }
    }
    [PunRPC]
    private void ates_size2(float sag ,float sol , float yukari , float asagi){
        
        var atess2  = GameObject.FindWithTag("ates_online2");
    
        if(atess2 != null){
            atess2.transform.GetChild(1).transform.localScale+=new Vector3(sag*(+1),0,0);
            atess2.transform.GetChild(1).transform.position+=new Vector3(sag*(0.5f),0,0);
            atess2.transform.GetChild(2).transform.localScale+=new Vector3(sol*(+1),0,0);
            atess2.transform.GetChild(2).transform.position+=new Vector3(sol*(-0.5f),0,0);
            atess2.transform.GetChild(3).transform.localScale+=new Vector3(asagi*(+1),0,0);
            atess2.transform.GetChild(3).transform.position+=new Vector3(0,asagi*(-0.5f),0);
            atess2.transform.GetChild(4).transform.localScale+=new Vector3(yukari*(+1),0,0); 
            atess2.transform.GetChild(4).transform.position+=new Vector3(0,yukari*(0.5f),0);

        }
    }
    [PunRPC]
    void baslat_yadacik(string ne){
        if(ne=="baslat"){ 
            StartCoroutine(PlaceBomb3(bombapos));  
        }
        else{ 
            Application.Quit();  
        }
    }
    
    private int Rando(int sayi,string kontrol){
        if(kontrol=="y"){
            sayi = Random.Range(-1,-5);
            return sayi;
        }
        else if(kontrol=="cift"){
            sayi = Random.Range(6,16);
            if(sayi%2!=0){  sayi+=1;  }
            return sayi;
        }else{
            sayi = Random.Range(0,7);
            return sayi;
        }
    }
    [PunRPC]
    private IEnumerator PlaceBomb3(Vector2 bombapos){
        if(photonView.IsMine){
            float x = oyuncu.transform.position.x;
            float y = oyuncu.transform.position.y;
            bombapos=new Vector2(Mathf.RoundToInt(x),Mathf.RoundToInt(y));
            bomba_all_pos = bombapos;
            GameObject bombprefab2 = PhotonNetwork.Instantiate("Bomb_online",bombapos,Quaternion.identity);
            if(carpisma_photon.tekme==1 ){
                bombprefab2.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Dynamic;
            }
            bombsayi--;
            yield return new WaitForSeconds(0.5f);
            bombprefab2.GetComponent<BoxCollider2D>().isTrigger=false;
            yield return new WaitForSeconds(patlama-1.3f);
            
            ses.PlayOneShot(clip,1f);
            yield return new WaitForSeconds(0.2f);
            bombapos=new Vector2(Mathf.RoundToInt(bombprefab2.transform.position.x),Mathf.RoundToInt(bombprefab2.transform.position.y));
            yield return new WaitForSeconds(0.05f);
            PhotonNetwork.Destroy(bombprefab2);
            
            bombsayi++;  carpisma_photon.zamanbomb=0; // kesilcek miktar carpisma_photon.atesbouyt-mesafe
            GameObject ates  = PhotonNetwork.Instantiate("Fire1_online",bombapos,Quaternion.identity); 
              
            for (var i = 1; i <=carpisma_photon.ates_boyut; i++){
                for (int j = 0; j < yonet.yikilanlar.Count; j++){
                
                    if(yonet.yikilanlar[j]  == null)continue;
                    if(new Vector3(bombapos.x+i,bombapos.y)==yonet.yikilanlar[j].transform.position){
                        int random_sayi=random_create();
                        photonView.RPC("gift_create",RpcTarget.All,yonet.yikilanlar[j].transform.position,random_sayi);
                        sag_indis = 1;
                        yikilan_sag_pos = yonet.yikilanlar[j].transform.position;
                        artik_yikilsag=1;
                        sag_kesil=1;
                        break;
                    }
                }
                if(sag_indis == 1){
                    break;
                }
            }    
            for (var i = 1; i <=carpisma_photon.ates_boyut; i++){
                for (int j = 0; j < yonet.yikilanlar.Count; j++){
                    if(yonet.yikilanlar[j]  == null)continue;
                    if(new Vector3(bombapos.x-i,bombapos.y)==yonet.yikilanlar[j].transform.position){
                        int random_sayi=random_create();
                        photonView.RPC("gift_create",RpcTarget.All,yonet.yikilanlar[j].transform.position,random_sayi);
                        sol_indis = 1;
                        yikilan_sol_pos = yonet.yikilanlar[j].transform.position;
                        sol_pos =(int) yikilan_sol_pos.x;
                        artik_yikilsol=1;
                        sol_kesil=1;
                        break;
                    }
                }
                if(sol_indis == 1){
                    break;
                }
            }
            for (var i = 1; i <=carpisma_photon.ates_boyut; i++){    
                for (int j = 0; j < yonet.yikilanlar.Count; j++){  
                    
                    if(yonet.yikilanlar[j]  == null)continue;
                    if(new Vector3(bombapos.x,bombapos.y+i)==yonet.yikilanlar[j].transform.position){
                        int random_sayi=random_create();
                        photonView.RPC("gift_create",RpcTarget.All,yonet.yikilanlar[j].transform.position,random_sayi);
                        yukari_indis = 1;
                        yikilan_yukari_pos=yonet.yikilanlar[j].transform.position;
                        yukari_pos =(int) yikilan_yukari_pos.y;
                        artik_yikilyukari=1;
                        yukari_kesil=1;
                        break;
                    }
                }
                if(yukari_indis == 1){
                    break;
                }
            }
            for (var i = 1; i <=carpisma_photon.ates_boyut; i++){
                for (int j = 0; j < yonet.yikilanlar.Count; j++){
                    if(yonet.yikilanlar[j]  == null)continue;
                    if(new Vector3(bombapos.x,bombapos.y-i)==yonet.yikilanlar[j].transform.position){
                        int random_sayi=random_create();
                        photonView.RPC("gift_create",RpcTarget.All,yonet.yikilanlar[j].transform.position,random_sayi);
                        asagi_indis = 1;
                        yikilan_asagi_pos=yonet.yikilanlar[j].transform.position;
                        artik_yikilasagi=1;
                        asagi_kesil=1;
                        break;
                    }
                } 
                if(asagi_indis == 1){
                    break;
                }
            }     
            
            
            yield return new WaitForSeconds(0.0002f);
            if(sag_kesil==1){ kesilecek_atessag = kesilecek_ates(MesafeSag,fire_collision.yikilx2,bombapos.x,kesilecek_atessag,sag_kesil,sol_kesil,asagi_kesil,yukari_kesil);  }
            if(sol_kesil==1){ kesilecek_atessol = kesilecek_ates(MesafeSol,sol_pos,bombapos.x,kesilecek_atessol,sag_kesil,sol_kesil,asagi_kesil,yukari_kesil);  }
            if(asagi_kesil==1){kesilecek_atesasagi = kesilecek_ates(MesafeAsagi,fire_collision.yikily2,bombapos.y,kesilecek_atesasagi,sag_kesil,sol_kesil,asagi_kesil,yukari_kesil); }
            if(yukari_kesil==1){ kesilecek_atesyukari = kesilecek_ates(MesafeYukari,yukari_pos,bombapos.y,kesilecek_atesyukari,sag_kesil,sol_kesil,asagi_kesil,yukari_kesil);    }
        
            if(fire_collision.carpisma==1){
                
                GameObject.FindWithTag("player2").GetComponent<PhotonView>().RPC("ates_size",RpcTarget.All,kesilecek_atessag,kesilecek_atessol,kesilecek_atesyukari,kesilecek_atesasagi);
                ates.transform.GetChild(1).transform.localScale+=new Vector3((kesilecek_atessag)*(-1),0,0);
                ates.transform.GetChild(1).transform.position+=new Vector3((kesilecek_atessag)*(-0.5f),0,0); 
                ates.transform.GetChild(2).transform.localScale+=new Vector3((kesilecek_atessol)*(-1),0,0);
                ates.transform.GetChild(2).transform.position+=new Vector3((kesilecek_atessol)*0.5f,0,0);
                ates.transform.GetChild(3).transform.localScale+=new Vector3((kesilecek_atesasagi)*(-1),0,0);
                ates.transform.GetChild(3).transform.position+=new Vector3(0,(kesilecek_atesasagi)*(0.5f),0);
                ates.transform.GetChild(4).transform.localScale+=new Vector3((kesilecek_atesyukari)*(-1),0,0);
                ates.transform.GetChild(4).transform.position+=new Vector3(0,(kesilecek_atesyukari)*(-0.5f),0);
            }
            yield return new WaitForSeconds(0.59f);

            if(fire_collision.carpisma==1){
                ates.SetActive(false);
                yield return new WaitForSeconds(0.1f);
                GameObject.FindWithTag("player2").GetComponent<PhotonView>().RPC("ates_size2",RpcTarget.All,kesilecek_atessag,kesilecek_atessol,kesilecek_atesyukari,kesilecek_atesasagi);
                ates.transform.GetChild(1).transform.localScale+=new Vector3(kesilecek_atessag*(+1),0,0);
                ates.transform.GetChild(1).transform.position+=new Vector3(kesilecek_atessag*(0.5f),0,0);
                ates.transform.GetChild(2).transform.localScale+=new Vector3(kesilecek_atessol*(+1),0,0);
                ates.transform.GetChild(2).transform.position+=new Vector3(kesilecek_atessol*(-0.5f),0,0);
                ates.transform.GetChild(3).transform.localScale+=new Vector3(kesilecek_atesasagi*(+1),0,0);
                ates.transform.GetChild(3).transform.position+=new Vector3(0,kesilecek_atesasagi*(-0.5f),0);
                ates.transform.GetChild(4).transform.localScale+=new Vector3(kesilecek_atesyukari*(+1),0,0); 
                ates.transform.GetChild(4).transform.position+=new Vector3(0,kesilecek_atesyukari*(0.5f),0);
                
            }
            PhotonNetwork.Destroy(ates);
            
            artik_yikilsag=0;   artik_yikilsol=0;   artik_yikilasagi=0;   artik_yikilyukari=0;
            sag_kesil =0 ;  sol_kesil = 0;    asagi_kesil =0 ;    yukari_kesil = 0; 
            kesilecek_atesasagi =0 ;    kesilecek_atesyukari =0 ;    kesilecek_atessol =0 ;    kesilecek_atessag =0 ;
            asagi_indis = 0;    yukari_indis = 0;    sol_indis = 0;    sag_indis = 0;
        }
    }
    public int random_create(){
        int random = Random.Range(0,6);
        return random;
    }
    [PunRPC]
    private IEnumerator gift_create(Vector3 bomba_pos,int random_sayi){
        if (photonView.IsMine){
            yield return new WaitForSeconds(0.95f);
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
    public float kesilecek_ates(float mesafe,int yikil,float pos_dir,float kesilecek,int sag_kesil,int sol_kesil,int yukari_kesil,int asagi_kesil){
        fire_collision.carpisma=1;
        mesafe = Math.Abs (yikil-pos_dir);
        if(PhotonNetwork.IsMasterClient){
            kesilecek = carpisma_photon.ates_boyut - mesafe;
        }else {     kesilecek = carpisma_photon.ates_boyut2 - mesafe;    }

        if(kesilecek<0|| mesafe==0){kesilecek=0;}
        return kesilecek ;
    }
}