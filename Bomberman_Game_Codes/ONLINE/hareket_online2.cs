using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class hareket_online2 : MonoBehaviourPunCallbacks
{
   
    PhotonView pw; int saglik=100;
    public new Rigidbody2D rigidbody;
    private Vector2 direction = Vector2.down;
    public static float hiz = 5f;
    Animator an;
    private KeyCode inputUp = KeyCode.W;
    private KeyCode inputDown = KeyCode.S;
    private KeyCode inputLeft = KeyCode.A;
    private KeyCode inputRight = KeyCode.D;
   
    [SerializeField] private SpriteRenderer  sp;
    [SerializeField] private SpriteRenderer  spleft;
    [SerializeField] private SpriteRenderer  spup;
    [SerializeField] private SpriteRenderer  spright;

    
    
    private void Start()
    {
        pw=GetComponent<PhotonView>();
        sp=GetComponent<SpriteRenderer> ();
        rigidbody = GetComponent<Rigidbody2D>();
        an= GetComponent<Animator>();
        
        if(!pw.IsMine) return;
        an.enabled=true;
        
    }
    private void Update()
    {
        if(carpisma_photon.anlama==1){
            an.enabled=true;
            if(!photonView.IsMine) return;  
            if (Input.GetKey(inputUp))
            {
                SetDirection(Vector2.up);
                string anim ="yukari" ;    string anim2 ="down" ;    string anim3 ="sol" ;    string anim4 ="sag" ;
                photonView.RPC("changeSprite_ilk", RpcTarget.AllBuffered, anim,anim2,anim3,anim4); 
            }
            else if (Input.GetKey(inputDown))
            {
                SetDirection(Vector2.down);
                string anim ="down" ;    string anim2 ="yukari" ;    string anim3 ="sol" ;    string anim4 ="sag" ;
                photonView.RPC("changeSprite_ilk", RpcTarget.AllBuffered, anim,anim2,anim3,anim4);
            }
            else if (Input.GetKey(inputLeft)) 
            {
                SetDirection(Vector2.left);
                string anim ="sol" ;    string anim2 ="yukari" ;    string anim3 ="down" ;    string anim4 ="sag" ;
                photonView.RPC("changeSprite_ilk", RpcTarget.AllBuffered, anim,anim2,anim3,anim4);
            }
            else if (Input.GetKey(inputRight))
            {
                SetDirection(Vector2.right);
                string anim ="sag" ;    string anim2 ="yukari" ;    string anim3 ="down" ;    string anim4 ="sol" ;
                photonView.RPC("changeSprite_ilk", RpcTarget.AllBuffered, anim,anim2,anim3,anim4);
            }
            
            else
            {
                SetDirection(Vector2.zero); 
            }
            if(Input.GetKeyUp(inputDown)){
                
                photonView.RPC("changeSprite", RpcTarget.AllBuffered,"down",2);
            }   
            else if(Input.GetKeyUp(inputUp)){  
                photonView.RPC("changeSprite", RpcTarget.AllBuffered,"yukari",1);
            }  
            else if(Input.GetKeyUp(inputLeft)){
                photonView.RPC("changeSprite", RpcTarget.AllBuffered,"sol",4);
            }
            else if(Input.GetKeyUp(inputRight)){
                photonView.RPC("changeSprite", RpcTarget.AllBuffered,"sag",3);
            } 
        } 
    } 
    [PunRPC]
    void changeSprite_ilk(string anim , string anim2 , string anim3 , string anim4)
    {
        sp.enabled=true;
        spleft.enabled=false;
        spright.enabled=false;
        spup.enabled=false;

        an.SetBool(anim4,false);
        an.SetBool(anim3,false);
        an.SetBool(anim2,false);
        an.SetBool(anim,true);
    }
    
    [PunRPC]
    void changeSprite(string anim,int a)
    {
        if(a==1){
            spright.enabled=false;
            spleft.enabled=false;
            sp.enabled=false;
            spup.enabled=true;
        }
        else if(a==2){
            spright.enabled=false;
            spup.enabled=false;
            spleft.enabled=false;
            sp.enabled=true;
        }
        if(a==3){
            sp.enabled=false;
            spup.enabled=false;
            spleft.enabled=false;
            spright.enabled=true;
        }
        if(a==4){
            spright.enabled=false;
            sp.enabled=false;
            spup.enabled=false;
            spleft.enabled=true;
        }
        an.Rebind();
        an.Update(0f); 
        an.SetBool(anim,false);
    }
    private void FixedUpdate()
    {
        if(!photonView.IsMine) return;

        Vector2 position = rigidbody.position;
        Vector2 translation = direction * hiz  * Time.fixedDeltaTime;
        rigidbody.MovePosition(position + translation);
    }
    [PunRPC]
    void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }
}