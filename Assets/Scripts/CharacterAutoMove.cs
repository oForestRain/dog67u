using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAutoMove : MonoBehaviour {

    public Vector3 speed = Vector3.one;
    public Vector3 moveDirection = Vector3.right;

    public CharacterMotion cMotion;
    private Vector3 velocity;

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
        if (velocity == Vector3.zero) {
            return;
        }

        autoMoveInput(velocity);
    }

    void autoMoveInput(Vector3 velocity) {
        //Debug.Log("CharacterMove-->inputMove" + velocity + inputData);
         if (velocity.x != 0 || velocity.z != 0) {
            if (velocity.x != 0 && velocity.z == 0) {
                cMotion.motion(velocity.x, MotionEnum.XAxis);
            }
            if (velocity.z != 0 && velocity.x == 0) {
                cMotion.motion(velocity.z, MotionEnum.ZAxis);
            }
            else {
            }
        }
        else {
            return;
        }        
    }

    public void directionReverse() {
        if (velocity == Vector3.zero) {
            return;
        }
        autoMove(velocity, new Vector3(-1, 1, 1));
    }

    public void defaultAutoMove() {
        autoMove(speed, moveDirection);
    }

    public void autoMove(Vector3 aSpeed, Vector3 aDirection) {
        velocity = new Vector3(aDirection.x * aSpeed.x, aDirection.y * aSpeed.y, aDirection.z * aSpeed.z);
    }

    public void stopAutoMove() {
        velocity = Vector3.zero;
    }    
}
