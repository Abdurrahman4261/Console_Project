using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class normal : MonoBehaviour
{
    public void normall(){
        Physics.gravity = new Vector3(0, 0, 0);
        SceneManager.LoadScene(1); 
    }
}
