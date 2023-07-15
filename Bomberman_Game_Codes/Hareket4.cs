using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hareket4 : MonoBehaviour
{

    public new Rigidbody2D rigidbody;
    private Vector2 direction = Vector2.down;
    public static float hiz = 5f;

    public KeyCode inputUp = KeyCode.Keypad8;
    public KeyCode inputDown = KeyCode.Keypad5;
    public KeyCode inputLeft = KeyCode.Keypad4;
    public KeyCode inputRight = KeyCode.Keypad6;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

private void Update()
    {
        if(Carpisma4.anlama==1){

            if (Input.GetKey(inputUp))
            {
                SetDirection(Vector2.up);
                SpriteRendUp4.anim.enabled=true;

                SpriteRendUp4.spriteRen.enabled=true;
                SpriteRendDown4.spriteRen.enabled=false;
                SpriteRendRight4.spriteRen.enabled=false;
                SpriteRendLeft4.spriteRen.enabled=false;
                
            }
            else if (Input.GetKey(inputDown))
            {
                SetDirection(Vector2.down);
                SpriteRendDown4.anim.enabled=true;
                SpriteRendDown4.spriteRen.enabled=true;
                SpriteRendUp4.spriteRen.enabled=false;
                SpriteRendRight4.spriteRen.enabled=false;
                SpriteRendLeft4.spriteRen.enabled=false;
            }
            else if (Input.GetKey(inputLeft)) 
            {
                SetDirection(Vector2.left);
                SpriteRendLeft4.anim.enabled=true;
                SpriteRendLeft4.spriteRen.enabled=true;
                SpriteRendUp4.spriteRen.enabled=false;
                SpriteRendDown4.spriteRen.enabled=false;
                SpriteRendRight4.spriteRen.enabled=false;
                
            }
            else if (Input.GetKey(inputRight))
            {
                SetDirection(Vector2.right);
                SpriteRendRight4.anim.enabled=true;
                SpriteRendRight4.spriteRen.enabled=true;
                SpriteRendUp4.spriteRen.enabled=false;
                SpriteRendDown4.spriteRen.enabled=false;
                SpriteRendLeft4.spriteRen.enabled=false;
            }
            else
            {
                SetDirection(Vector2.zero); 
            }
            if(Input.GetKeyUp(inputDown)){
                SpriteRendDown4.anim.enabled=false;
                SpriteRendDown4.anim.Rebind();           
                SpriteRendDown4.anim.Update(0f);      
            }   
            else if(Input.GetKeyUp(inputUp)){  
                SpriteRendUp4.anim.enabled=false;
                SpriteRendUp4.anim.Rebind();              
                SpriteRendUp4.anim.Update(0f);      
            }  
            else if(Input.GetKeyUp(inputLeft)){
                SpriteRendLeft4.anim.enabled=false;
                SpriteRendLeft4.anim.Rebind();              
                SpriteRendLeft4.anim.Update(0f);      
            }
            else if(Input.GetKeyUp(inputRight)){
            
                SpriteRendRight4.anim.enabled=false;
                SpriteRendRight4.anim.Rebind();              
                SpriteRendRight4.anim.Update(0f);      
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