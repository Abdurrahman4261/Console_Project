using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class online_right_1 : MonoBehaviour
{
    public static SpriteRenderer spriteRen;
    public Animator anim;
    
    private void Start()
    { 
        spriteRen = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();     
    }
}