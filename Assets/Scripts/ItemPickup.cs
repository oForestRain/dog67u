using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    public ItemPickupEnum pickupType;
    public float pickupValue = 1f;

    CharacterMedia cMeidia;
    private ParticleTransformManager cParticle;

    private GameObject playerGameObject;

    void Awake() {
        cMeidia = GetComponent<CharacterMedia>();
        cParticle = GetComponent<ParticleTransformManager>();

        playerGameObject = GameObject.FindGameObjectWithTag("Player");
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
        //Debug.Log("ItemPickup-->OnTriggerEnter");
        CharacterMode playerMode;
        if (other.tag == "Player") {
            //Debug.Log("ItemPickup-->OnTriggerEnter" + "Player");
            playerMode = playerGameObject.GetComponent<CharacterMode>();
            playerMode.PickupItem(pickupType,pickupValue);

            //cMeidia.playAudio(AudioEnum.Jump);
            //cParticle.playParticle(ParticleEnum.Jump);
        }
    }
}
