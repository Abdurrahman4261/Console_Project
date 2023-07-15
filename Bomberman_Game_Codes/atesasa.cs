using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atesasa : MonoBehaviour
{
    public static SpriteRenderer asa;
    private void Start()
    {
        asa = GetComponent<SpriteRenderer>();   
    }

    
   
    private void OnTriggerEnter2D (Collider2D duvar) {

        Debug.Log("a"+duvar.gameObject.tag);
        Destroy(duvar.gameObject);
        if(duvar.gameObject.tag=="bir"){
            Debug.Log("bir"+duvar.gameObject.tag);
        }
        
    }
}
