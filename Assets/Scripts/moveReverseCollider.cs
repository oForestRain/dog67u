using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveReverseCollider : MonoBehaviour {

    //public GameObject objectMoveDelegate;

    public Vector3 moveDirection = Vector3.right;
    //public bool reverse = false;

    public ObjectMove objectMove;

    void Awake() {
        //objectMove = objectMoveDelegate.GetComponent<ObjectMove>();
    }

    void OnEnable() {
    }

    void Disable() {
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        //Debug.Log("moveReverseCollider-->OnTriggerEnter" + other.tag);
        if (other.tag == TagEnum.Block.ToString() || other.tag == TagEnum.Pickup.ToString()) {
            //reverse = !reverse;
            moveDirection *= -1;
            objectMove.velocityDirection(moveDirection);
            //Debug.Log("moveReverseCollider-->OnTriggerEnter" + moveDirection);
        }
    }

}
