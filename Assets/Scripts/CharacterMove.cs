using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {
    public Vector3 speed = new Vector3(4f,0f,0f);

    private Vector3 velocity;

    //private DelegateManager dManager;

    public CharacterMotion cMotion;

    void Awake() {
        //Debug.Log("CharacterMove-->Awake ");
        //dManager = GetComponent<DelegateManager>();

        //cMotion = GetComponent<CharacterMotion>();
    }

    void OnEnable() {
        //dManager.addDelegate(DelegateEnum.Input, calculateMove);
        velocity = Vector3.zero;
    }

    void Disable() {
        //dManager.decreaseDelegate(DelegateEnum.Input, calculateMove);
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        //Debug.Log("CharacterMove-->FixedUpdate"+ moveInput);
    }

    public void inputMove(InputEnum inputEnum, object inputData) {
        //Debug.Log("CharacterMove-->inputMove" + velocity + inputData);
        if (inputEnum == InputEnum.HorizontalMove) {
            if (velocity.x == 0 && (float)inputData == 0) {
                return;
            }
            velocity.x = speed.x * (float)inputData;
            cMotion.motion(velocity.x, MotionEnum.XAxis);
        }
        if (inputEnum == InputEnum.HorizontalMove) {
            if (velocity.z == 0 && (float)inputData == 0) {
                return;
            }
            velocity.z = speed.z * (float)inputData;
            cMotion.motion(velocity.z, MotionEnum.ZAxis);
        }        
    }

    void checkInput(ref float rVelocity,float inputData, MotionEnum mEnum) {
        if (rVelocity == 0 && inputData == 0) {
            return;
        }
        cMotion.motion(rVelocity, MotionEnum.ZAxis);
    }

    //void calculateMove(object[] rMsgData) {
    //    InputEnum inputEnum;
    //    float inputData;

    //    if (rMsgData.Length >= 2) {
    //        inputEnum = (InputEnum)rMsgData[0];
    //        inputData = (float)rMsgData[1];
    //    }
    //    else {
    //        return;
    //    }
    //    if (inputEnum != InputEnum.HorizontalMove) {
    //        return;
    //    }

    //    //Debug.Log("CharacterMove-->calculateMove" + inputEnum + inputData);        
    //    if (velocity == 0f && inputData == 0f) {
    //        return;
    //    }
    //    velocity = moveVelocity(inputEnum, inputData);

    //    object[] sMsgData = new object[2];
    //    sMsgData[0] = MotionEnum.XAxis;
    //    sMsgData[1] = velocity;
    //    dManager.delegateInvoke(DelegateEnum.Motion, sMsgData);
    //}


    //float moveVelocity(InputEnum inputEnum, float inputData) {        
    //    float velocity = 0f;
    //    if (inputEnum == InputEnum.HorizontalMove) {
    //        velocity = speed * inputData;
    //    }
    //    return velocity;
    //}
}
