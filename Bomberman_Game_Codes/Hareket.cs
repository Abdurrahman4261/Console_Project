using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hareket : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    private Vector2 direction = Vector2.down;
    public static float hiz = 5f;

    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Carpisma.anlama==1){
            
            if (Input.GetKey(inputUp))
            {
                SetDirection(Vector2.up);
                SpriteRendUp.anim.enabled=true;

                SpriteRendUp.spriteRen.enabled=true;
                SpriteRendDown.spriteRen.enabled=false;
                SpriteRendRight.spriteRen.enabled=false;
                SpriteRendLeft.spriteRen.enabled=false;
                
            }
            else if (Input.GetKey(inputDown))
            {
                SetDirection(Vector2.down);
                SpriteRendDown.anim.enabled=true;
                SpriteRendDown.spriteRen.enabled=true;
                SpriteRendUp.spriteRen.enabled=false;
                SpriteRendRight.spriteRen.enabled=false;
                SpriteRendLeft.spriteRen.enabled=false;
            }
            else if (Input.GetKey(inputLeft)) 
            {
                SetDirection(Vector2.left);
                SpriteRendLeft.anim.enabled=true;
                SpriteRendLeft.spriteRen.enabled=true;
                SpriteRendUp.spriteRen.enabled=false;
                SpriteRendDown.spriteRen.enabled=false;
                SpriteRendRight.spriteRen.enabled=false;
                
            }
            else if (Input.GetKey(inputRight))
            {
                SetDirection(Vector2.right);
                SpriteRendRight.anim.enabled=true;
                SpriteRendRight.spriteRen.enabled=true;
                SpriteRendUp.spriteRen.enabled=false;
                SpriteRendDown.spriteRen.enabled=false;
                SpriteRendLeft.spriteRen.enabled=false;
                
            }
            else
            {
                SetDirection(Vector2.zero); 
            }
            if(Input.GetKeyUp(inputDown)){
                SpriteRendDown.anim.enabled=false;
                SpriteRendDown.anim.Rebind();           
                SpriteRendDown.anim.Update(0f);      
            }   
            else if(Input.GetKeyUp(inputUp)){  
                SpriteRendUp.anim.enabled=false;
                SpriteRendUp.anim.Rebind();              
                SpriteRendUp.anim.Update(0f);      
            }  
            else if(Input.GetKeyUp(inputLeft)){
                SpriteRendLeft.anim.enabled=false;
                SpriteRendLeft.anim.Rebind();              
                SpriteRendLeft.anim.Update(0f);      
            }
            else if(Input.GetKeyUp(inputRight)){
            
                SpriteRendRight.anim.enabled=false;
                SpriteRendRight.anim.Rebind();              
                SpriteRendRight.anim.Update(0f);      
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