using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hareket3 : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    private Vector2 direction = Vector2.down;
    public static float hiz = 5f;

    public KeyCode inputUp = KeyCode.I;
    public KeyCode inputDown = KeyCode.K;
    public KeyCode inputLeft = KeyCode.J;
    public KeyCode inputRight = KeyCode.L;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

private void Update()
    {
        if(Carpisma3.anlama==1){

            if (Input.GetKey(inputUp))
            {
                SetDirection(Vector2.up);
                SpriteRendUp2.anim.enabled=true;

                SpriteRendUp2.spriteRen.enabled=true;
                SpriteRendDown2.spriteRen.enabled=false;
                SpriteRendRight2.spriteRen.enabled=false;
                SpriteRendLeft2.spriteRen.enabled=false;
                
            }
            else if (Input.GetKey(inputDown))
            {
                SetDirection(Vector2.down);
                SpriteRendDown2.anim.enabled=true;
                SpriteRendDown2.spriteRen.enabled=true;
                SpriteRendUp2.spriteRen.enabled=false;
                SpriteRendRight2.spriteRen.enabled=false;
                SpriteRendLeft2.spriteRen.enabled=false;
            }
            else if (Input.GetKey(inputLeft)) 
            {
                SetDirection(Vector2.left);
                SpriteRendLeft2.anim.enabled=true;
                SpriteRendLeft2.spriteRen.enabled=true;
                SpriteRendUp2.spriteRen.enabled=false;
                SpriteRendDown2.spriteRen.enabled=false;
                SpriteRendRight2.spriteRen.enabled=false;
                
            }
            else if (Input.GetKey(inputRight))
            {
                SetDirection(Vector2.right);
                SpriteRendRight2.anim.enabled=true;
                SpriteRendRight2.spriteRen.enabled=true;
                SpriteRendUp2.spriteRen.enabled=false;
                SpriteRendDown2.spriteRen.enabled=false;
                SpriteRendLeft2.spriteRen.enabled=false;
            }
            else
            {
                SetDirection(Vector2.zero); 
            }
            if(Input.GetKeyUp(inputDown)){
                SpriteRendDown2.anim.enabled=false;
                SpriteRendDown2.anim.Rebind();           
                SpriteRendDown2.anim.Update(0f);      
            }   
            else if(Input.GetKeyUp(inputUp)){  
                SpriteRendUp2.anim.enabled=false;
                SpriteRendUp2.anim.Rebind();              
                SpriteRendUp2.anim.Update(0f);      
            }  
            else if(Input.GetKeyUp(inputLeft)){
                SpriteRendLeft2.anim.enabled=false;
                SpriteRendLeft2.anim.Rebind();              
                SpriteRendLeft2.anim.Update(0f);      
            }
            else if(Input.GetKeyUp(inputRight)){
            
                SpriteRendRight2.anim.enabled=false;
                SpriteRendRight2.anim.Rebind();              
                SpriteRendRight2.anim.Update(0f);      
            } 
        }
    }
    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * hiz  * Time.fixedDeltaTime;
        rigidbody.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }
}