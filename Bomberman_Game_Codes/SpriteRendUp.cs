using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteRendUp : MonoBehaviour
{
    public static SpriteRenderer spriteRen;
    public static Animator anim;
    public static GameObject yer;
    private void Start()
    {
        spriteRen = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
}