using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollider : MonoBehaviour {

    public ColliderEnum part;
    public CharacterCollision handler;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        handler.partColliderEnter(other,part);
    }
}
