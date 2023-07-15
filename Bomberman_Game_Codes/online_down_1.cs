using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class online_down_1 : MonoBehaviour
{
    public static SpriteRenderer spriteRen;
    public Animator anim;
    
    private void Start()
    {  
        spriteRen = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();     
    }
}