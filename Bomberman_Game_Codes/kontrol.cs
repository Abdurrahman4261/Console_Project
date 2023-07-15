using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kontrol : MonoBehaviour
{
    public anamenu option;
    //public rastgele_gidis option2;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            // option.gameObject.SetActive(true);
            if(option.gameObject.activeSelf){
                option.gameObject.SetActive(false);
                Time.timeScale=1;
            }
            else{
                option.gameObject.SetActive(true);
                Debug.Log("dur");
                Time.timeScale=0;
            }
        }
    }
    public void bas(){
        SceneManager.LoadScene("level2");
        Time.timeScale=1f;
    }
    public void bas2(){
        SceneManager.LoadScene("level3");
        Time.timeScale=1f;
    }
    public void yeniden(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("devam");
        Time.timeScale=1;
    }
}
        // else if(Input.GetKeyDown(KeyCode.CapsLock)){
        //     // option.gameObject.SetActive(true);
        //     if(option2.gameObject.activeSelf){
        //         option2.gameObject.SetActive(false);
        //         Time.timeScale=1;
        //     }
        //     else{
        //         option2.gameObject.SetActive(true);
        //         Time.timeScale=0;
        //     }
        // }
