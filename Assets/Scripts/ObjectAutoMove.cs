using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAutoMove : MonoBehaviour {

    public Vector3 speed = Vector3.one;
    public Vector3 moveDirection = Vector3.right;

    private Vector3 velocity;

    void Awake() {
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
        if (velocity == Vector3.zero) {
            return;
        }

        transform.Translate(velocity * Time.deltaTime);
    }

    public void directionReverse() {
        if (velocity == Vector3.zero) {
            return;
        }
        autoMove(velocity, new Vector3(-1,1,1));
    }

    public void defaultAutoMove() {
        autoMove(speed,moveDirection);
    }

    public void autoMove(Vector3 aSpeed, Vector3 aDirection) {
        velocity = new Vector3(aDirection.x * aSpeed.x, aDirection.y * aSpeed.y, aDirection.z * aSpeed.z);
    }

    public void stopAutoMove() {
        velocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision) {
        ContactPoint contact = collision.contacts[0];
        //Debug.Log("ObjectAutoMove-->OnCollisionEnter" + contact.normal);
        //Debug.DrawRay(contact.point, contact.normal, Color.red, 500);
        Vector3 pos = contact.point;
        if (collision.collider.tag == TagEnum.Block.ToString() || collision.collider.tag == transform.tag) {
            if (contact.normal.x != 0) {
                //Debug.Log("ObjectAutoMove-->OnCollisionEnter Reverse");
                directionReverse();
            }
            if (contact.normal.y > 0) {                
                if (velocity == Vector3.zero) {
                    //Debug.Log("ObjectAutoMove-->OnCollisionEnter Default");
                    defaultAutoMove();
                }                
            }
        }
    }
}
