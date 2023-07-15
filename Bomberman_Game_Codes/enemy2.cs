// using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemy2 : MonoBehaviour
{
    public Button kayıp_buton;
    public TMP_Text kaybetme;
    private float speed=9;
    public Transform[] movepoints;
    public GameObject p1,kayıp;
    private int randompos ,hedef=0;

    public float minx, miny , maxX , maxY , starttime=2,waittime ;
    public static int gecis = 0;
    void Start()
    {
        Time.timeScale=1f;
        waittime=starttime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            gecis = 4;
            Debug.Log("gecis: "+gecis);
        }
        move();
        
    }
    int rand(int i){
        if(i==0 || i==3) { 
            i = Random.Range(1,3);
            return i;
        }
        if(i==1 || i ==2){   
            i = Random.Range(1,3);
            if      (i==1){i =0;
            return i;}
            else if (i==2){i =3;
            return i;}
        }
        
        return i;
    }

    void move(){
        if(hedef==0){
            transform.position = Vector2.MoveTowards(transform.position,movepoints[hedef].position,speed * Time.deltaTime);
            
            if(Vector2.Distance(transform.position , movepoints[hedef].position) < 0.2f){
                if(transform.rotation.y!=0){
                    transform.rotation *= Quaternion.Euler(0, -180, 0);}
                if(waittime<=0){
                    hedef=rand(0);
                    waittime=starttime;
                    Debug.Log("move");
                    
                }
                else{ waittime -= Time.deltaTime;}
            }

        }
        else if(hedef==1){
            
            transform.position = Vector2.MoveTowards(transform.position,movepoints[hedef].position,speed * Time.deltaTime);
            
            if(Vector2.Distance(transform.position , movepoints[hedef].position) < 0.2f){
                if(transform.rotation.y!=0){
                    transform.rotation *= Quaternion.Euler(0, -180, 0);}
            
                if(waittime<=0){
                    if(transform.rotation.y!=0){
                }
                    hedef=rand(1);
                    waittime=starttime;
                    Debug.Log("move");
                    move();
                }
                else{ waittime -= Time.deltaTime;}
            }

        }
        else if(hedef==2){
            transform.position = Vector2.MoveTowards(transform.position,movepoints[hedef].position,speed * Time.deltaTime);
            
            if(Vector2.Distance(transform.position , movepoints[hedef].position) < 0.2f){
                if(transform.rotation.y==0){
                    transform.rotation *= Quaternion.Euler(0, +180, 0);
                }
            
                if(waittime<=0){
                    hedef=rand(2);
                    waittime=starttime;
                    Debug.Log("move");
                    move();
                }
                else{ waittime -= Time.deltaTime;}
            }

        }
        else if(hedef==3){
            
            transform.position = Vector2.MoveTowards(transform.position,movepoints[hedef].position,speed * Time.deltaTime);
            
            if(Vector2.Distance(transform.position , movepoints[hedef].position) < 0.2f){
                if(transform.rotation.y==0){
                    transform.rotation *= Quaternion.Euler(0, +180, 0);
                }
                if(waittime<=0){
                    hedef=rand(3);
                    waittime=starttime;
                    Debug.Log("move");
                    move();
                }
                else{ waittime -= Time.deltaTime;}
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other){

       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name=="Oyuncu 1"){
            Destroy(p1);
            kayıp.SetActive(true);
            StartCoroutine(bekle());
        }
        if(other.gameObject.tag=="asagi" || other.gameObject.tag=="start"|| other.gameObject.tag=="sag"||other.gameObject.tag=="sol"||other.gameObject.tag=="yukari"){
            Destroy(this.gameObject);
            gecis+=1;
            Debug.Log("gecis: "+gecis);
        }
    }
    private IEnumerator bekle(){
        yield return new WaitForSeconds(2f);
        kaybetme.text ="Yeni Oyun";
        kayıp_buton.enabled=true;
        Time.timeScale=0f;
    }
}
