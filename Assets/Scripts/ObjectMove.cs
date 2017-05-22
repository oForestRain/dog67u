using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour {

    public Vector3 speed = Vector3.one;

    private Vector3 velocity;

    void Awake() {
    }

    void OnEnable() {
        velocityDirection(Vector3.right);
    }

    void Disable() {
    }

     // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (velocity == Vector3.zero) {
            return;
        }

        transform.Translate(velocity * Time.deltaTime);
    }

    public void velocityDirection(Vector3 direction) {
        velocity = new Vector3(direction.x * speed.x, direction.y * speed.y, direction.z * speed.z);
    }
}
