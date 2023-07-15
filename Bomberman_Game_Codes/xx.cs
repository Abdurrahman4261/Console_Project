using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class xx : MonoBehaviourPunCallbacks
{
    
    public float spee=1f;
    private Vector2 direction = Vector2.down;
    public static float hizz = 5f;
    public new Rigidbody2D rigidbody;
    private Animator an;
    // Start is called before the first frame update
    private void Awake()
    {
        an=GetComponent<Animator>();
    }
  
    private void Update(){
        if(!photonView.IsMine) return;
        if(Input.GetKey(KeyCode.W)){
            an.SetBool("movingg",true);   //an.enabled=true;
            SetDirection(Vector2.up);
        }
        else if(Input.GetKey(KeyCode.S)){
            an.SetBool("movingg",true);
            SetDirection(Vector2.down); 
        }
        else
        {
            SetDirection(Vector2.zero); 
        }
        if(Input.GetKeyUp(KeyCode.W)){
            an.SetBool("movingg",false);
            
        }
        else if(Input.GetKeyUp(KeyCode.S)){
            an.SetBool("movingg",false);
        }
    }
    private void FixedUpdate()
    {
        if(!photonView.IsMine) return;
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * hizz  * Time.fixedDeltaTime;
        rigidbody.MovePosition(position + translation);
    }
    private IEnumerator onesec(){
        yield return new WaitForSeconds(1f);
        an.enabled=false;
    }
    private void SetDirection(Vector2 newDirection)
    {
        direction = newDirection; 
    }
}
