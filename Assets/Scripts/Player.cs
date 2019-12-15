using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Vector3 movement;                   
    Animator anim;                      
    Rigidbody playerRigidbody;          
    int floorMask;                      
    float camRayLength = 100f;
    public bool dead = false;
    public UnityEngine.UI.Slider healthSlider;
    public UnityEngine.UI.Text tLevel;
    

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turning();
        Animating(h, v);
        Die();


       
        healthSlider.value = (Stats.Instance.playerHealth / Stats.Instance.playerMaxHealth) * 100f;
        tLevel.text = Stats.Instance.playerLevel.ToString();
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * Stats.Instance.playerSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }

    void Die()
    {
        if (Stats.Instance.playerHealth <= 0 && dead == false)
        {
            transform.position = new Vector3(-38.8f, 1f, -3.8f);
            Stats.Instance.playerLevel = 1;
            Stats.Instance.playerXP = 0;
            dead = true;
        }
    }
}