using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class harita_secim : MonoBehaviour
{
    public GameObject harita1,harita2,harita3,harita4,harita5;
    public static int i=2;
    void Start()
    { 
      harita2.SetActive(false);  
      harita3.SetActive(false);  
      harita4.SetActive(false);  
      harita5.SetActive(false);  
    }
    public void sagbutton(){
        
        if(harita1.activeInHierarchy){
            i=3;
            harita1.SetActive(false);
            harita3.SetActive(false);  
            harita4.SetActive(false);  
            harita5.SetActive(false);  
            harita2.SetActive(true);
        }
        else if(harita2.activeInHierarchy){
            i=4;
            harita1.SetActive(false);
            harita2.SetActive(false);
            harita4.SetActive(false);
            harita5.SetActive(false);
            harita3.SetActive(true);
        }
        else if(harita3.activeInHierarchy){
            i=5;
            harita1.SetActive(false);
            harita2.SetActive(false);
            harita3.SetActive(false);
            harita5.SetActive(false);
            harita4.SetActive(true);
        }
        else if(harita4.activeInHierarchy){
            i=6;
            harita1.SetActive(false);
            harita2.SetActive(false);
            harita3.SetActive(false);
            harita4.SetActive(false);
            harita5.SetActive(true);
        }
        
    }
    public void solbutton(){
        if(harita2.activeInHierarchy){
            i=2;
            harita2.SetActive(false);
            harita3.SetActive(false);
            harita4.SetActive(false);
            harita5.SetActive(false);
            harita1.SetActive(true);
        }
        else if(harita3.activeInHierarchy){
            i=3;
            harita1.SetActive(false);
            harita3.SetActive(false);  
            harita4.SetActive(false);  
            harita5.SetActive(false);  
            harita2.SetActive(true);
        }
        else if(harita4.activeInHierarchy){
            i=4;
            harita1.SetActive(false);
            harita2.SetActive(false);
            harita4.SetActive(false);
            harita5.SetActive(false);
            harita3.SetActive(true);
        }
        else if(harita5.activeInHierarchy){
            i=5;
            harita1.SetActive(false);
            harita2.SetActive(false);  
            harita3.SetActive(false);  
            harita5.SetActive(false);  
            harita4.SetActive(true);
        }
        
    }
}
//  if(oyuncu.transform.position.x>=-15 &&  oyuncu.transform.position.x<=-14.7 &&
//            oyuncu.transform.position.y<=6.4 &&  oyuncu.transform.position.y>=5.8 ){

//             x=Randomcift(x); y=Randomy(y);
//             oyuncu.transform.position= new Vector3(oyuncu.transform.position.x+x,oyuncu.transform.position.y+y,0);

//         }
//         if(oyuncu.transform.position.x>=-15 &&  oyuncu.transform.position.x<=-14.7 &&
//            oyuncu.transform.position.y<=-1.7 &&  oyuncu.transform.position.y>=-2.35 ){

//             x=Randomcift(x); y=Randomy(y);
//             oyuncu.transform.position= new Vector3(oyuncu.transform.position.x+x,oyuncu.transform.position.y-y,0);

//         }
//         if(oyuncu.transform.position.x>=10.7 &&  oyuncu.transform.position.x<=11.2 &&
//            oyuncu.transform.position.y<=6.4 &&  oyuncu.transform.position.y>=5.8 ){

//             x=Randomcift(x); y=Randomy(y);
//             oyuncu.transform.position= new Vector3(oyuncu.transform.position.x-x,oyuncu.transform.position.y+y,0);

//         }
//         if(oyuncu.transform.position.x>=10.7 &&  oyuncu.transform.position.x<=11.2 &&
//            oyuncu.transform.position.y<=-1.7 &&  oyuncu.transform.position.y>=-2.35 ){

//             x=Randomcift(x); y=Randomy(y);
//             oyuncu.transform.position= new Vector3(oyuncu.transform.position.x-x,oyuncu.transform.position.y-y,0);

//         }