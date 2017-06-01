using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public Vector3 speed = Vector3.one;
    public CMovement cMovement;

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
 
    }

    void moveInput(float inputData, MotionEnum inputEnum) {
        //Debug.Log("EnemyAI-->inputMove" + velocity + inputData);
        cMovement.movement(inputData,inputEnum);
    }  

    public void startAI() {
        moveInput(speed.x,MotionEnum.XAxis);
    }
}

