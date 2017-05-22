using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMode : MonoBehaviour {

    //private CharacterController controller;
    public ObjectMedia cMeidia;
    public ParticleTransformManager cParticle;

    private CharacterState status;

    void Awake() {
        //controller = GetComponent<CharacterController>();
        //cMeidia = GetComponent<ObjectMedia>();
        //cParticle = GetComponent<ParticleTransformManager>();
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
    //    //Debug.Log("CharacterMode-->Update");
    //}

    //void FixedUpdate() {
    //    //Debug.Log("CharacterMode-->FixedUpdate");
    //}

    //void LateUpdate() {
    //}    

    public void PickupItem(ItemPickupEnum type,float value) {
        //Debug.Log("CharacterMode-->PickupItem");
        if (ItemPickupEnum.Hp == type) {
            Debug.Log("CharacterMode-->AddHp");
            cMeidia.playAudio(AudioEnum.Pickup);
        }
        else if (ItemPickupEnum.Coin == type) {
            cMeidia.playAudio(AudioEnum.Coin);
            //Debug.Log("CharacterMode-->AddCoins");
            //cParticle.playParticle(ParticleEnum.Jump);
        }
        else if (ItemPickupEnum.Life == type) {
            cMeidia.playAudio(AudioEnum.Life);
            //Debug.Log("CharacterMode-->AddLife");
        }
        else if (ItemPickupEnum.Key == type) {
            cMeidia.playAudio(AudioEnum.Key);
            //Debug.Log("CharacterMode-->AddKey");
        }
    }
}






















