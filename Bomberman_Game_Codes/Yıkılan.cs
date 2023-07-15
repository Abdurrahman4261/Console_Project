using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yıkılan : MonoBehaviour
{
    private float yikzaman=0.4f;
    void Start()
    {
        Destroy(gameObject,yikzaman);
    }
}
