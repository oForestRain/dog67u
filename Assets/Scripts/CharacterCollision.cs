using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour {

    public CharacterController controller;
    //private DelegateManager dManager;
    public CharacterMotion cMotion;
    public CharacterJump cJump;

    //private CollisionFlags curFlags;

    void Awake() {
        //controller = GetComponent<CharacterController>();
        //dManager = GetComponent<DelegateManager>();
        //cMotion = GetComponent<CharacterMotion>();
    }

    void OnEnable() {
        //curFlags = CollisionFlags.None;
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

    public void partColliderEnter(Collider other,ColliderEnum part) {
        if (part == ColliderEnum.Head) {
            headColliderEnter(other);
        }
    }

    void headColliderEnter(Collider other) {
        if (other.tag == TagEnum.Block.ToString()) {           
            cJump.headBumped();
            cMotion.motion(0, MotionEnum.ReverseYAxis);
            //Debug.Log("CharacterCollision-->headColliderEnter");
        }
    }

}
