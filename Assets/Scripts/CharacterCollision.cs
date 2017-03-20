using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour {

    private CharacterController controller;
    //private DelegateManager dManager;
    private CharacterMotion cMotion;

    private CollisionFlags curFlags;

    void Awake() {
        controller = GetComponent<CharacterController>();
        //dManager = GetComponent<DelegateManager>();
        cMotion = GetComponent<CharacterMotion>();
    }

    void OnEnable() {
        curFlags = CollisionFlags.None;
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
        //Debug.Log("CharacterCollision-->FixedUpdate" + controller.collisionFlags + curFlags);
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
        //Debug.Log("CharacterCollision-->OnControllerColliderHit" + hit.moveDirection);
        //if (hit.moveDirection == Vector3.up) {

        //else {
        //    return;
        //}

        FlagsCollision();
    }

    void FlagsCollision() {
        if (controller.collisionFlags == curFlags) {
            return;
        }
        object[] sMsgData = new object[2];
        curFlags = controller.collisionFlags;
        if (controller.collisionFlags == CollisionFlags.Above) {
            //sMsgData[0] = MotionEnum.ReverseYAxis;
            //sMsgData[1] = 0f;
            cMotion.motion(0,MotionEnum.ReverseYAxis);
        }
        else {
            return;
        }
        //dManager.delegateInvoke(DelegateEnum.Motion, sMsgData);
    }
}
