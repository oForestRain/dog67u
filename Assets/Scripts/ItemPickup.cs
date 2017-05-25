using System.Collections;
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

    void OnTriggerEnter(Collider other) {
        CharacterMode playerMode;
        if (!ReferenceEquals(other.transform.parent,null) && other.transform.parent.tag == TagEnum.Player.ToString()) {
            //Debug.Log("ItemPickup-->OnTriggerEnter" + other.transform.parent.tag);
            playerMode = other.GetComponentInParent<CharacterMode>();
            playerMode.PickupItem(pickupType, pickupValue);

            Destroy(gameObject);
        }       
    }
}
