using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Bomb3 : MonoBehaviour
{
    public KeyCode input = KeyCode.Space;
    public GameObject bombprefab,atesprefab,oyuncu,hediye_ates,hediye_bomba,hediye_hiz,hediye_unknown,hediye_ball,hediye_tekme3,hediye_ates_az;
    public static GameObject shediye_ates,shediye_bomba,shediye_hiz,shediye_unknown,shediye_ball,shediye_tekme3,shediye_ates_az;
    public float patlama = 3f,fark1,fark2;
    public static int bombsayi = 2,random_sayi,kısaüst=1,kısaalt=1,kısasag=1,kısasol=1 ,kısaüst2=1,kısaalt2=1,kısasag2=1,kısasol2=1;
    private int i,sayac,yön,a,b,c,d,a1,b1,c1,d1,x,y;
    public Vector2 bombapos,bombapos2,posit;
    [Header("Yıkilmayan")]
    Vector3Int gridPlace2,gridPlace ;
    public Tilemap yıkılmayan, yıklan_duvarlar;  
    [Header("Yıkılan")]
    public Yıkılan duvar_prefab;
    public AudioSource ses;
    public AudioClip clip;

    private void  Start(){
        
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
    
    private void  Update() {
        if(Input.GetKeyDown(input) && bombsayi>0){
            StartCoroutine(PlaceBomb(bombapos));
        }
        if(Input.GetKeyDown(KeyCode.F1)){
            Application.Quit();
        }
    }
    private float fark(float i){
        
        i=oyuncu.transform.position.x-bombapos.x; 
        return i;
    } 
    private float farkk(float j){
        
        j=oyuncu.transform.position.y-bombapos.y;
        return j;
    } 
    private int Randomm(int sayi){
        sayi = Random.Range(0,7);
        //sayi=4;
        return sayi;
    }
    private int Randomcift(int sayi){
        sayi = Random.Range(6,16);
        if(sayi%2!=0){
            sayi+=1;
        }
        return sayi;
    }
     private int Randomy(int sayi){
        sayi = Random.Range(-1,-5);
        return sayi;
    }
    private GameObject hediye_al_yuk(Vector3 bomba,int sayacc,GameObject hediye,GameObject ne){
        hediye = Instantiate(ne,new Vector3 (bomba.x, bomba.y+1+sayacc),Quaternion.identity); 
        return hediye;
    }
    private GameObject hediye_al_as(Vector3 bomba,int sayacc,GameObject hediye,GameObject ne){
        hediye = Instantiate(ne,new Vector3 (bomba.x, bomba.y-1-sayacc),Quaternion.identity);
        return hediye;
    }
    private GameObject hediye_al_sag(Vector3 bomba,int sayacc,GameObject hediye,GameObject ne){
        hediye = Instantiate(ne,new Vector3 (bomba.x+1+sayacc, bomba.y),Quaternion.identity);
        return hediye;
    }
    private GameObject hediye_al_sol(Vector3 bomba,int sayacc,GameObject hediye,GameObject ne){
        hediye = Instantiate(ne,new Vector3 (bomba.x-1-sayacc, bomba.y),Quaternion.identity);
        return hediye;
    }
    private IEnumerator asagi(GameObject ates,Vector3 bomba,Vector3Int pPos,int sayacc){
        yield return new WaitForSeconds(0.60f); 
        Destroy(ates);  
        ates.transform.GetChild(3).transform.localScale+=new Vector3(kısaalt*(+1),0,0);
        ates.transform.GetChild(3).transform.position+=new Vector3(0,kısaalt*(-0.5f),0);
        yield return new WaitForSeconds(0.05f);
        
        for(;sayacc<Carpisma3.ates_boyut;sayacc++){
            
            if(random_sayi==0){
                shediye_bomba=hediye_al_as(bomba,sayacc,shediye_bomba,hediye_bomba);
            }
            else if(random_sayi==1){
                shediye_ates=hediye_al_as(bomba,sayacc,shediye_ates,hediye_ates);
            }
            else if(random_sayi==2){
                shediye_hiz=hediye_al_as(bomba,sayacc,shediye_hiz,hediye_hiz);
            } 
            else if(random_sayi==3){
                shediye_ball=hediye_al_as(bomba,sayacc,shediye_ball,hediye_ball);
            } 
            else if(random_sayi==4){
                shediye_tekme3=hediye_al_as(bomba,sayacc,shediye_tekme3,hediye_tekme3);
            } 
            else if(random_sayi==5){
                shediye_ates_az=hediye_al_as(bomba,sayacc,shediye_ates_az,hediye_ates_az);
            } 
            else if(random_sayi==6){
                shediye_unknown=hediye_al_as(bomba,sayacc,shediye_unknown,hediye_unknown);
            } 
            sayacc=Carpisma3.ates_boyut; 
        }
    }
    private IEnumerator asagi2(GameObject ates){
        yield return new WaitForSeconds(0.60f);
        Destroy(ates);  
        ates.transform.GetChild(3).transform.localScale+=new Vector3(kısaalt2*(+1),0,0);
        ates.transform.GetChild(3).transform.position+=new Vector3(0,kısaalt2*(-0.5f),0);
    }
    private IEnumerator yuk(GameObject ates,Vector3 bomba,Vector3Int pPos,int sayacc){

        yield return new WaitForSeconds(0.60f);
        Destroy(ates); 
        ates.transform.GetChild(4).transform.localScale+=new Vector3(kısaüst*(1),0,0);
        ates.transform.GetChild(4).transform.position+=new Vector3(0,kısaüst*(0.5f),0);
        yield return new WaitForSeconds(0.05f);
        for(;sayacc<Carpisma3.ates_boyut;sayacc++){
            if(random_sayi==0){
                shediye_bomba=hediye_al_yuk(bomba,sayacc,shediye_bomba,hediye_bomba);
            }
            else if(random_sayi==1){
                shediye_ates=hediye_al_yuk(bomba,sayacc,shediye_ates,hediye_ates);
            }
            else if(random_sayi==2){
                shediye_hiz=hediye_al_yuk(bomba,sayacc,shediye_hiz,hediye_hiz);
            } 
            else if(random_sayi==3){
                shediye_ball=hediye_al_yuk(bomba,sayacc,shediye_ball,hediye_ball);
            } 
            else if(random_sayi==4){
                shediye_tekme3=hediye_al_yuk(bomba,sayacc,shediye_tekme3,hediye_tekme3);
            } 
            else if(random_sayi==5){
                shediye_ates_az=hediye_al_yuk(bomba,sayacc,shediye_ates_az,hediye_ates_az);
            } 
            else if(random_sayi==6){
                shediye_unknown=hediye_al_yuk(bomba,sayacc,shediye_unknown,hediye_unknown);
            }
            sayacc=Carpisma3.ates_boyut; 
        }
    }
    private IEnumerator yuk2(GameObject ates){
        yield return new WaitForSeconds(0.60f);
        Destroy(ates);  
        ates.transform.GetChild(4).transform.localScale+=new Vector3(kısaüst2*(+1),0,0); //ates_boyut-uzklk-1
        ates.transform.GetChild(4).transform.position+=new Vector3(0,kısaüst2*(0.5f),0);
    }
    private IEnumerator sol(GameObject ates,Vector3 bomba,Vector3Int pPos,int sayacc){
        yield return new WaitForSeconds(0.60f);   
        Destroy(ates); 
        ates.transform.GetChild(2).transform.localScale+=new Vector3((1),0,0);
        ates.transform.GetChild(2).transform.position+=new Vector3(-0.5f,0,0);
        yield return new WaitForSeconds(0.05f);
        for(;sayacc<Carpisma3.ates_boyut;sayacc++){
            if(random_sayi==0){
                shediye_bomba=hediye_al_sol(bomba,sayacc,shediye_bomba,hediye_bomba);
            }
            else if(random_sayi==1){
                shediye_ates=hediye_al_sol(bomba,sayacc,shediye_ates,hediye_ates);
            }
            else if(random_sayi==2){
                shediye_hiz=hediye_al_sol(bomba,sayacc,shediye_hiz,hediye_hiz);
            } 
            else if(random_sayi==3){
                shediye_ball=hediye_al_sol(bomba,sayacc,shediye_ball,hediye_ball);
            } 
            else if(random_sayi==4){
                shediye_tekme3=hediye_al_sol(bomba,sayacc,shediye_tekme3,hediye_tekme3);
            } 
            else if(random_sayi==5){
                shediye_ates_az=hediye_al_sol(bomba,sayacc,shediye_ates_az,hediye_ates_az);
            } 
            else if(random_sayi==6){
                shediye_unknown=hediye_al_sol(bomba,sayacc,shediye_unknown,hediye_unknown);
            }
            sayacc=Carpisma3.ates_boyut;
        }
    }
    private IEnumerator sol2(GameObject ates){
        yield return new WaitForSeconds(0.60f);
        Destroy(ates);  
        ates.transform.GetChild(2).transform.localScale+=new Vector3(kısasol2*(+1),0,0);
        ates.transform.GetChild(2).transform.position+=new Vector3(kısasol2*(-0.5f),0,0);
    }
    private IEnumerator sag(GameObject ates,Vector3 bomba,Vector3Int pPos,int sayacc){
        yield return new WaitForSeconds(0.60f);
        Destroy(ates); 
        ates.transform.GetChild(1).transform.localScale+=new Vector3((1),0,0);
        ates.transform.GetChild(1).transform.position+=new Vector3(0.5f,0,0);
        yield return new WaitForSeconds(0.05f);
        for(;sayacc<Carpisma3.ates_boyut;sayacc++){
            if(random_sayi==0){
                shediye_bomba=hediye_al_sag(bomba,sayacc,shediye_bomba,hediye_bomba);
            }
            else if(random_sayi==1){
                shediye_ates=hediye_al_sag(bomba,sayacc,shediye_ates,hediye_ates);
            }
            else if(random_sayi==2){
                shediye_hiz=hediye_al_sag(bomba,sayacc,shediye_hiz,hediye_hiz);
            } 
            else if(random_sayi==3){
                shediye_ball=hediye_al_sag(bomba,sayacc,shediye_ball,hediye_ball);
            } 
            else if(random_sayi==4){
                shediye_tekme3=hediye_al_sag(bomba,sayacc,shediye_tekme3,hediye_tekme3);
            } 
            else if(random_sayi==5){
                shediye_ates_az=hediye_al_sag(bomba,sayacc,shediye_ates_az,hediye_ates_az);
            } 
            else if(random_sayi==6){
                shediye_unknown=hediye_al_sag(bomba,sayacc,shediye_unknown,hediye_unknown);
            }
            sayacc=Carpisma3.ates_boyut;
        }
    }
    private IEnumerator sag2(GameObject ates){
        yield return new WaitForSeconds(0.60f);
        Destroy(ates);  
        ates.transform.GetChild(1).transform.localScale+=new Vector3(kısasag2*(+1),0,0);
        ates.transform.GetChild(1).transform.position+=new Vector3(kısasag2*(0.5f),0,0);
    }
    private IEnumerator yok(GameObject ates){
        yield return new WaitForSeconds(0.60f);
        Destroy(ates); 
        yield return new WaitForSeconds(0.05f);
    }
    private IEnumerator PlaceBomb(Vector3 bombapos){
        bombapos=new Vector2(Mathf.RoundToInt(oyuncu.transform.position.x),Mathf.RoundToInt(oyuncu.transform.position.y));
        Vector3 tilePosition;
        Vector3Int coordinate = new Vector3Int(0, 0, 0);
        tilePosition = yıklan_duvarlar.CellToWorld(coordinate);

        Vector3 tilePosition2;
        Vector3Int coordinate2 = new Vector3Int(0, 0, 0);
        tilePosition2 = yıkılmayan.CellToWorld(coordinate2);
        GameObject Bomb = Instantiate(bombprefab,bombapos , Quaternion.identity);
        if(Carpisma3.tekme3==1 ){
            Debug.Log("tekme3 1");
            Bomb.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Dynamic;
        }
        bombsayi--;
        
        yield return new WaitForSeconds(0.5f);
        Bomb.GetComponent<BoxCollider2D>().isTrigger=false;
        yield return new WaitForSeconds(patlama-1.29f);
        ses.PlayOneShot(clip,0.7f);
        yield return new WaitForSeconds(0.2f);
        bombapos=new Vector2(Mathf.RoundToInt(Bomb.transform.position.x),Mathf.RoundToInt(Bomb.transform.position.y));
        yield return new WaitForSeconds(0.1f);
        Destroy(Bomb);
        bombsayi++;  Carpisma3.zamanbomb=0;

        var pPos =  yıklan_duvarlar.WorldToCell(bombapos); var pPos2 =  yıkılmayan.WorldToCell(bombapos);
        
        kısaüst=1; kısaalt=1; kısasag=1; kısasol=1;  kısaüst2=1; kısaalt2=1; kısasag2=1; kısasol2=1; a=1; b=1; c=1; d=1; a1=1; b1=1; c1=1; d1=1;
      
        uzaklıküst(Carpisma3.ates_boyut) ;uzaklıksag(Carpisma3.ates_boyut);    ;uzaklıksag2(Carpisma3.ates_boyut); uzaklıküst2(Carpisma3.ates_boyut); 
        uzaklıkalt(Carpisma3.ates_boyut) ;uzaklıksol(Carpisma3.ates_boyut);    uzaklıkalt2(Carpisma3.ates_boyut) ;uzaklıksol2(Carpisma3.ates_boyut);
        
        GameObject ates = Instantiate(atesprefab,bombapos,Quaternion.identity);
        
        for(sayac=0;sayac<Carpisma3.ates_boyut;sayac++){
            if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x, pPos.y-1-sayac, pPos.z))==null){    
                uzaklıkalt(Carpisma3.ates_boyut);
                StartCoroutine(yok(ates));
            } 
            if(yıkılmayan.GetTile(new Vector3Int(pPos2.x, pPos2.y-1-sayac, pPos2.z))!=null){  
                uzaklıkalt2(Carpisma3.ates_boyut);
                if(a1==1){
                    ates.transform.GetChild(3).transform.localScale+=new Vector3((kısaalt2+1)*(-1),0,0);
                    ates.transform.GetChild(3).transform.position+=new Vector3(0,(kısaalt2+1)*(0.5f),0);
                }
                a1++;
                StartCoroutine(asagi2(ates));
                sayac=Carpisma3.ates_boyut;
            }
            else if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x, pPos.y-1-sayac, pPos.z))!=null){  
                
                if(a==1){
                    for(int i=0;i<Carpisma3.ates_boyut+2-kısaalt;i++){
                        ates.transform.GetChild(3).transform.localScale+=new Vector3((-1),0,0);
                        ates.transform.GetChild(3).transform.position+=new Vector3(0,(0.5f),0);
                    }
                }
                a++;
                yıklan_duvarlar.SetTile(new Vector3Int (pPos.x, pPos.y-1-sayac, pPos.z), null); 
                Instantiate(duvar_prefab,new Vector3 (bombapos.x, bombapos.y-1-sayac),Quaternion.identity);
                
                random_sayi= Randomm(random_sayi);
                StartCoroutine(asagi(ates,bombapos,pPos,sayac));
                sayac=Carpisma3.ates_boyut;
            }
        }
        for(sayac=0;sayac<Carpisma3.ates_boyut;sayac++){
            if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x, pPos.y+1+sayac, pPos.z))==null){
                uzaklıküst(Carpisma3.ates_boyut);
                StartCoroutine(yok(ates));
            } 
            if(yıkılmayan.GetTile(new Vector3Int(pPos2.x, pPos2.y+1+sayac, pPos2.z))!=null){
                uzaklıküst2(Carpisma3.ates_boyut);
                if(b1==1){
                    ates.transform.GetChild(4).transform.localScale+=new Vector3((kısaüst2+1)*(-1),0,0);
                    ates.transform.GetChild(4).transform.position+=new Vector3(0,(kısaüst2+1)*(-0.5f),0);
                }
                b1++;
                StartCoroutine(yuk2(ates));
                sayac=Carpisma3.ates_boyut;
            }
            else if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x, pPos.y+1+sayac, pPos.z))!=null){
                if(b==1){
                    for(int i=0;i<Carpisma3.ates_boyut-kısaüst;i++){
                        ates.transform.GetChild(4).transform.localScale+=new Vector3((-1),0,0);
                        ates.transform.GetChild(4).transform.position+=new Vector3(0,(-0.5f),0);
                    }
                }
                b++;
                yıklan_duvarlar.SetTile(new Vector3Int (pPos.x, pPos.y+1+sayac, pPos.z), null); 
                
                Instantiate(duvar_prefab,new Vector3 (bombapos.x, bombapos.y+1+sayac),Quaternion.identity);
                
                random_sayi= Randomm(random_sayi);
                StartCoroutine(yuk(ates,bombapos,pPos,sayac));
                sayac=Carpisma3.ates_boyut;
            }
        }
        for(sayac=0;sayac<Carpisma3.ates_boyut;sayac++){

            if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x-1-sayac, pPos.y, pPos.z))==null){
                uzaklıksol(Carpisma3.ates_boyut);
                StartCoroutine(yok(ates));
            } 
            if(yıkılmayan.GetTile(new Vector3Int(pPos2.x-1-sayac, pPos2.y, pPos2.z))!=null){ 
                uzaklıksol2(Carpisma3.ates_boyut);
                if(c1==1){
                    ates.transform.GetChild(2).transform.localScale+=new Vector3((kısasol2+1)*(-1),0,0);
                    ates.transform.GetChild(2).transform.position+=new Vector3((kısasol2+1)*(0.5f),0,0);
                }
                c1++;
                StartCoroutine(sol2(ates));
                sayac=Carpisma3.ates_boyut;
            }
            else if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x-1-sayac, pPos.y, pPos.z))!=null){
                if(c==1){
                    for(int i=0;i<Carpisma3.ates_boyut+1-kısasol;i++){
                        ates.transform.GetChild(2).transform.localScale+=new Vector3((-1),0,0);
                        ates.transform.GetChild(2).transform.position+=new Vector3(0.5f,0,0);
                    }
                }
                c++;
                yıklan_duvarlar.SetTile(new Vector3Int (pPos.x-1-sayac, pPos.y, pPos.z), null); 
                Instantiate(duvar_prefab,new Vector3 (bombapos.x-1-sayac, bombapos.y),Quaternion.identity);
                
                random_sayi= Randomm(random_sayi);
                StartCoroutine(sol(ates,bombapos,pPos,sayac));
                sayac=Carpisma3.ates_boyut;
            }
        }
        for(sayac=0;sayac<Carpisma3.ates_boyut;sayac++){
            if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x+1+sayac, pPos.y, pPos.z))==null){
                uzaklıksag(Carpisma3.ates_boyut);
                StartCoroutine(yok(ates));
            } 
            if(yıkılmayan.GetTile(new Vector3Int(pPos2.x+1+sayac, pPos2.y, pPos2.z))!=null){ 
                uzaklıksag2(Carpisma3.ates_boyut);
                if(d1==1){
                    ates.transform.GetChild(1).transform.localScale+=new Vector3((kısasag2+1)*(-1),0,0);
                    ates.transform.GetChild(1).transform.position+=new Vector3((kısasag2+1)*(-0.5f),0,0);
                }
                d1++;
                StartCoroutine(sag2(ates));
                sayac=Carpisma3.ates_boyut;
            }
            else if(yıklan_duvarlar.GetTile(new Vector3Int(pPos.x+1+sayac, pPos.y, pPos.z))!=null){
                if(d==1){
                    for(int i=0;i<Carpisma3.ates_boyut+1-kısasag;i++){
                        ates.transform.GetChild(1).transform.localScale+=new Vector3((-1),0,0);
                        ates.transform.GetChild(1).transform.position+=new Vector3(-0.5f,0,0);
                    }
                }
                d++;
                yıklan_duvarlar.SetTile(new Vector3Int (pPos.x+1+sayac, pPos.y, pPos.z), null); 
                Instantiate(duvar_prefab,new Vector3 (bombapos.x+1+sayac, bombapos.y),Quaternion.identity);
                
                random_sayi= Randomm(random_sayi);
                StartCoroutine(sag(ates,bombapos,pPos,sayac));
                sayac=Carpisma3.ates_boyut;
            }
        }
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
            int i=0; int xx=pPos2.y+2;
            while(i<x){
                if(yıkılmayan.GetTile(new Vector3Int(pPos2.x, xx-1+i, pPos2.z))!=null){
                    kısaüst2 =(Carpisma3.ates_boyut)-(i+1); Debug.Log("kısaüst2: "+kısaüst2); //atesboyut-uzklk
                    i=x;
                }
                else{i++;}
            }
        }
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
            int i=0; int xx=pPos2.y;
            while(i<x){
                if(yıkılmayan.GetTile(new Vector3Int(pPos2.x, xx-1-i, pPos2.z))!=null){
                    kısaalt2 =(Carpisma3.ates_boyut)-(i+1);
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
            int i=0; int xx=pPos2.x-1;
            while(i<x){
                if(yıkılmayan.GetTile(new Vector3Int(xx-i, pPos2.y, pPos2.z))!=null){
                    kısasol2 = (Carpisma3.ates_boyut)-(i+1);
                    i=x;
                }
                else{i++;}
            }
        }
        void uzaklıksag2(int x){
            int i=0;    int xx=pPos2.x+1;
            while(i<x){
                if(yıkılmayan.GetTile(new Vector3Int(xx+i, pPos2.y, pPos2.z))!=null){
                    kısasag2 =(Carpisma3.ates_boyut)-(i+1);
                    i=x;
                }
                else{i++;}
            }
        }
    }
}