using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class online_left_1 : MonoBehaviour
{   
    public static SpriteRenderer spriteRen;
    public Animator anim;
    
    private void Start()
    {  
        spriteRen = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();     
    }
    // void etkin(){
    //     if(!pv.IsMine) return;
    //     spriteRen.enabled=true;
    // }
}