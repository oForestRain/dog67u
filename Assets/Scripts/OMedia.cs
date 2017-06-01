﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OMedia : MonoBehaviour {

    private Animator anim;

    public EnumAudioSource[] enumAudioSource;
    private Dictionary<AudioEnum, AudioSource> audioSourceMapping;
    //private DelegateManager dManager;

    void Awake() {
        //Debug.Log("OMedia-->Awake ");
        //dManager = GetComponent<DelegateManager>();
        anim = GetComponent<Animator>();

        audioSourceMapping = new Dictionary<AudioEnum, AudioSource>();
    }

    void OnEnable() {
        //Debug.Log("OMedia-->OnEnable ");
        //dManager.addDelegate(DelegateEnum.Animation, updateAnimation);
        //dManager.addDelegate(DelegateEnum.Audio, updateAudio);
        //facingRight = true;

        int len = enumAudioSource.Length;
        for (int i = 0; i < len; i++) {
            audioSourceMapping.Add(enumAudioSource[i].aEnum, enumAudioSource[i].aAudioSource);
        }
    }

    void Disable() {
        //dManager.decreaseDelegate(DelegateEnum.Animation, updateAnimation);
        //dManager.decreaseDelegate(DelegateEnum.Audio, updateAudio);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void playAnimation(AnimationEnum inputEnum,object inputData) {
        float velocity;
        bool boolean;
        if (inputEnum == AnimationEnum.VelocityX ||
                    inputEnum == AnimationEnum.VelocityY) {

            velocity = (float)inputData;
            anim.SetFloat(inputEnum.ToString(), velocity);
            //Debug.Log("OMedia-->updateAnimation " + inputEnum.ToString() + velocity);
        }
        else if (inputEnum == AnimationEnum.Grounded) {
            boolean = (bool)inputData;
            anim.SetBool(inputEnum.ToString(), boolean);
            //Debug.Log("OMedia-->updateAnimation " + inputEnum.ToString() + boolean);
        }
        else if (inputEnum == AnimationEnum.FacingRight) {
            turnAround();
            //Debug.Log("OMedia-->updateMove " + AnimationEnum.FacingRight);
        }
        else if (inputEnum == AnimationEnum.Bumped) {
            boolean = (bool)inputData;
            anim.SetBool(inputEnum.ToString(), boolean);
        }
    }

    void turnAround() {
        transform.Rotate(Vector3.up * 180);
    }

    public void playAudio(AudioEnum inputEnum, object inputData = null) {
        if (!audioSourceMapping.ContainsKey(inputEnum)) {
            return;
        }

        AudioSource audioSource = audioSourceMapping[inputEnum];
        //AudioClip currentAc = SceneMode.instance.getAudioClipByEnum(inputEnum);
        //AudioMixerGroup currentAmg = SceneMode.instance.getAudioMixerGroupByEnum(inputEnum);

        EnumAudioClip currentAc = SceneMode.instance.getAudioByEnum(inputEnum);

        //audioSource = this.gameObject.AddComponent<AudioSource>();
        //if (currentAc) {
        //    if (!audioSource.isPlaying) {
        //        audioSource.clip = currentAc;
        //        audioSource.outputAudioMixerGroup = currentAmg;
        //        audioSource.Play();
        //        //Debug.Log("OMedia-->updateAudio " + audioSource.outputAudioMixerGroup.name);
        //    }
        //    //Debug.Log("CharacterMedia-->updateAudio " + inputEnum.ToString());
        //}
        if (currentAc!=null) {
            if (!audioSource.isPlaying) {
                audioSource.clip = currentAc.aAudioClip;
                audioSource.outputAudioMixerGroup = currentAc.outputAudioMixerGroup;
                audioSource.Play();
                //Debug.Log("OMedia-->updateAudio " + audioSource.outputAudioMixerGroup.name);
            }
            //Debug.Log("OMedia-->updateAudio " + inputEnum.ToString());
        }
    }

    //void updateAnimation(object[] rMsgData) {
    //    AnimationEnum inputEnum;
    //    float velocity;
    //    bool boolean;

    //    if (rMsgData.Length >= 2) {
    //        inputEnum = (AnimationEnum)rMsgData[0];
    //    }
    //    else {
    //        return;
    //    }

    //    if (inputEnum == AnimationEnum.VelocityX ||
    //                inputEnum == AnimationEnum.VelocityY) {

    //        velocity = (float)rMsgData[1];
    //        anim.SetFloat(inputEnum.ToString(), velocity);
    //        //Debug.Log("CharacterMedia-->updateAnimation " + inputEnum.ToString() + velocity);
    //    }
    //    else if (inputEnum == AnimationEnum.Grounded) {

    //        boolean = (bool)rMsgData[1];
    //        anim.SetBool(inputEnum.ToString(), boolean);
    //        //Debug.Log("CharacterMedia-->updateAnimation " + inputEnum.ToString() + boolean);
    //    }
    //    else if (inputEnum == AnimationEnum.FacingRight) {
    //        turnAround();
    //        //Debug.Log("CharacterMedia-->updateMove " + AnimationEnum.FacingRight);
    //    }
    //}

    //void updateAudio(object[] rMsgData) {
    //    AudioEnum inputEnum;
    //    AudioClip currentAc;

    //    if (rMsgData.Length >= 2) {
    //        inputEnum = (AudioEnum)rMsgData[0];
    //    }
    //    else {
    //        return;
    //    }

    //    if (inputEnum == AudioEnum.Jump) {
    //        currentAc = SceneMode.instance.getAudioClipByEnum(inputEnum);
    //        if (!audioSource.isPlaying) {
    //            audioSource.clip = currentAc;
    //            audioSource.Play();
    //        }
    //        //Debug.Log("CharacterMedia-->updateAudio " + inputEnum.ToString());
    //    }
    //}
}