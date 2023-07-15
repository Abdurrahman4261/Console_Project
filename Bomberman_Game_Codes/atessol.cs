using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atessol : MonoBehaviour
{
    public static SpriteRenderer sol;
    private void Start()
    {
        sol = GetComponent<SpriteRenderer>();   
    }
}
