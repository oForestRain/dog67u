using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMode : MonoBehaviour {

    //private CharacterController controller;

    private CharacterState status;

    public Transform jumpParticle;
    public Transform rightGroundCheck;
    [HideInInspector]
    public float sphereRadius = 0.2f;
    public LayerMask whatIsGround;

    private bool grounded;

    void Awake() {
        //controller = GetComponent<CharacterController>();
    }

    void OnEnable() {
        status &= ~CharacterState.Crouch;
    }

    void Disable() {

    }

    // Use this for initialization
    void Start() {
        
    }
    
    // Update is called once per frame
    //void Update() {
    //    //Debug.Log("Character2DController-->Update");
    //}

    void FixedUpdate() {
        //Debug.Log("Character2DController-->FixedUpdate");
    }

    void LateUpdate() {
    }
    
    void Update() {
    }
}






















