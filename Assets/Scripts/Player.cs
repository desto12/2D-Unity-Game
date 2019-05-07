using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageInterface
{
    Rigidbody2D rgbody;  
    public int diamonds = 0;
    public int PlayerSpeed = 10;
    public float moveX;
    public float jumpForce = 10.0f;
    public bool isGround;
    private PlayerAnimation anim;
    public bool isLookingRight = true;
    private SpriteRenderer playerSprite;
    private SpriteRenderer swordSprite;
    public int Health { get; set; }
    public int Dmg;

    // Use this for initialization
    void Start()
    {
        rgbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<PlayerAnimation>();
        swordSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        Health = 4;
        Dmg = 1;
        diamonds = StaticSave.diamnonds;
        Health = StaticSave.Health;
        Dmg = StaticSave.Dmg;
    }   

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        ChangeSide();
        //
    }

    void Movement()
    {

        //run
        moveX = CrossPlatformInputManager.GetAxis ("Horizontal");//Input.GetAxisRaw("horizontal") //for pc

        //regular ground attack
        if (CrossPlatformInputManager.GetButtonDown("A_button") && isGround == true)//Input.GetKeyDown(KeyCode.X) )
        {
            anim.Attack();
        }

        //jump
        if (CrossPlatformInputManager.GetButtonDown("B_button") && isGround == true) //Input.GetButtonDown("Jump")
        {
            rgbody.velocity = new Vector2(rgbody.velocity.x, jumpForce);
            isGround = false;
            anim.Jump(true);
        }



        rgbody.velocity = new Vector2(moveX * PlayerSpeed, rgbody.velocity.y);
        anim.Move(moveX);

    }
    void ChangeSide()
    {
        if (moveX < 0.0f && isLookingRight == false)
        {
            isLookingRight = !isLookingRight;
            playerSprite.flipX = true;
            swordSprite.flipY = true;
            Vector3 swordposition = swordSprite.transform.localPosition;
            swordposition.x = -1.09f;
            swordSprite.transform.localPosition = swordposition;
        }
        else if (moveX > 0.0f && isLookingRight == true)
        {
            isLookingRight = !isLookingRight;
            playerSprite.flipX = false;
            swordSprite.flipY = false;
            Vector3 swordposition = swordSprite.transform.localPosition;// checking actual sword animation postion
            swordposition.x = 1.09f;// x starting position
            swordSprite.transform.localPosition = swordposition; //moving with x postion
        }
    }


    void OnCollisionEnter2D(Collision2D collision)//checking that we are on grond
    {
        if (collision.gameObject.name == "Ground_Tilemap")
        {
            isGround = true;
            anim.Jump(false);
        }
    }
    public void Damage()
    {
        Debug.Log("Enemy uderzył gracza!");
        Health -= 1;
        UIManager.Instance.UpdateLives(Health);

        if (Health < 1)
        {
            anim.Death();
            Debug.Log("Gracz ginie");

        } 
    }

    public void AddGems(int gems)
    {
        diamonds += gems;
        StaticSave.diamnonds = diamonds;
        UIManager.Instance.UpdateDiamnodsCount(diamonds);
        
    }

}