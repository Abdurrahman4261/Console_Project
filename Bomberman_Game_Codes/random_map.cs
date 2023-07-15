using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class random_map : MonoBehaviour
{
    public Tilemap yıkılabilen,yıkılamayan;     public Grid yıkılan;    public Tile yıkılabil,yıkılmaz;  public Vector3Int posit,posit2; 
    public int [,] pozis = new int[100,2];  public int [,] pozis2 = new int[100,2] ; private int i=0,i2=0;
    void Start()
    {
        rand();
        rand2();
    }
    private void rand(){
        for(;i<238;i++){
            int x=Random.Range(-15,12); int y=Random.Range(-5,9);   
            
            Debug.Log("x: "+x +" y: "+y);
            
            posit= new Vector3Int(x,y,0);   Debug.Log("pozis: "+posit); 
             
            if(yıkılabilen.GetTile(new Vector3Int(posit.x,posit.y-1,0))!=null || yıkılamayan.GetTile(new Vector3Int(posit.x,posit.y-1,0))!=null){
                Debug.Log("s1");    i--;    continue;
            }
            if(x==-15 && y==8 || x==-14 && y==8 || x==-15 && y==7 || x==11 && y==8 || x==10 && y==8 || x==11 && y==7 || x==-15 && y==-4 
            || x==-14 && y==-5 || x==-15 && y==-5 ||x==11 && y==-5 ||x==11 && y==-4 ||x==10 && y==-5 ||x==-4 && y==0 ||x==-4 && y==1 ||x==-4 && y==2 ||x==-4 && y==3
            ||x==-3 && y==0 ||x==-3 && y==1 ||x==-3 && y==2  ||x==-3 && y==3
            ||x==-2 && y==0 ||x==-2 && y==1 ||x==-2 && y==2  ||x==-2 && y==3 ||x==-1 && y==0 ||x==-1 && y==1 ||x==-1 && y==2 ||x==-1 && y==3 ||x==0 && y==0 ||x==0 && y==1 ||x==0 && y==2 ||x==0 && y==3) {
                i--;    continue;
            }
            yıkılabilen.SetTile(yıkılabilen.WorldToCell(posit), yıkılabil);
        }
    }
    private void rand2(){
        for(;i2<85;i2++){
            //toplam 334
            int x2=Random.Range(-15,12); int y2=Random.Range(-5,9); Debug.Log("x2: "+x2 +" y2: "+y2+" i2: "+i2+"mmm "+yıkılabilen.GetTile(new Vector3Int(posit2.x,posit2.y+1,0)));
            
            posit2= new Vector3Int(x2,y2,0);

            if(yıkılabilen.GetTile(new Vector3Int(posit2.x,posit2.y-1,0))!=null || yıkılamayan.GetTile(new Vector3Int(posit2.x,posit2.y-1,0))!=null){
                
                Debug.Log("s2 i2: "+i2);    i2--;    continue;
            }
            if(x2==-15 && y2==8 || x2==-14 && y2==8 || x2==-15 && y2==7 || x2==11 && y2==8 || x2==10 && y2==8 || x2==11 && y2==7 || x2==-15 && y2==-4 || x2==-14 && y2==-5 || x2==-15 && y2==-5 ||x2==11 && y2==-5 ||x2==11 && y2==-4 ||x2==10 && y2==-5
            ||x2==-4 && y2==0 ||x2==-4 && y2==1 ||x2==-4 && y2==2  ||x2==-4 && y2==3||x2==-3 && y2==0 ||x2==-3 && y2==1 ||x2==-3 && y2==2 ||x2==-3 && y2==3
            ||x2==-2 && y2==0 ||x2==-2 && y2==1 ||x2==-2 && y2==2  ||x2==-2 && y2==3||x2==-1 && y2==0 ||x2==-1 && y2==1 ||x2==-1 && y2==2 ||x2==-1 && y2==3||x2==0 && y2==0||x2==0 && y2==1 ||x2==0 && y2==2 ||x2==0 && y2==3) {
                i2--;    continue;
            }
            yıkılamayan.SetTile(yıkılamayan.WorldToCell(posit2), yıkılmaz);
        }
    }
}