using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hareket2 : MonoBehaviour
{

    public new Rigidbody2D rigidbody;
    private Vector2 direction = Vector2.down;
    public static float hiz = 5f;

    public KeyCode inputUp = KeyCode.UpArrow;
    public KeyCode inputDown = KeyCode.DownArrow;
    public KeyCode inputLeft = KeyCode.LeftArrow;
    public KeyCode inputRight = KeyCode.RightArrow;

   

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Carpisma2.anlama==1){

            if (Input.GetKey(inputUp))
            {
                SetDirection(Vector2.up);
                SpriteRendUp1.anim.enabled=true;

                SpriteRendUp1.spriteRen.enabled=true;
                SpriteRendDown1.spriteRen.enabled=false;
                SpriteRendRight1.spriteRen.enabled=false;
                SpriteRendLeft1.spriteRen.enabled=false;
                
            }
            else if (Input.GetKey(inputDown))
            {
                SetDirection(Vector2.down);
                SpriteRendDown1.anim.enabled=true;
                SpriteRendDown1.spriteRen.enabled=true;
                SpriteRendUp1.spriteRen.enabled=false;
                SpriteRendRight1.spriteRen.enabled=false;
                SpriteRendLeft1.spriteRen.enabled=false;
            }
            else if (Input.GetKey(inputLeft)) 
            {
                SetDirection(Vector2.left);
                SpriteRendLeft1.anim.enabled=true;
                SpriteRendLeft1.spriteRen.enabled=true;
                SpriteRendUp1.spriteRen.enabled=false;
                SpriteRendDown1.spriteRen.enabled=false;
                SpriteRendRight1.spriteRen.enabled=false;
                
            }
            else if (Input.GetKey(inputRight))
            {
                SetDirection(Vector2.right);
                SpriteRendRight1.anim.enabled=true;
                SpriteRendRight1.spriteRen.enabled=true;
                SpriteRendUp1.spriteRen.enabled=false;
                SpriteRendDown1.spriteRen.enabled=false;
                SpriteRendLeft1.spriteRen.enabled=false;
            }
            else
            {
                SetDirection(Vector2.zero); 
            }
            if(Input.GetKeyUp(inputDown)){
                SpriteRendDown1.anim.enabled=false;
                SpriteRendDown1.anim.Rebind();           
                SpriteRendDown1.anim.Update(0f);      
            }   
            else if(Input.GetKeyUp(inputUp)){  
                SpriteRendUp1.anim.enabled=false;
                SpriteRendUp1.anim.Rebind();              
                SpriteRendUp1.anim.Update(0f);      
            }  
            else if(Input.GetKeyUp(inputLeft)){
                SpriteRendLeft1.anim.enabled=false;
                SpriteRendLeft1.anim.Rebind();              
                SpriteRendLeft1.anim.Update(0f);      
            }
            else if(Input.GetKeyUp(inputRight)){
            
                SpriteRendRight1.anim.enabled=false;
                SpriteRendRight1.anim.Rebind();              
                SpriteRendRight1.anim.Update(0f);      
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