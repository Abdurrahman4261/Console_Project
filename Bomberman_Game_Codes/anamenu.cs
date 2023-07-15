using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anamenu : MonoBehaviour
{
    [SerializeField] private  GameObject p1;
    // private void Start(){
    //     GameObject x=p1;
    // }
    public void anamenuu(){
        // load
        // GameObject x=p1;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale=1f;
        //Physics.gravity = new Vector3(0, 0, 0);
        
        SceneManager.LoadScene("AnaMenu");  
        // if(p1!=null){
        //     Destroy(x);  
        // }
    } 
}
