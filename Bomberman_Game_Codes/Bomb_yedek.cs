 using System.Runtime.InteropServices;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Photon.Realtime;
using Photon.Pun;
using Random=UnityEngine.Random;
public class Bomb_yedek : MonoBehaviourPunCallbacks
{
    public KeyCode input = KeyCode.Space;
    public GameObject bombprefab,atesprefab,oyuncu,hediye_ates,hediye_bomba,hediye_hiz,hediye_unknown,hediye_ball,hediye_tekme,hediye_ates_az;
    public static GameObject shediye_ates,shediye_bomba,shediye_hiz,shediye_unknown,shediye_ball,shediye_tekme,shediye_ates_az;
    public float patlama = 3f,fark1,fark2;
    public static int bombsayi = 2,random_sayi,kısaüst=1,kısaalt=1,kısasag=1,kısasol=1 ,kısaüst2=1,kısaalt2=1,kısasag2=1,kısasol2=1;
    private int i,sayac,yön,a,b,c,d,a1,b1,c1,d1,x,y, ust_ugrama1=0,ust_ugrama2=0,alt_ugrama1=0,alt_ugrama2=0,sol_ugrama1=0,sol_ugrama2=0,sag_ugrama1=0,sag_ugrama2=0;
    private int ust=0,kontrol=0,ates_kontrol=0;
    public Vector2 bombapos,bombapos2,posit;
    [Header("Yıkilmayan")]
    Vector3Int gridPlace2,gridPlace ; PhotonView pw;
    public Tilemap yıkılmayan, yıklan_duvarlar; 
    [Header("Yıkılan")]
    public Yıkılan duvar_prefab;    private GameObject s;
    
    

    private void  Start(){
        pw=GetComponent<PhotonView>();
        photonView.RPC("gridd",RpcTarget.All);
    }
    private void  Update() {
        if (!photonView.IsMine) return;
        
        if(Input.GetKeyDown(input) && bombsayi>0){
            photonView.RPC("PlaceBomb",RpcTarget.All,bombapos);
            // photonView.RPC("baslat_yadacik",RpcTarget.All,"ne");
        }
        if(Input.GetKeyDown(KeyCode.F1)){
            photonView.RPC("baslat_yadacik",RpcTarget.All,"cik");
        }
    }
    
