using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    [HideInInspector]
    public InputEnum inputEnum;    

    void Awake() {

    }

    void OnEnable() {
    }

    void Disable() {
    }

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        horizontalInput();
        jumpInput();
        actionInput();
    }

    void horizontalInput() {
        float hInput = Input.GetAxis("Horizontal");
        if (hInput == 0) {
            return;
        }
        else if (hInput > 0) {
            inputEnum = Input.GetButton("Fire1") ? InputEnum.RunRight : InputEnum.WalkRight;
        }
        else if (hInput < 0) {
            inputEnum = Input.GetButton("Fire1") ? InputEnum.RunLeft : InputEnum.WalkLeft;
        }

        string msg = System.Enum.GetName(typeof(MassageEnum), MassageEnum.msgSetMoveInput);
        //Debug.Log("PlayerInput-->horizontalInput " + msg);
        gameObject.SendMessage(msg, inputEnum);
    }

    void jumpInput() {
        if (Input.GetButtonDown("Jump") && !Input.GetButton("Fire1")) {
            inputEnum = InputEnum.Jump;
        }
        else if (Input.GetButtonDown("Jump") && Input.GetButton("Fire1")) {
            inputEnum = InputEnum.RunJump;
        }
        else if (Input.GetButtonDown("Jump") && Input.GetAxis("Vertical") < 0 ) {
            inputEnum = InputEnum.CrouchJump;
        }
        else {
            return;
        }
        
        string msg = System.Enum.GetName(typeof(MassageEnum), MassageEnum.msgSetJumpInput);
        //Debug.Log("PlayerInput-->jumpInput " + msg);
        gameObject.SendMessage(msg, inputEnum);
    }

    void actionInput() {
        float vInput = Input.GetAxis("Vertical");
        if (vInput == 0) {
            return;
        }
        if (vInput > 0) {            
        }
        else if (vInput < 0) {
            inputEnum = InputEnum.Crouch;
        }

        string msg = System.Enum.GetName(typeof(MassageEnum), MassageEnum.msgSetActioinInput);
        //Debug.Log("PlayerInput-->actionInput " + msg);
        gameObject.SendMessage(msg, inputEnum);
    }


    void FixedUpdate() {
        //Debug.Log("PlayerInput-->FixedUpdate");
    }
}