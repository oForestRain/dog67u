using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour {
    [HideInInspector]
    public CharacterState status;

    public Transform landCheck;
    public LayerMask whatIsGround;

    private Rigidbody2D rb2D;

    private bool landed;

    void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void OnEnable() {
        status |= CharacterState.FacingRight;
        status &= ~CharacterState.Crouch;
    }

    void Disable() {

    }

    // Use this for initialization
    void Start() {

    }
    
    // Update is called once per frame
    void Update() {
        //Debug.Log("Character2DController-->Update");
        checkFacing();                
    }

    void FixedUpdate() {
        //Debug.Log("Character2DController-->FixedUpdate");  
        checkLand();
    }

    //void LateUpdate() {
    //}

    void checkLand() {
        bool check = Physics2D.Linecast(transform.position,landCheck.position, whatIsGround);
        if (landed == check) {
            return;
        }

        landed = check;
        if (landed) {
            string msg = System.Enum.GetName(typeof(MassageEnum), MassageEnum.msgSetJumpStatus);
            gameObject.SendMessage(msg, JumpStatus.Landed);
        }
        else {
        }
    }

    void checkFacing() {
        if ((status & CharacterState.FacingRight) == CharacterState.FacingRight) {
            if (rb2D.velocity.x < 0 ) {
                flip();
                status &= ~CharacterState.FacingRight;
            }
        }
        else {
            if (rb2D.velocity.x > 0) {
                flip();
                status |= CharacterState.FacingRight;
            }
        }
    }

    void flip() {
        string msg = System.Enum.GetName(typeof(MassageEnum), MassageEnum.msgFlipHorizontal);
        gameObject.SendMessage(msg);
    }
}






















