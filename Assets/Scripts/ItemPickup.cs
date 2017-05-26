﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    public ItemPickupEnum pickupType;
    public float pickupValue = 1f;

    public ObjectMedia oMeidia;
    public ParticleTransformManager cParticle;

    private GameObject playerGameObject;

    void Awake() {
        //cMeidia = GetComponent<ObjectMedia>();
        //cParticle = GetComponent<ParticleTransformManager>();

        //playerGameObject = GameObject.FindGameObjectWithTag(TagEnum.Player.ToString());
    }

    void OnEnable() {

    }

    void Disable() {
        //dManager.decreaseDelegate(DelegateEnum.Motion, updateVelocity);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision) {
        CharacterMode playerMode;
        if (!ReferenceEquals(collision.collider.transform.parent, null) && collision.collider.transform.parent.tag == TagEnum.Player.ToString()) {
            //Debug.Log("ItemPickup-->OnTriggerEnter" + other.transform.parent.tag);
            playerMode = collision.collider.GetComponentInParent<CharacterMode>();
            playerMode.PickupItem(pickupType, pickupValue);

            //Destroy(gameObject);
        }
    }
}
