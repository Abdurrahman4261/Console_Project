using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class carpisma_photon2 : MonoBehaviourPunCallbacks
{
    public Animator oyuncu_dead,deathanim; PhotonView pw;
    public SpriteRenderer oyuncu_death_sp,death_sp; private SpriteRenderer oyuncu_sp;
    public static int anlama=1,hediyee,ates_boyut=1,zamanbomb=0,tekme=0,x,y;
    private int sart_death=0;
    private Rigidbody2D coll;
    public GameObject ates,ates2,death1,p1;
    public AudioSource ses;
    public AudioClip clip,clip2,clip3,clip4,clip5,clip6;
    void Start()
    { 
        oyuncu_sp = GetComponent<SpriteRenderer>();
        pw = GetComponent<PhotonView>();
        anlama=1;
        photonView.RPC("ilkboyut",RpcTarget.All,null);
        
        oyuncu_dead=GetComponent<Animator>(); 
        oyuncu_death_sp=GetComponent<SpriteRenderer>();  
        coll=GetComponent<Rigidbody2D>();   
        oyuncu_dead.enabled=false;
    }
   
    [PunRPC]
    private void ilkboyut(){
        if(!photonView.IsMine) return;
        for(int i=1;i<5;i++){
            ates.transform.GetChild(i).localScale=new Vector3(1,1,1);
            if(i==1)  ates.transform.GetChild(i).position=new Vector3(1f,0,0);
            else if(i==2)ates.transform.GetChild(i).position=new Vector3(-1f,0,0);
            else if(i==3)ates.transform.GetChild(i).position=new Vector3(0,-1f,0);
            else if(i==4)ates.transform.GetChild(i).position=new Vector3(0,1f,0);
        }
    }
    [PunRPC]
    private void ilkboyut2(){
        if(!photonView.IsMine) return;
        for(int i=1;i<5;i++){
            ates2.transform.GetChild(i).localScale=new Vector3(1,1,1);
            if(i==1)  ates2.transform.GetChild(i).position=new Vector3(1f,0,0);
            else if(i==2)ates2.transform.GetChild(i).position=new Vector3(-1f,0,0);
            else if(i==3)ates2.transform.GetChild(i).position=new Vector3(0,-1f,0);
            else if(i==4)ates2.transform.GetChild(i).position=new Vector3(0,1f,0);
        }
    }
    [PunRPC]
    private void boyut_degis(int i,string degis){
        if(!photonView.IsMine) return;

        if(degis == "arttır"){ ates.transform.GetChild(i).localScale+=new Vector3(1,0,0); }
        else {ates.transform.GetChild(i).localScale+=new Vector3(-1,0,0);}
    }
    [PunRPC]
    private void boyut_degis2(int i,string degis){
        if(!photonView.IsMine) return;
        if(degis == "arttır"){
            foreach (Transform child in ates2.transform){
                if(child.tag == "sag"){
                    child.position += new Vector3 (0.5f,0,0);
                }
                else if(child.tag == "sol"){
                    child.position += new Vector3 (-0.5f,0,0);
                }
                else if(child.tag == "asagi"){
                    child.position += new Vector3 (0,-0.5f,0);
                }
                else if(child.tag == "yukari"){
                    child.position += new Vector3 (0,0.5f,0);
                }
            }
        }
        if(degis == "az"){
            foreach (Transform child in ates2.transform){
                if(child.tag == "sag"){
                    child.position += new Vector3 (-0.5f,0,0);
                }
                else if(child.tag == "sol"){
                    child.position += new Vector3 (+0.5f,0,0);
                }
                else if(child.tag == "asagi"){
                    child.position += new Vector3 (0,+0.5f,0);
                }
                else if(child.tag == "yukari"){
                    child.position += new Vector3 (0,-0.5f,0);
                }
            }
        }
        for (int j=1;j<5;j++)
        {
            Debug.Log("j:"+j);
            if(degis == "arttır"){ ates2.transform.GetChild(j).localScale+=new Vector3(1,0,0); }
            else {ates2.transform.GetChild(j).localScale+=new Vector3(-1,0,0);}
        }
    }
    [PunRPC]
    void choose_music(int i){
        if(i==0 || i == 4){
            ses.PlayOneShot(clip,1f);
        }
        if(i==1){
            ses.PlayOneShot(clip2,1f);
        }
        if(i==2){
            ses.PlayOneShot(clip3,1f);
        }
        if(i==3){
            ses.PlayOneShot(clip4,1f);
        }
        if(i==5){
            ses.PlayOneShot(clip5,1f);
        }
        if(i==6){ ses.PlayOneShot(clip6,1f); }
    }
    [PunRPC]
    
    private int xrandom(string deger,int y){
        if(deger == "x"){
            y=Random.Range(0,5);
            return y;
        }else if(deger == "cift"){
            y = Random.Range(6,16);
            if(y%2!=0){
                y+=1;
            }
            return y;
        }else{
            y = Random.Range(-1,-5);
            return y;
        }
    }
    [PunRPC]
    void carpis (int i){
        if(i==1){gameObject.transform.position= new Vector3(gameObject.transform.position.x+x,gameObject.transform.position.y+y,0);}
        else if (i==2){gameObject.transform.position= new Vector3(gameObject.transform.position.x-x,gameObject.transform.position.y+y,0);}    
        else if (i==3){gameObject.transform.position= new Vector3(gameObject.transform.position.x-x,gameObject.transform.position.y-y,0);}    
        else if (i==4){gameObject.transform.position= new Vector3(gameObject.transform.position.x+x,gameObject.transform.position.y-y,0);}    
    }
    [PunRPC]
    void ates_size(string amac){
        if(!photonView.IsMine)return;
        
        if(amac =="arti"){
            ates_boyut++;
            Debug.Log("atessssss: "+ates_boyut);
            GameObject.FindWithTag("PlayerOne"). GetComponent<PhotonView>().RPC("boyut_degis2",RpcTarget.All,1,"arttır");
            foreach (Transform child in ates.transform)
            {
                if(child.tag == "sag"){
                    child.position += new Vector3 (0.5f,0,0);
                    photonView.RPC("boyut_degis",RpcTarget.All,1,"arttır");
                }
                else if(child.tag == "sol"){
                    child.position += new Vector3 (-0.5f,0,0);
                    photonView.RPC("boyut_degis",RpcTarget.All,2,"arttır");
                }
                else if(child.tag == "asagi"){
                    child.position += new Vector3 (0,-0.5f,0);
                    photonView.RPC("boyut_degis",RpcTarget.All,3,"arttır");
                }
                else if(child.tag == "yukari"){
                    child.position += new Vector3 (0,0.5f,0);
                    photonView.RPC("boyut_degis",RpcTarget.All,4,"arttır");
                }
            }
        }
        else if(amac =="eksi"){
            if(ates_boyut>=2){
                ates_boyut--;
                GameObject.FindWithTag("PlayerOne"). GetComponent<PhotonView>().RPC("boyut_degis2",RpcTarget.All,1,"az");

                foreach (Transform child in ates.transform)
                {
                    if(child.tag == "sag"){
                        child.position += new Vector3 (-0.5f,0,0);
                        photonView.RPC("boyut_degis",RpcTarget.All,1,"azalt");
                    }
                    else if(child.tag == "sol"){
                        child.position += new Vector3 (+0.5f,0,0);
                        photonView.RPC("boyut_degis",RpcTarget.All,2,"azalt");
                    }
                    else if(child.tag == "asagi"){
                        child.position += new Vector3 (0,+0.5f,0);
                        photonView.RPC("boyut_degis",RpcTarget.All,3,"azalt");
                    }
                    else if(child.tag == "yukari"){
                        child.position += new Vector3 (0,-0.5f,0);
                        photonView.RPC("boyut_degis",RpcTarget.All,4,"azalt");
                    }
                }
            }
        }
    }
    [PunRPC]
    void hediye_islemler(string islem){
        
        if(!photonView.IsMine) return;
        if(islem=="bomba"){
            Bomb_Player2.bombsayi+=1;
        }
        else if(islem=="hiz"){
            hareket_online2.hiz+=0.5f;  
        }
        else if(islem=="kick"){  
            tekme=1;  
        }
        else{   
            zamanbomb=1;    
        }
    }
    [PunRPC]
    private int yrandom(int y){
        y=Random.Range(0,5);
        return y;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(!photonView.IsMine) return;
        if(tekme==1 ){ 
            if(other.gameObject.tag=="bomb"){
                other.gameObject.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Dynamic;
            } 
        }   
    }
    [PunRPC]
    public void OnTriggerEnter2D(Collider2D duvar) {
        if(photonView.IsMine){
            if(duvar.gameObject.tag=="isin1"){
                x=xrandom("cift",x); y=xrandom("y",y);
                photonView.RPC("carpis",RpcTarget.All,1);
            }
            else if(duvar.gameObject.tag=="isin2"){
                x=xrandom("cift",x); y=xrandom("y",y);
                photonView.RPC("carpis",RpcTarget.All,2);
            }
            else if(duvar.gameObject.tag=="isin3"){
                x=xrandom("cift",x); y=xrandom("y",y);
                photonView.RPC("carpis",RpcTarget.All,3);
            }
            else if(duvar.gameObject.tag=="isin4"){
                x=xrandom("cift",x); y=xrandom("y",y);
                photonView.RPC("carpis",RpcTarget.All,4);
            }
            if(duvar.gameObject.tag == "ates"){
                int  i=0;    
                i = yrandom(i);
                Debug.Log("ates client");
                photonView.RPC("choose_music",RpcTarget.All,i);
                Debug.Log("duvar.gameObject.transform.position:"+duvar.gameObject.transform.position);
                
                Debug.Log("duvar.gameObject.transform.position:"+duvar.gameObject.transform.position);
                photonView.RPC("ates_size",RpcTarget.All,"arti");
            }   
            else if(duvar.gameObject.tag=="bomba"){
                int i=0;    i = yrandom(i);
                //photonView.RPC("yrandom",RpcTarget.All,i);
                photonView.RPC("choose_music",RpcTarget.All,i);
                
                photonView.RPC("hediye_islemler",RpcTarget.All,"bomba"); 
            }   
            else if(duvar.gameObject.tag=="hiz"){
                int i=0;    i = yrandom(i);
                //photonView.RPC("yrandom",RpcTarget.All,i);
                photonView.RPC("choose_music",RpcTarget.All,i);
                
                photonView.RPC("hediye_islemler",RpcTarget.All,"hiz");  
            }   
            else if(duvar.gameObject.tag=="ball"){
                
                hediye_islemler("ball"); 
            }
            else if(duvar.gameObject.tag=="kick"){ 
                int i=0;    i = yrandom(i);
                //photonView.RPC("yrandom",RpcTarget.All,i);
                photonView.RPC("choose_music",RpcTarget.All,i);
                
                photonView.RPC("hediye_islemler",RpcTarget.All,"kick");  
            }
            else if(duvar.gameObject.tag=="fire_down"){
                int i=0;    i = yrandom(i);
                //photonView.RPC("yrandom",RpcTarget.All,i);
                photonView.RPC("choose_music",RpcTarget.All,i);
                
                photonView.RPC("ates_size",RpcTarget.All,"eksi");
            }
            else if(duvar.gameObject.tag=="unknown"){
                int j=0;    j = yrandom(j);
                //photonView.RPC("yrandom",RpcTarget.All,j);
                photonView.RPC("choose_music",RpcTarget.All,j);
                
                int i=0;    i=xrandom("x",i);
                if(i==0){
                    photonView.RPC("ates_size",RpcTarget.All,"arti");
                }
                else if(i==1){
                    photonView.RPC("hediye_islemler",RpcTarget.All,"bomba");  
                }
                else if(i==2){
                    photonView.RPC("hediye_islemler",RpcTarget.All,"hiz"); 
                }
                else if(i==3){ 
                    photonView.RPC("hediye_islemler",RpcTarget.All,"kick");
                }
                else if(i==4){
                    photonView.RPC("ates_size",RpcTarget.All,"eksi");
                }
            }   
            if(duvar.gameObject.tag=="sol"||duvar.gameObject.tag=="sag"||duvar.gameObject.tag=="asagi"||duvar.gameObject.tag=="yukari"){
                sart_death+=1;
                transform.position =new Vector2(transform.position.x,transform.position.y);
                coll.constraints=RigidbodyConstraints2D.FreezeAll;
                anlama=2;
                photonView.RPC("Ölü",RpcTarget.All);
                oyuncu_sp.enabled=false;
                gameObject.transform.position= new Vector3 (-40,-40,0);
            }
        }
        if(PhotonNetwork.IsMasterClient){
            if(duvar.gameObject.tag == "ates" || duvar.gameObject.tag == "bomba" ||duvar.gameObject.tag == "hiz" ||duvar.gameObject.tag == "fire_down" || duvar.gameObject.tag == "unknown" ||duvar.gameObject.tag == "kick"){
                PhotonNetwork.Destroy(duvar.gameObject);
            }
        }
    }
    [PunRPC]
    private IEnumerator Ölü(){
        if(sart_death==1){
            GameObject xx=PhotonNetwork.Instantiate("death_online_2",gameObject.transform.position,Quaternion.identity);
            deathanim=xx.GetComponent<Animator>(); 
            death_sp=xx.GetComponent<SpriteRenderer>();
            deathanim.enabled = true ;
            deathanim.SetBool("death",true);
            death_sp.enabled=true;
            yield return new WaitForSeconds(1.9f);
            death_sp.enabled = false;
            PhotonNetwork.Destroy(xx);
            yield return new WaitForSeconds(2.0f);
            PhotonNetwork.Destroy(p1);
        }
    }
}