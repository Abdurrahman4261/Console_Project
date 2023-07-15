using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_secim : MonoBehaviour
{
    // Start is called before the first frame update
     public void bas(){
        SceneManager.LoadScene("level1");
        Time.timeScale=1f;
    }
    public void bas2(){
        SceneManager.LoadScene("level2");
        Time.timeScale=1f;
    }
    public void bas3(){
        SceneManager.LoadScene("level3");
        Time.timeScale=1f;
    }
}
