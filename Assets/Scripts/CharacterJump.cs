using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour {
    public float normalJump = 6f;
    public float doubleJump = 6f;    
    public float runJump = 8f;
    public float crouchJump = 10f;
    public bool doubleJumpEnable = true;

    private Rigidbody2D rb2D;

    private InputEnum inputEnum;
    private JumpStatus status;

    void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void OnEnable() {
        inputEnum = InputEnum.None;
        status = JumpStatus.Landed;
    }

    void Disable() {

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void FixedUpdate() {
        //Debug.Log("CharacterJump-->FixedUpdate"+ moveInput);
        toJump();
    }

    public void msgSetJumpInput(InputEnum msgData) {
        //Debug.Log("CharacterJump-->msgSetJumpInput " + System.Enum.GetName(typeof(JumpStatus), status) + " " + doubleJumpEnable + " " + isDoubleJump);
        inputEnum = msgData;
    }

    public void msgSetJumpStatus(JumpStatus msgData) {
        //Debug.Log("CharacterJump-->msgSetJumpStatus " + System.Enum.GetName(typeof(JumpStatus), msgData));
        if (status != msgData) {
            status = msgData;
        }
    }

    void toJump() {
        if (inputEnum == InputEnum.None) {
            return;
        }

        if (inputEnum == InputEnum.Jump) {
            checkJumpEnableAndJump(normalJump, normalJump);
        }
        else if (inputEnum == InputEnum.RunJump) {
            checkJumpEnableAndJump(runJump, normalJump);
        }
        else if (inputEnum == InputEnum.CrouchJump) {
            checkJumpEnableAndJump(crouchJump, normalJump);
        }
        else {
            inputEnum = InputEnum.None;
            return;
        }
        inputEnum = InputEnum.None;
    }

    void checkJumpEnableAndJump(float oneJump,float doubleJump) {
        float velocity;
        if (status == JumpStatus.Landed) {
            velocity = oneJump;
            status = JumpStatus.Jump;
            //Debug.Log("CharacterJump-->checkJumpEnable oneJump" + velocity + System.Enum.GetName(typeof(JumpStatus), status));
        }
        else if (doubleJumpEnable && status != JumpStatus.DoubleJump) {
            velocity = doubleJump;
            status = JumpStatus.DoubleJump;
            //Debug.Log("CharacterJump-->checkJumpEnable oneJump" + velocity + System.Enum.GetName(typeof(JumpStatus), status));
        }
        else {
            return;
        }

        //Debug.Log("CharacterJump-->checkJumpEnable " + oneJump +" "+ doubleJump);

        rb2D.velocity = new Vector2(rb2D.velocity.x, velocity);
    }
}
