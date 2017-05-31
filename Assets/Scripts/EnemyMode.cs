using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMode : MonoBehaviour {

    public CharacterAutoMove eAutoMove;
    public ObjectMedia oMeidia;
    public ParticleTransformManager cParticle;

    // Use this for initialization
    void Start () {
        eAutoMove.defaultAutoMove();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision) {
        ContactPoint contact = collision.contacts[0];
        //Debug.Log("ObjectAutoMove-->OnCollisionEnter" + contact.normal);
        //Debug.DrawRay(contact.point, contact.normal, Color.red, 500);
        Vector3 pos = contact.point;
        if (collision.collider.tag == TagEnum.Block.ToString() || collision.collider.tag == transform.tag) {
            if (contact.normal.x != 0) {
                //Debug.Log("ObjectAutoMove-->OnCollisionEnter Reverse");
                eAutoMove.directionReverse();
            }
        }
    }
}
