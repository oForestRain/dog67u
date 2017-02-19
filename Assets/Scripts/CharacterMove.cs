using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {
    public float walkSpeed = 1f;
    public float runSpeed = 2f;

    private Rigidbody2D rb2D;

    private InputEnum inputEnum;
    private MoveStatus status;

    void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void OnEnable() {
        inputEnum = InputEnum.None;
        status = MoveStatus.Stay;
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
        //Debug.Log("CharacterMove-->FixedUpdate"+ moveInput);
        toMove();
    }

    void msgSetMoveInput(InputEnum msgData) {
        inputEnum = msgData;
    }

    void toMove() {
        if (inputEnum == InputEnum.None) {
            status = MoveStatus.Stay;
            return;
        }

        float velocity;

        if (inputEnum == InputEnum.WalkRight) {
            velocity = walkSpeed;
            status = MoveStatus.Walk;
        }
        else if (inputEnum == InputEnum.RunRight) {
            velocity = runSpeed;
            status = MoveStatus.Run;
        }
        else if (inputEnum == InputEnum.WalkLeft) {
            velocity = -walkSpeed;
            status = MoveStatus.Walk;
        }
        else if (inputEnum == InputEnum.RunLeft) {
            velocity = -runSpeed;
            status = MoveStatus.Run;
        }
        else {
            inputEnum = InputEnum.None;
            return;
        }

        rb2D.velocity = new Vector2(velocity, rb2D.velocity.y);
        inputEnum = InputEnum.None;
    }

}
