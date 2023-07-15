using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
public class Carpisma : MonoBehaviour
{
    public Animator ölüm,deathoyuncu;
    public SpriteRenderer öl,oyuncudeath;
    public static int anlama=1,hediyee,ates_boyut=1,zamanbomb=0,tekme=0,x,y;
    private int sart_death=0;
    public Rigidbody2D coll;
    public GameObject ates,death1,p1;
    private Vector3 boyut,pozisyon;
    public AudioSource ses;
    public AudioClip clip,clip2,clip3,clip4,clip5,clip6;
    void Start()
    { 
        anlama=1;
        ilkboyut();
        ölüm=GetComponent<Animator>(); 
        öl=GetComponent<SpriteRenderer>();  
        coll=GetComponent<Rigidbody2D>();   
        ölüm.enabled=false;
        
    }
    private void ilkboyut(){
        for(int i=1;i<5;i++){
            ates.transform.GetChild(i).localScale=new Vector3(1,1,1);
            if(i==1)  ates.transform.GetChild(i).position=new Vector3(1f,0,0);
            else if(i==2)ates.transform.GetChild(i).position=new Vector3(-1f,0,0);
            else if(i==3)ates.transform.GetChild(i).position=new Vector3(0,-1f,0);
            else if(i==4)ates.transform.GetChild(i).position=new Vector3(0,1f,0);
        }
    }
    public void boyutartırım(int i){
        ates.transform.GetChild(i).localScale+=new Vector3(1,0,0);
    }
    public void boyutazalt(int i){
        ates.transform.GetChild(i).localScale+=new Vector3(-1,0,0);
    }
    private int xrandom(int y){
        y=Random.Range(0,5);
        return y;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(tekme==1 ){
            Debug.Log("temasss");   
            Debug.Log("isim"+other.gameObject.tag);   
            if(other.gameObject.tag=="bomb"){
                Debug.Log("temasss");   
                other.gameObject.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Dynamic;
            } 
        }
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
    void choose_music(int i){
        if(i==0 || i == 4){
            Debug.Log("i: "+i);
            ses.PlayOneShot(clip,1f);
        }
        if(i==1){
            Debug.Log("i: "+i);
            ses.PlayOneShot(clip2,1f);
        }
        if(i==2){
            Debug.Log("i: "+i);
            ses.PlayOneShot(clip3,1f);
        }
        if(i==3){
            Debug.Log("i: "+i);
            ses.PlayOneShot(clip4,1f);
        }
        if(i==5){
            Debug.Log("i: "+i);
            ses.PlayOneShot(clip5,1f);
        }
         if(i==6){ ses.PlayOneShot(clip6,1f); }
        
    }
    private void OnTriggerEnter2D(Collider2D duvar) {
        
        if(duvar.gameObject.tag=="isin1"){
            x=Randomcift(x); y=Randomy(y);
            gameObject.transform.position= new Vector3(gameObject.transform.position.x+x,gameObject.transform.position.y+y,0);
        }
        if(duvar.gameObject.tag=="isin2"){
            x=Randomcift(x); y=Randomy(y);
            gameObject.transform.position= new Vector3(gameObject.transform.position.x-x,gameObject.transform.position.y+y,0);

        }
        if(duvar.gameObject.tag=="isin3"){
            x=Randomcift(x); y=Randomy(y);
            gameObject.transform.position= new Vector3(gameObject.transform.position.x-x,gameObject.transform.position.y-y,0);
        }
        if(duvar.gameObject.tag=="isin4"){
            x=Randomcift(x); y=Randomy(y);
            gameObject.transform.position= new Vector3(gameObject.transform.position.x+x,gameObject.transform.position.y-y,0);
        }
        if(duvar.gameObject.tag == "ates"){
            Destroy(duvar.gameObject);
            ates_boyut++;
            foreach (Transform child in ates.transform)
            {
                if(child.tag == "sag"){
                    child.position += new Vector3 (0.5f,0,0);
                    boyutartırım(1);
                }
                else if(child.tag == "sol"){
                    child.position += new Vector3 (-0.5f,0,0);
                    boyutartırım(2);
                }
                else if(child.tag == "asagi"){
                    child.position += new Vector3 (0,-0.5f,0);
                    boyutartırım(3);
                }
                else if(child.tag == "yukari"){
                    child.position += new Vector3 (0,0.5f,0);
                    boyutartırım(4);
                }
            }
        }   
        else if(duvar.gameObject.tag=="bomba"){
            int i=0;    i=xrandom(i);
            choose_music(i);
            
            Destroy(duvar.gameObject);
            Bomb.bombsayi+=1;   
        }   
        else if(duvar.gameObject.tag=="hiz"){
            int i=0;    i=xrandom(i);
            choose_music(i);
            Destroy(duvar.gameObject);
            Hareket.hiz+=0.5f;
        }   
        else if(duvar.gameObject.tag=="ball"){
            int i=0;    i=xrandom(i);
            choose_music(i);
            Destroy(duvar.gameObject);
            zamanbomb=1;
        }
        else if(duvar.gameObject.tag=="kick"){ 
            int i=0;    i=xrandom(i);
            choose_music(i);
            Destroy(duvar.gameObject);
            tekme=1;
        }
        else if(duvar.gameObject.tag=="fire_down"){
            int i=0;    i=xrandom(i);
            choose_music(i);
            Destroy(duvar.gameObject);
            if(ates_boyut>=2){
                ates_boyut--;
                foreach (Transform child in ates.transform)
                {
                    if(child.tag == "sag"){
                        child.position += new Vector3 (-0.5f,0,0);
                        boyutazalt(1);
                    }
                    else if(child.tag == "sol"){
                        child.position += new Vector3 (+0.5f,0,0);
                        boyutazalt(2);
                    }
                    else if(child.tag == "asagi"){
                        child.position += new Vector3 (0,+0.5f,0);
                        boyutazalt(3);
                    }
                    else if(child.tag == "yukari"){
                        child.position += new Vector3 (0,-0.5f,0);
                        boyutazalt(4);
                    }
                }
            }
        }
        else if(duvar.gameObject.tag=="unknown"){
            int y=0;    y=xrandom(y);
            choose_music(y);
            Destroy(duvar.gameObject);
            int i=0;    i=xrandom(i);
            if(i==0){
                ates_boyut++;
                foreach (Transform child in ates.transform){
                    if(child.tag == "sag"){
                        child.position += new Vector3 (0.5f,0,0);
                        boyutartırım(1);
                    }
                    else if(child.tag == "sol"){
                        child.position += new Vector3 (-0.5f,0,0);
                        boyutartırım(2);
                    }
                    else if(child.tag == "asagi"){
                        child.position += new Vector3 (0,-0.5f,0);
                        boyutartırım(3);
                    }
                    else if(child.tag == "yukari"){
                        child.position += new Vector3 (0,0.5f,0);
                        boyutartırım(4);
                    }
                    Destroy(duvar.gameObject);
                } 
            }
            else if(i==1){
                Bomb.bombsayi+=1;  
            }
            else if(i==2){
                Hareket.hiz+=0.5f; 
            }
            else if(i==3){
                Destroy(duvar.gameObject);
                tekme=1;
            }
            else if(i==4){
                Destroy(duvar.gameObject);
                if(ates_boyut>=2){
                    ates_boyut--;
                    foreach (Transform child in ates.transform)
                    {
                        if(child.tag == "sag"){
                            child.position += new Vector3 (-0.5f,0,0);
                            boyutazalt(1);
                        }
                        else if(child.tag == "sol"){
                            child.position += new Vector3 (+0.5f,0,0);
                            boyutazalt(2);
                        }
                        else if(child.tag == "asagi"){
                            child.position += new Vector3 (0,+0.5f,0);
                            boyutazalt(3);
                        }
                        else if(child.tag == "yukari"){
                            child.position += new Vector3 (0,-0.5f,0);
                            boyutazalt(4);
                        }
                    }
                }
            }
        }   
        if(duvar.gameObject.tag=="sol"||duvar.gameObject.tag=="sag"||duvar.gameObject.tag=="asagi"||duvar.gameObject.tag=="yukari"){
            Debug.Log("öl");
            sart_death+=1;
            transform.position =new Vector2(transform.position.x,transform.position.y+0.4f);
            coll.constraints=RigidbodyConstraints2D.FreezeAll;
            anlama=2;
            StartCoroutine (Ölü());
            SpriteRendUp.spriteRen.enabled=false;
            SpriteRendDown.spriteRen.enabled=false;
            SpriteRendLeft.spriteRen.enabled=false;
            SpriteRendRight.spriteRen.enabled=false;
            gameObject.transform.position= new Vector3 (-40,-40,0);
            
            
        }
    }
    private IEnumerator Ölü(){
        if(sart_death==1){
            GameObject xx=Instantiate(death1,gameObject.transform.position,Quaternion.identity);
            deathoyuncu=xx.GetComponent<Animator>(); 
            oyuncudeath=xx.GetComponent<SpriteRenderer>();
           
            deathoyuncu.enabled=true;
            oyuncudeath.enabled=true;
            
            yield return new WaitForSeconds(1.2f);
            deathoyuncu.enabled=false;
            yield return new WaitForSeconds(0.2f);
            choose_music(5);
            oyuncudeath.enabled = false;
            yield return new WaitForSeconds(0.5f);
            Destroy(xx);
            yield return new WaitForSeconds(1.0f);
            GameObject player1 = p1;
            yield return new WaitForSeconds(0.2f);
            Destroy(player1);
        }
        else{
        }
    }
}
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