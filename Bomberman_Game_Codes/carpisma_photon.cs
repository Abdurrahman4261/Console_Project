using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class carpisma_photon : MonoBehaviourPunCallbacks
{
    public Animator oyuncu_dead,deathanim; PhotonView pw;
    public SpriteRenderer oyuncu_death_sp,death_sp; private SpriteRenderer oyuncu_sp;
    public static int anlama=1,hediyee,ates_boyut=1,zamanbomb=0,tekme=0,x,y;
    private int sart_death=0;
    public Rigidbody2D coll;
    public GameObject ates,ates2,death1,p1;   private Vector3 boyut,pozisyon;
    [SerializeField] private SpriteRenderer  sp;
    [SerializeField] private SpriteRenderer  spleft;
    [SerializeField] private SpriteRenderer  spup;
    [SerializeField] private SpriteRenderer  spright;
    void Start()
    { 
        oyuncu_sp = GetComponent<SpriteRenderer>();
        pw = GetComponent<PhotonView>();
        anlama=1;
        if(PhotonNetwork.IsMasterClient){
            ilkboyut(ates);
        }
        else{ilkboyut(ates2);}
            
        oyuncu_dead=GetComponent<Animator>(); 
        oyuncu_death_sp=GetComponent<SpriteRenderer>();  
        coll=GetComponent<Rigidbody2D>();   
        oyuncu_dead.enabled=false;
        
    }
    private void ilkboyut(GameObject ates){
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
    private void boyut_degis(int i,string degis,string masterorclient){
        if(masterorclient=="master"){
            if(degis == "arttır"){ ates.transform.GetChild(i).localScale+=new Vector3(1,0,0); }
            else {ates.transform.GetChild(i).localScale+=new Vector3(-1,0,0);}
        }
        else{
            if(degis == "arttır"){ ates2.transform.GetChild(i).localScale+=new Vector3(1,0,0); }
            else {ates2.transform.GetChild(i).localScale+=new Vector3(-1,0,0);}
        }
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
        
        Debug.Log("atessssss");
        if (photonView.IsMine){

            if(amac =="arti"){
                ates_boyut++;
                Debug.Log("atessssss: "+ates_boyut);
                foreach (Transform child in ates.transform)
                {
                    if(child.tag == "sag"){
                        child.position += new Vector3 (0.5f,0,0);
                        photonView.RPC("boyut_degis",RpcTarget.All,1,"arttır","master");
                        // boyut_degis(1,"arttır",ates);
                    }
                    else if(child.tag == "sol"){
                        child.position += new Vector3 (-0.5f,0,0);
                        photonView.RPC("boyut_degis",RpcTarget.All,2,"arttır","master");
                        // boyut_degis(2,"arttır",ates);
                    }
                    else if(child.tag == "asagi"){
                        child.position += new Vector3 (0,-0.5f,0);
                        photonView.RPC("boyut_degis",RpcTarget.All,3,"arttır","master");
                        // boyut_degis(3,"arttır",ates);
                    }
                    else if(child.tag == "yukari"){
                        child.position += new Vector3 (0,0.5f,0);
                        photonView.RPC("boyut_degis",RpcTarget.All,4,"arttır","master");
                        // boyut_degis(4,"arttır",ates);
                    }
                }
            }
        }
        
        else{
            if(amac =="eksi"){
                if(ates_boyut>=2){
                    ates_boyut--;
                    foreach (Transform child in ates.transform)
                    {
                        if(child.tag == "sag"){
                            child.position += new Vector3 (-0.5f,0,0);
                            photonView.RPC("boyut_degis",RpcTarget.All,1,"azalt","client");
                            // boyut_degis(1,"azalt",ates2);
                        }
                        else if(child.tag == "sol"){
                            child.position += new Vector3 (+0.5f,0,0);
                            photonView.RPC("boyut_degis",RpcTarget.All,2,"azalt","client");
                            // boyut_degis(2,"azalt",ates2);
                        }
                        else if(child.tag == "asagi"){
                            child.position += new Vector3 (0,+0.5f,0);
                            photonView.RPC("boyut_degis",RpcTarget.All,3,"azalt","client");
                            // boyut_degis(3,"azalt",ates2);
                        }
                        else if(child.tag == "yukari"){
                            child.position += new Vector3 (0,-0.5f,0);
                            photonView.RPC("boyut_degis",RpcTarget.All,4,"azalt","client");
                            // boyut_degis(4,"azalt",ates2);
                        }
                    }
                }
            }
        }
    }
    [PunRPC]
    void hediye_islemler(string islem){
        if(islem=="bomba"){
            Bomb_yedek.bombsayi+=1;
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
    private void OnCollisionEnter2D(Collision2D other) {
        if(!photonView.IsMine) return;
        Debug.Log("online ilk");  
        if(tekme==1 ){
            Debug.Log("isim"+other.gameObject.tag);   
            if(other.gameObject.tag=="bomb"){
                //Debug.Log("temasss");   
                other.gameObject.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Dynamic;
            } 
        }
        // if(other.gameObject.tag == "yikilan"){

        // }
    }
    [PunRPC]
    public void OnTriggerEnter2D(Collider2D duvar) {
        if(!photonView.IsMine) return;
        if(duvar.gameObject.tag == "ates"){
            photonView.RPC("ates_size",RpcTarget.All,"arti");
            PhotonNetwork.Destroy(duvar.gameObject);
            if(photonView.IsMine){

            }
            // ates_size("arti");
        }   
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
        else if(duvar.gameObject.tag=="bomba"){
            PhotonNetwork.Destroy(duvar.gameObject);
            photonView.RPC("hediye_islemler",RpcTarget.All,"bomba");  
            // hediye_islemler("bomba");  
            
        }   
        else if(duvar.gameObject.tag=="hiz"){
            PhotonNetwork.Destroy(duvar.gameObject);
            photonView.RPC("hediye_islemler",RpcTarget.All,"hiz");  
            // hediye_islemler("hiz"); 
        }   
        else if(duvar.gameObject.tag=="ball"){
            PhotonNetwork.Destroy(duvar.gameObject);
            hediye_islemler("ball"); 
        }
        else if(duvar.gameObject.tag=="kick"){ 
            PhotonNetwork.Destroy (duvar.gameObject);
            // hediye_islemler("kick"); 
            photonView.RPC("hediye_islemler",RpcTarget.All,"kick");  
        }
        else if(duvar.gameObject.tag=="fire_down"){
            PhotonNetwork.Destroy (duvar.gameObject);
            // ates_size("eksi"); 
            photonView.RPC("ates_size",RpcTarget.All,"eksi");
        }
        else if(duvar.gameObject.tag=="unknown"){
            PhotonNetwork.Destroy(duvar.gameObject);
            int i=0;    i=xrandom("x",i);
            if(i==0){
                // ates_size("arti");
                photonView.RPC("ates_size",RpcTarget.All,"arti");
            }
            else if(i==1){
                // hediye_islemler("bomba"); 
                photonView.RPC("hediye_islemler",RpcTarget.All,"bomba");  
            }
            else if(i==2){
                // hediye_islemler("hiz"); 
                photonView.RPC("hediye_islemler",RpcTarget.All,"hiz"); 
            }
            else if(i==3){
                // hediye_islemler("kick"); 
                photonView.RPC("hediye_islemler",RpcTarget.All,"kick");
            }
            else if(i==4){
                // ates_size("eksi");
                photonView.RPC("ates_size",RpcTarget.All,"eksi");
            }
        }   
        if(duvar.gameObject.tag=="sol"||duvar.gameObject.tag=="sag"||duvar.gameObject.tag=="asagi"||duvar.gameObject.tag=="yukari"){
            Debug.Log("öl");
            sart_death+=1;
            transform.position =new Vector2(transform.position.x,transform.position.y+0.4f);
            coll.constraints=RigidbodyConstraints2D.FreezeAll;
            anlama=2;
            photonView.RPC("Ölü",RpcTarget.All);
            //StartCoroutine (Ölü());
            oyuncu_sp.enabled=false;
            // SpriteRendUp.spriteRen.enabled=false;
            // SpriteRendDown.spriteRen.enabled=false;
            // SpriteRendLeft.spriteRen.enabled=false;
            // SpriteRendRight.spriteRen.enabled=false;
            gameObject.transform.position= new Vector3 (-40,-40,0);
        }
    }
    [PunRPC]
    private IEnumerator Ölü(){
        Debug.Log("ölü");  
        if(sart_death==1){
            Debug.Log("ölü2");  
            GameObject xx=PhotonNetwork.Instantiate("death_online",gameObject.transform.position,Quaternion.identity);
            deathanim=xx.GetComponent<Animator>(); 
            death_sp=xx.GetComponent<SpriteRenderer>();
            deathanim.enabled = true ;
            deathanim.SetBool("death",true);
            death_sp.enabled=true;
            yield return new WaitForSeconds(1.2f);
            // deathanim.enabled=false;
            yield return new WaitForSeconds(0.2f);
            
            yield return new WaitForSeconds(0.5f);
            death_sp.enabled = false;
            PhotonNetwork.Destroy(xx);
            // Destroy(xx);
            yield return new WaitForSeconds(2.0f);
            PhotonNetwork.Destroy(p1);
            //GameObject player1 = p1;
            //Destroy(player1);
        }
        else{
        }
    }
}
// else {
        //     if(amac =="arti"){
        //         ates_boyut++;
        //         Debug.Log("atessssss: "+ates_boyut);
        //         foreach (Transform child in ates.transform)
        //         {
        //             if(child.tag == "sag"){
        //                 photonView.RPC("boyut_degis",RpcTarget.All,1,"arttır","client");
        //                 child.position += new Vector3 (0.5f,0,0);
        //                 // boyut_degis(1,"arttır",ates2);
        //             }
        //             else if(child.tag == "sol"){
        //                 photonView.RPC("boyut_degis",RpcTarget.All,2,"arttır","client");
        //                 child.position += new Vector3 (-0.5f,0,0);
        //                 // boyut_degis(2,"arttır",ates2);
        //             }
        //             else if(child.tag == "asagi"){
        //                 photonView.RPC("boyut_degis",RpcTarget.All,3,"arttır","client");
        //                 child.position += new Vector3 (0,-0.5f,0);
        //                 // boyut_degis(3,"arttır",ates2);
        //             }
        //             else if(child.tag == "yukari"){
        //                 photonView.RPC("boyut_degis",RpcTarget.All,4,"arttır","client");
        //                 child.position += new Vector3 (0,0.5f,0);
        //                 // boyut_degis(4,"arttır",ates2);
        //             }
        //         }
        //     }
        // }
        // if (PhotonNetwork.IsMasterClient){
        //     if(amac =="eksi"){
        //         if(ates_boyut>=2){
        //             ates_boyut--;
        //             foreach (Transform child in ates.transform)
        //             {
        //                 if(child.tag == "sag"){
        //                     child.position += new Vector3 (-0.5f,0,0);
        //                     photonView.RPC("boyut_degis",RpcTarget.All,1,"azalt","master");
        //                     // boyut_degis(1,"azalt",ates);
        //                 }
        //                 else if(child.tag == "sol"){
        //                     child.position += new Vector3 (+0.5f,0,0);
        //                     photonView.RPC("boyut_degis",RpcTarget.All,2,"azalt","master");
        //                     // boyut_degis(2,"azalt",ates);
        //                 }
        //                 else if(child.tag == "asagi"){
        //                     photonView.RPC("boyut_degis",RpcTarget.All,3,"azalt","master");
        //                     child.position += new Vector3 (0,+0.5f,0);
        //                     // boyut_degis(3,"azalt",ates);
        //                 }
        //                 else if(child.tag == "yukari"){
        //                     photonView.RPC("boyut_degis",RpcTarget.All,4,"azalt","master");
        //                     child.position += new Vector3 (0,-0.5f,0);
        //                     // boyut_degis(4,"azalt",ates);
        //                 }
        //             }
        //         }
        //     }
        // }

            // //deathoyuncu.enabled=false;
            // // öl.enabled=true;
            // // ölüm.enabled=true;
            // deathoyuncu.enabled=true;
            // oyuncudeath.enabled=true;
            // yield return new WaitForSeconds(1.2f);
            // deathoyuncu.enabled=false;
            // //ölüm.enabled=false;
            // yield return new WaitForSeconds(0.2f);
            // //öl.enabled = false;
            // oyuncudeath.enabled = false;
            // yield return new WaitForSeconds(0.5f);
            
            // Destroy(gameObject);
            // //yield return new WaitForSeconds(2.5f);