    [PunRPC]
    void gridd(){
        Debug.Log("ss");
        s = GameObject.FindWithTag("Respawn");
        yıklan_duvarlar = s.transform.GetChild(2).GetComponent<Tilemap>();
        yıkılmayan      = s.transform.GetChild(1).GetComponent<Tilemap>();
        foreach (var pos in yıklan_duvarlar.cellBounds.allPositionsWithin)
        {   
            gridPlace = new Vector3Int(pos.x, pos.y, pos.z);
            if (yıklan_duvarlar.HasTile(gridPlace))
            {
                TileBase tile = yıklan_duvarlar.GetTile(gridPlace);
            }
        }
        foreach (var pos in yıkılmayan.cellBounds.allPositionsWithin)
        {   
            gridPlace2 = new Vector3Int(pos.x, pos.y, pos.z);
            if (yıkılmayan.HasTile(gridPlace2))
            {
                TileBase tile = yıkılmayan.GetTile(gridPlace2);
            }
        }
    }
    [PunRPC]
    void baslat_yadacik(string ne){
        if(ne=="baslat"){ 
            StartCoroutine(PlaceBomb(bombapos));  
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
    private IEnumerator all(Vector2 bomba,int sayacc,int x_arti,int y_arti,string direction){
        if (photonView.IsMine){

            yield return new WaitForSeconds(0.95f);
            for(;sayacc<Carpisma.ates_boyut;sayacc++){
                if(random_sayi==0){
                    if(direction =="yuk"){ y_arti+=1; }
                    if(direction =="asagi"){ y_arti=-y_arti-1; }
                    if(direction =="sag"){x_arti+=1; }
                    if(direction =="sol"){ x_arti=-x_arti-1; }
                    PhotonNetwork.Instantiate("hediye_bomb_online",new Vector3 (bomba.x+x_arti, bomba.y+y_arti),Quaternion.identity); 
                }
                else if(random_sayi==1){
                    if(direction =="yuk"){ y_arti+=1; }
                    if(direction =="asagi"){ y_arti=-y_arti-1; }
                    if(direction =="sag"){x_arti+=1; }
                    if(direction =="sol"){ x_arti=-x_arti-1; }
                    PhotonNetwork.Instantiate("hediye_ates_online",new Vector3 (bomba.x+x_arti, bomba.y+y_arti),Quaternion.identity);
                }
                else if(random_sayi==2){
                    if(direction =="yuk"){ y_arti+=1; }
                    if(direction =="asagi"){ y_arti=-y_arti-1; }
                    if(direction =="sag"){x_arti+=1; }
                    if(direction =="sol"){ x_arti=-x_arti-1; }
                    PhotonNetwork.Instantiate("hediye_hiz_online",new Vector3 (bomba.x+x_arti, bomba.y+y_arti),Quaternion.identity); 
                } 
                else if(random_sayi==3){
                    if(direction =="yuk"){ y_arti+=1; }
                    if(direction =="asagi"){ y_arti=-y_arti-1; }
                    if(direction =="sag"){x_arti+=1; }
                    if(direction =="sol"){ x_arti=-x_arti-1; }
                    PhotonNetwork.Instantiate("hediye_tekme_online",new Vector3 (bomba.x+x_arti, bomba.y+y_arti),Quaternion.identity); 
                } 
                else if(random_sayi==4){
                    if(direction =="yuk"){ y_arti+=1; }
                    if(direction =="asagi"){ y_arti=-y_arti-1; }
                    if(direction =="sag"){x_arti+=1; }
                    if(direction =="sol"){ x_arti=-x_arti-1; }
                    PhotonNetwork.Instantiate("hediye_bilinmeyen_online",new Vector3 (bomba.x+x_arti, bomba.y+y_arti),Quaternion.identity); 
                } 
                else if(random_sayi==5){
                    if(direction =="yuk"){ y_arti+=1; }
                    if(direction =="asagi"){ y_arti=-y_arti-1; }
                    if(direction =="sag"){x_arti+=1; }
                    if(direction =="sol"){ x_arti=-x_arti-1; }
                    PhotonNetwork.Instantiate("hediye_ates_az_online",new Vector3 (bomba.x+x_arti, bomba.y+y_arti),Quaternion.identity); 
                } 
                sayacc=Carpisma.ates_boyut; 
            }
        }
    }
    // hatalar 3 tane: iki ateş , ateş boyutu ayarlama, hediye alımı client sorunu 
    [PunRPC]
    public IEnumerator PlaceBomb(Vector2 bombapos){
        
        Vector2 bombapos2=new Vector2(Mathf.RoundToInt(oyuncu.transform.position.x),Mathf.RoundToInt(oyuncu.transform.position.y));
        Debug.Log("bombapos2 : "+bombapos2);
        
        bombapos=new Vector2(Mathf.RoundToInt(gameObject.transform.position.x),Mathf.RoundToInt(gameObject.transform.position.y));
        Debug.Log("bombapos : "+bombapos);
        if(photonView.IsMine){
            kontrol=1;
            Vector3 tilePosition;
            Vector3Int coordinate = new Vector3Int(0, 0, 0);
            tilePosition = yıklan_duvarlar.CellToWorld(coordinate);

            Vector3 tilePosition2;
            Vector3Int coordinate2 = new Vector3Int(0, 0, 0);
            tilePosition2 = yıkılmayan.CellToWorld(coordinate2);
            GameObject bombprefab2 = PhotonNetwork.Instantiate("Bomb_online",bombapos,Quaternion.identity);
            
            if(carpisma_photon.tekme==1 ){
                Debug.Log("tekme 1");
                bombprefab2.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Dynamic;
            }
            bombsayi--;
            
            yield return new WaitForSeconds(0.5f);
            bombprefab2.GetComponent<BoxCollider2D>().isTrigger=false;
            yield return new WaitForSeconds(patlama-1.45f);
            bombapos=new Vector2(Mathf.RoundToInt(bombprefab2.transform.position.x),Mathf.RoundToInt(bombprefab2.transform.position.y));
            yield return new WaitForSeconds(0.05f);
            PhotonNetwork.Destroy(bombprefab2);
            
            bombsayi++;  carpisma_photon.zamanbomb=0;
        }
        if(kontrol==0){
            yield return new WaitForSeconds(2f);
        }
        var pPos =  yıklan_duvarlar.WorldToCell(bombapos); //var pPos =  yıkılmayan.WorldToCell(bombapos);
        
        kısaüst=1; kısaalt=1; kısasag=1; kısasol=1;  kısaüst2=1; kısaalt2=1; kısasag2=1; kısasol2=1; a=1; b=1; c=1; d=1; a1=1; b1=1; c1=1; d1=1;
    
        uzaklıküst(carpisma_photon.ates_boyut) ;uzaklıksag(carpisma_photon.ates_boyut);    ;uzaklıksag2(carpisma_photon.ates_boyut); uzaklıküst2(carpisma_photon.ates_boyut); 
        uzaklıkalt(carpisma_photon.ates_boyut) ;uzaklıksol(carpisma_photon.ates_boyut);    uzaklıkalt2(carpisma_photon.ates_boyut) ;uzaklıksol2(carpisma_photon.ates_boyut);
        GameObject  ates  = PhotonNetwork.Instantiate("Fire1_online",bombapos,Quaternion.identity);
        if(photonView.IsMine){

        }
        
        for(sayac=0;sayac<carpisma_photon.ates_boyut;sayac++){
            if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x, pPos.y+1+sayac, pPos.z))==null){
                uzaklıküst(carpisma_photon.ates_boyut);
            } 
            
            if(yıkılmayan.GetTile(new Vector3Int(pPos.x, pPos.y+1+sayac, pPos.z))!=null){
                uzaklıküst2(carpisma_photon.ates_boyut);
                if(b1==1){
                    
                    ates.transform.GetChild(4).transform.localScale+=new Vector3((kısaüst2+1)*(-1),0,0);
                    ates.transform.GetChild(4).transform.position+=new Vector3(0,(kısaüst2+1)*(-0.5f),0);
                }
                b1++;
                ust_ugrama1=1;
                sayac=carpisma_photon.ates_boyut;
            }
            if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x, pPos.y+1+sayac, pPos.z))!=null){
                Debug.Log("yiıkılan");
                ust=carpisma_photon.ates_boyut-(sayac+1);
                if(b==1){
                    if(ust>0){
                        Debug.Log("ust : "+ust);
                        ates.transform.GetChild(4).transform.localScale+=new Vector3(ust*(-1),0,0);
                        ates.transform.GetChild(4).transform.position+=new Vector3(0,ust*(-0.5f),0); 
                    }
                }
                b++;     
                yıklan_duvarlar.SetTile(new Vector3Int (pPos.x, pPos.y+1+sayac, pPos.z), null); 
                PhotonNetwork.Instantiate("yikil_online",new Vector3 (bombapos.x, bombapos.y+1+sayac),Quaternion.identity);
                random_sayi= Rando(random_sayi,".");
                if(photonView.IsMine){
                    photonView.RPC("all",RpcTarget.All,bombapos,sayac,0,sayac,"yuk");
                }
                ust_ugrama2=1;
                sayac=carpisma_photon.ates_boyut;
            }
        }
        for(sayac=0;sayac<carpisma_photon.ates_boyut;sayac++){
            
            if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x, pPos.y-1-sayac, pPos.z))==null){  
                int a=carpisma_photon.ates_boyut;
                uzaklıkalt(carpisma_photon.ates_boyut);
                if(sayac==carpisma_photon.ates_boyut-1){
                    //yield return new WaitForSeconds(0.6f);
                    //Destroy(ates);  Debug.Log("destroy");
                }
            } 
            if(yıkılmayan.GetTile(new Vector3Int(pPos.x, pPos.y-1-sayac, pPos.z))!=null){  
                Debug.Log("292 uzaklıik : "+(sayac+1));
                uzaklıkalt2(carpisma_photon.ates_boyut);
                if(a1==1){
                    ates.transform.GetChild(3).transform.localScale+=new Vector3((kısaalt2+1)*(-1),0,0);
                    ates.transform.GetChild(3).transform.position+=new Vector3(0,(kısaalt2+1)*(0.5f),0);
                }
                a1++;
                //eski_boyut(GameObject ates,int eski_byt,int indis,int eksi_arti,string direction);
                //yield return new WaitForSeconds(0.60f);
                alt_ugrama1=1;
                // ates.transform.GetChild(3).transform.localScale+=new Vector3(kısaalt2*(+1),0,0);
                // ates.transform.GetChild(3).transform.position+=new Vector3(0,kısaalt2*(-0.5f),0);
                sayac=carpisma_photon.ates_boyut;
                //Destroy(ates);  Debug.Log("destroy");
                // StartCoroutine(asagi22(ates));
            }
            else if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x, pPos.y-1-sayac, pPos.z))!=null){  
                if(a==1){
                    for(int i=0;i<carpisma_photon.ates_boyut+1-kısaalt;i++){
                        ates.transform.GetChild(3).transform.localScale+=new Vector3((-1),0,0);
                        ates.transform.GetChild(3).transform.position+=new Vector3(0,(0.5f),0);
                    }
                }
                a++;
                yıklan_duvarlar.SetTile(new Vector3Int (pPos.x, pPos.y-1-sayac, pPos.z), null); 
                PhotonNetwork.Instantiate("yikil_online",new Vector3 (bombapos.x, bombapos.y-1-sayac),Quaternion.identity);
                
                random_sayi= Rando(random_sayi,".");
                if(photonView.IsMine){
                    Debug.Log("yikilmayan");
                    photonView.RPC("all",RpcTarget.All,bombapos,sayac,0,sayac,"asagi");
                }
                alt_ugrama2=1;
                sayac=carpisma_photon.ates_boyut;
                continue;
            }
        }
        for(sayac=0;sayac<carpisma_photon.ates_boyut;sayac++){

            if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x-1-sayac, pPos.y, pPos.z))==null){
                uzaklıksol(carpisma_photon.ates_boyut);
                if(sayac==carpisma_photon.ates_boyut-1){
                    //yield return new WaitForSeconds(0.6f);
                    //Destroy(ates); Debug.Log("destroy");
                    
                }
                // StartCoroutine(yok(ates));
            } 
            if(yıkılmayan.GetTile(new Vector3Int(pPos.x-1-sayac, pPos.y, pPos.z))!=null){ 
                Debug.Log("345 uzaklıik : "+(sayac+1));
                uzaklıksol2(carpisma_photon.ates_boyut);
                if(c1==1){
                    ates.transform.GetChild(2).transform.localScale+=new Vector3((kısasol2+1)*(-1),0,0);
                    ates.transform.GetChild(2).transform.position+=new Vector3((kısasol2+1)*(0.5f),0,0);
                }
                c1++;
                //yield return new WaitForSeconds(0.60f);
                sol_ugrama1=1;
                // ates.transform.GetChild(2).transform.localScale+=new Vector3(kısasol2*(+1),0,0);
                // ates.transform.GetChild(2).transform.position+=new Vector3(kısasol2*(-0.5f),0,0);
                sayac=carpisma_photon.ates_boyut;
                //Destroy(ates);  Debug.Log("destroy");
            }
            else if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x-1-sayac, pPos.y, pPos.z))!=null){
                if(c==1){
                    for(int i=0;i<carpisma_photon.ates_boyut+1-kısasol;i++){
                        ates.transform.GetChild(2).transform.localScale+=new Vector3((-1),0,0);
                        ates.transform.GetChild(2).transform.position+=new Vector3(0.5f,0,0);
                    }
                }
                c++;
                yıklan_duvarlar.SetTile(new Vector3Int (pPos.x-1-sayac, pPos.y, pPos.z), null); 
                PhotonNetwork.Instantiate("yikil_online",new Vector3 (bombapos.x-1-sayac, bombapos.y),Quaternion.identity);
                random_sayi= Rando(random_sayi,".");
                if(photonView.IsMine){
                    photonView.RPC("all",RpcTarget.All,bombapos,sayac,0,sayac,"sol");
                }
                sol_ugrama2=1;
                sayac=carpisma_photon.ates_boyut;
            }
        }
        for(sayac=0;sayac<carpisma_photon.ates_boyut;sayac++){
            if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x+1+sayac, pPos.y, pPos.z))==null){
                uzaklıksag(carpisma_photon.ates_boyut);
                if(sayac==carpisma_photon.ates_boyut-1){
                    //yield return new WaitForSeconds(0.6f);
                    //Destroy(ates);  Debug.Log("destroy");
                }
                // StartCoroutine(yok(ates));
            } 
            if(yıkılmayan.GetTile(new Vector3Int(pPos.x+1+sayac, pPos.y, pPos.z))!=null){ 
                Debug.Log("392 uzaklıik : "+(sayac+1));
                uzaklıksag2(carpisma_photon.ates_boyut);
                if(d1==1){
                    ates.transform.GetChild(1).transform.localScale+=new Vector3((kısasag2+1)*(-1),0,0);
                    ates.transform.GetChild(1).transform.position+=new Vector3((kısasag2+1)*(-0.5f),0,0);
                }
                d1++;
                // StartCoroutine(sag2(ates));
                //yield return new WaitForSeconds(0.60f);
                sag_ugrama1=1;
                // ates.transform.GetChild(1).transform.localScale+=new Vector3(kısasag2*(+1),0,0);
                // ates.transform.GetChild(1).transform.position+=new Vector3(kısasag2*(0.5f),0,0);
                sayac=carpisma_photon.ates_boyut;
                //Destroy(ates);  Debug.Log("destroy");
            }
            else if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x+1+sayac, pPos.y, pPos.z))!=null){
                if(d==1){
                    for(int i=0;i<carpisma_photon.ates_boyut+1-kısasag;i++){
                        ates.transform.GetChild(1).transform.localScale+=new Vector3((-1),0,0);
                        ates.transform.GetChild(1).transform.position+=new Vector3(-0.5f,0,0);
                    }
                }
                d++;
                yıklan_duvarlar.SetTile(new Vector3Int (pPos.x+1+sayac, pPos.y, pPos.z), null); 
                PhotonNetwork.Instantiate("yikil_online",new Vector3 (bombapos.x+1+sayac, bombapos.y),Quaternion.identity);
                random_sayi= Rando(random_sayi,".");
                if(photonView.IsMine){
                    photonView.RPC("all",RpcTarget.All,bombapos,sayac,0,sayac,"sag");
                }
                sag_ugrama2=1;
                sayac=carpisma_photon.ates_boyut;
            }
        }
        yield return new WaitForSeconds(0.59f);
        ates.SetActive(false);
        if(ust_ugrama1==1){
            yield return new WaitForSeconds(0.01f);   
            ates.transform.GetChild(4).transform.localScale+=new Vector3(kısaüst2*(+1),0,0); 
            ates.transform.GetChild(4).transform.position+=new Vector3(0,kısaüst2*(0.5f),0);
        }
        if(ust_ugrama2==1){
            yield return new WaitForSeconds(0.01f);   
            ates.transform.GetChild(4).transform.localScale+=new Vector3(kısaüst*1,0,0);
            ates.transform.GetChild(4).transform.position+=new Vector3(kısaüst*0,0.5f,0);
        }
        if(alt_ugrama1==1){
            yield return new WaitForSeconds(0.01f);   
            ates.transform.GetChild(3).transform.localScale+=new Vector3(kısaalt2*(+1),0,0);
            ates.transform.GetChild(3).transform.position+=new Vector3(0,kısaalt2*(-0.5f),0);
        }
        if(alt_ugrama2==1){
            yield return new WaitForSeconds(0.01f);   
            ates.transform.GetChild(3).transform.localScale+=new Vector3(kısaalt*(+1),0,0);
            ates.transform.GetChild(3).transform.position+=new Vector3(0,kısaalt*(-0.5f),0);
        }
        if(sol_ugrama1==1){
            yield return new WaitForSeconds(0.01f);   
            ates.transform.GetChild(2).transform.localScale+=new Vector3(kısasol2*(+1),0,0);
            ates.transform.GetChild(2).transform.position+=new Vector3(kısasol2*(-0.5f),0,0);
        }
        if(sol_ugrama2==1){
            yield return new WaitForSeconds(0.01f);   
            ates.transform.GetChild(2).transform.localScale+=new Vector3((1),0,0);
            ates.transform.GetChild(2).transform.position+=new Vector3(-0.5f,0,0);
        }
        if(sag_ugrama1==1){
            yield return new WaitForSeconds(0.01f);   
            ates.transform.GetChild(1).transform.localScale+=new Vector3(kısasag2*(+1),0,0);
            ates.transform.GetChild(1).transform.position+=new Vector3(kısasag2*(0.5f),0,0);
        }
        if(sag_ugrama2==1){
            yield return new WaitForSeconds(0.01f);   
            ates.transform.GetChild(1).transform.localScale+=new Vector3((1),0,0);
            ates.transform.GetChild(1).transform.position+=new Vector3(0.5f,0,0);
        }
        PhotonNetwork.Destroy(ates);
        void uzaklıküst(int x){
            int i=0;
            while(i<x){
                if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x, pPos.y+1+i, pPos.z))!=null){
                    kısaüst =(pPos.y+1+i)-((int)(bombapos.y));
                    i=x;
                }
                else{i++;}
            }
        }
        void uzaklıküst2(int x){
            int i=0; int xx=pPos.y+2;
            while(i<x){
                if(yıkılmayan.GetTile(new Vector3Int(pPos.x, xx-1+i, pPos.z))!=null){
                    kısaüst2 =(carpisma_photon.ates_boyut)-(i+1); Debug.Log("kısaüst2: "+kısaüst2); //atesboyut-uzklk
                    i=x;
                }
                else{i++;}
            }
        }
        [PunRPC]
        void uzaklıkalt(int x){
            int i=0;
            while(i<x){
                if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x, pPos.y-1-i, pPos.z))!=null){
                    kısaalt =((int)(bombapos.y))-(pPos.y-1-i);
                    i=x;
                }
                else{i++;}
            }
        }
        void uzaklıkalt2(int x){
            int i=0; int xx=pPos.y;
            while(i<x){
                if(yıkılmayan.GetTile(new Vector3Int(pPos.x, xx-1-i, pPos.z))!=null){
                    kısaalt2 =(carpisma_photon.ates_boyut)-(i+1);
                    i=x;
                }
                else{i++;}
            }
        }
        void uzaklıksol(int x){
            int i=0;
            while(i<x){
                if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x-1-i, pPos.y, pPos.z))!=null){
                    kısasol =((int)(bombapos.x))-(pPos.x-i-1);
                    i=x;
                }
                else{i++;}
            }
        }
        void uzaklıksag(int x){
            int i=0;
            while(i<x){
                if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x+1+i, pPos.y, pPos.z))!=null){
                    kısasag =((pPos.x+i+1)-(int)(bombapos.x));
                    i=x;
                }
                else{i++;}
            }
        }
        void uzaklıksol2(int x){
            int i=0; int xx=pPos.x-1;
            while(i<x){
                if(yıkılmayan.GetTile(new Vector3Int(xx-i, pPos.y, pPos.z))!=null){
                    kısasol2 = (carpisma_photon.ates_boyut)-(i+1);
                    i=x;
                }
                else{i++;}
            }
        }
        void uzaklıksag2(int x){
            int i=0;    int xx=pPos.x+1;
            while(i<x){
                if(yıkılmayan.GetTile(new Vector3Int(xx+i, pPos.y, pPos.z))!=null){
                    kısasag2 =(carpisma_photon.ates_boyut)-(i+1);
                    i=x;
                }
                else{i++;}
            }
        }
    }
}
    // }

    // private GameObject create_gift(Vector3 bomba,int sayacc,string i){
    //     if(i=="yukari"){
    //         hediye = Instantiate(ne,new Vector3 (bomba.x, bomba.y+1+sayacc),Quaternion.identity); 
    //         return hediye;
    //     }
    //     else if(i=="asagi"){
    //         hediye = Instantiate(ne,new Vector3 (bomba.x, bomba.y-1-sayacc),Quaternion.identity); 
    //         return hediye;
    //     }
    //     else if(i=="sag"){
    //         hediye = Instantiate(ne,new Vector3 (bomba.x+1+sayacc, bomba.y),Quaternion.identity); 
    //         return hediye;
    //     }
    //     hediye = Instantiate(ne,new Vector3 (bomba.x-1-sayacc, bomba.y),Quaternion.identity);
    //     return hediye;
    // }
    // private GameObject hediye_al(Vector3 bomba,int sayacc,GameObject hediye,GameObject ne,string i){
    //     if(i=="yukari"){
    //         hediye = Instantiate(ne,new Vector3 (bomba.x, bomba.y+1+sayacc),Quaternion.identity); 
    //         return hediye;
    //     }
    //     else if(i=="asagi"){
    //         hediye = Instantiate(ne,new Vector3 (bomba.x, bomba.y-1-sayacc),Quaternion.identity); 
    //         return hediye;
    //     }
    //     else if(i=="sag"){
    //         hediye = Instantiate(ne,new Vector3 (bomba.x+1+sayacc, bomba.y),Quaternion.identity); 
    //         return hediye;
    //     }
    //     hediye = Instantiate(ne,new Vector3 (bomba.x-1-sayacc, bomba.y),Quaternion.identity);
    //     return hediye;
    // }

    // private IEnumerator sag2(GameObject ates){
    //     yield return new WaitForSeconds(0.60f);
    //     Destroy(ates);  
    //     ates.transform.GetChild(1).transform.localScale+=new Vector3(kısasag2*(+1),0,0);
    //     ates.transform.GetChild(1).transform.position+=new Vector3(kısasag2*(0.5f),0,0);
    // }
    // private IEnumerator sol2(GameObject ates){
    //     yield return new WaitForSeconds(0.60f);
    //     Destroy(ates);  
    //     ates.transform.GetChild(2).transform.localScale+=new Vector3(kısasol2*(+1),0,0);
    //     ates.transform.GetChild(2).transform.position+=new Vector3(kısasol2*(-0.5f),0,0);
    // }
  
     // private IEnumerator eski_boyut(int eski_boyutt,int indis,int eksi_arti,string direction){
    //     yield return new WaitForSeconds(0.60f);
    //     Destroy(ates);  
    //     if(direction == "y"){
    //         ates.transform.GetChild(indis).transform.localScale+=new Vector3(eski_boyutt*(+1),0,0);
    //         ates.transform.GetChild(indis).transform.position+=new Vector3(0,eski_boyutt*(eksi_arti*0.5f),0);
    //     }
    //     else if(direction == "x"){
    //         ates.transform.GetChild(indis).transform.localScale+=new Vector3(eski_boyutt*(+1),0,0);
    //         ates.transform.GetChild(indis).transform.position+=new Vector3(eski_boyutt*(eksi_arti*0.5f),0,0);
    //     }
    // }

    // private IEnumerator asagi(GameObject ates,Vector3 bomba,Vector3Int pPos,int sayacc){
    //     yield return new WaitForSeconds(0.60f); 
    //     Destroy(ates);  
    //     ates.transform.GetChild(3).transform.localScale+=new Vector3(kısaalt*(+1),0,0);
    //     ates.transform.GetChild(3).transform.position+=new Vector3(0,kısaalt*(-0.5f),0);
    //     yield return new WaitForSeconds(0.05f);
        
    //     for(;sayacc<Carpisma.ates_boyut;sayacc++){
            
    //         if(random_sayi==0){
    //             shediye_bomba=hediye_al(bomba,sayacc,shediye_bomba,hediye_bomba,"asagi");
    //         }
    //         else if(random_sayi==1){
    //             shediye_ates=hediye_al(bomba,sayacc,shediye_ates,hediye_ates,"asagi");
    //         }
    //         else if(random_sayi==2){
    //             shediye_hiz=hediye_al(bomba,sayacc,shediye_hiz,hediye_hiz,"asagi");
    //         } 
    //         else if(random_sayi==3){
    //             shediye_ball=hediye_al(bomba,sayacc,shediye_ball,hediye_ball,"asagi");
    //         } 
    //         else if(random_sayi==4){
    //             shediye_tekme=hediye_al(bomba,sayacc,shediye_tekme,hediye_tekme,"asagi");
    //         } 
    //         else if(random_sayi==5){
    //             shediye_ates_az=hediye_al(bomba,sayacc,shediye_ates_az,hediye_ates_az,"asagi");
    //         } 
    //         else if(random_sayi==6){
    //             shediye_unknown=hediye_al(bomba,sayacc,shediye_unknown,hediye_unknown,"asagi");
    //         } 
    //         sayacc=Carpisma.ates_boyut; 
    //     }
    // }



    // private IEnumerator sol(GameObject ates,Vector3 bomba,Vector3Int pPos,int sayacc){
        
    //     yield return new WaitForSeconds(0.05f);
    //     for(;sayacc<Carpisma.ates_boyut;sayacc++){
    //         if(random_sayi==0){
    //             shediye_bomba=hediye_al(bomba,sayacc,shediye_bomba,hediye_bomba,"sol");
    //         }
    //         else if(random_sayi==1){
    //             shediye_ates=hediye_al(bomba,sayacc,shediye_ates,hediye_ates,"sol");
    //         }
    //         else if(random_sayi==2){
    //             shediye_hiz=hediye_al(bomba,sayacc,shediye_hiz,hediye_hiz,"sol");
    //         } 
    //         else if(random_sayi==3){
    //             shediye_ball=hediye_al(bomba,sayacc,shediye_ball,hediye_ball,"sol");
    //         } 
    //         else if(random_sayi==4){
    //             shediye_tekme=hediye_al(bomba,sayacc,shediye_tekme,hediye_tekme,"sol");
    //         } 
    //         else if(random_sayi==5){
    //             shediye_ates_az=hediye_al(bomba,sayacc,shediye_ates_az,hediye_ates_az,"sol");
    //         } 
    //         else if(random_sayi==6){
    //             shediye_unknown=hediye_al(bomba,sayacc,shediye_unknown,hediye_unknown,"sol");
    //         }
    //         sayacc=Carpisma.ates_boyut;
    //     }
    // }


    // private IEnumerator yuk(GameObject ates,Vector3 bomba,Vector3Int pPos,int sayacc){

        // yield return new WaitForSeconds(0.60f);
        // Destroy(ates); 
        // ates.transform.GetChild(4).transform.localScale+=new Vector3(1,0,0);
        // ates.transform.GetChild(4).transform.position+=new Vector3(0,0.5f,0);
    //     yield return new WaitForSeconds(0.05f);
    //     for(;sayacc<Carpisma.ates_boyut;sayacc++){
    //         if(random_sayi==0){
    //             PhotonNetwork.Instantiate("hediye_bomb_online",new Vector3 (bomba.x, bomba.y+1+sayacc),Quaternion.identity); 
    //         }
    //         else if(random_sayi==1){
    //             PhotonNetwork.Instantiate("hediye_ates_online",new Vector3 (bomba.x, bomba.y+1+sayacc),Quaternion.identity);
    //         }
    //         else if(random_sayi==2){
    //             PhotonNetwork.Instantiate("hediye_hiz_online",new Vector3 (bomba.x, bomba.y+1+sayacc),Quaternion.identity); 
    //         } 
    //         else if(random_sayi==3){
    //             PhotonNetwork.Instantiate("hediye_tekme_online",new Vector3 (bomba.x, bomba.y+1+sayacc),Quaternion.identity); 
    //         } 
    //         else if(random_sayi==4){
    //             PhotonNetwork.Instantiate("hediye_bilinmeyen_online",new Vector3 (bomba.x, bomba.y+1+sayacc),Quaternion.identity); 
    //         } 
    //         else if(random_sayi==5){
    //             PhotonNetwork.Instantiate("hediye_ates_az_online",new Vector3 (bomba.x, bomba.y+1+sayacc),Quaternion.identity); 
    //         } 
    //         sayacc=Carpisma.ates_boyut; 
    //     }
    // }


    // private IEnumerator sag(GameObject ates,Vector3 bomba,Vector3Int pPos,int sayacc){
    //     yield return new WaitForSeconds(0.60f);
    //     Destroy(ates); 
    //     ates.transform.GetChild(1).transform.localScale+=new Vector3((1),0,0);
    //     ates.transform.GetChild(1).transform.position+=new Vector3(0.5f,0,0);
    //     yield return new WaitForSeconds(0.05f);
    //     for(;sayacc<Carpisma.ates_boyut;sayacc++){
    //         if(random_sayi==0){
    //             shediye_bomba=hediye_al(bomba,sayacc,shediye_bomba,hediye_bomba,"sag");
    //         }
    //         else if(random_sayi==1){
    //             shediye_ates=hediye_al(bomba,sayacc,shediye_ates,hediye_ates,"sag");
    //         }
    //         else if(random_sayi==2){
    //             shediye_hiz=hediye_al(bomba,sayacc,shediye_hiz,hediye_hiz,"sag");
    //         } 
    //         else if(random_sayi==3){
    //             shediye_ball=hediye_al(bomba,sayacc,shediye_ball,hediye_ball,"sag");
    //         } 
    //         else if(random_sayi==4){
    //             shediye_tekme=hediye_al(bomba,sayacc,shediye_tekme,hediye_tekme,"sag");
    //         } 
    //         else if(random_sayi==5){
    //             shediye_ates_az=hediye_al(bomba,sayacc,shediye_ates_az,hediye_ates_az,"sag");
    //         } 
    //         else if(random_sayi==6){
    //             shediye_unknown=hediye_al(bomba,sayacc,shediye_unknown,hediye_unknown,"sag");
    //         }
    //         sayacc=Carpisma.ates_boyut;
    //     }
    // }
