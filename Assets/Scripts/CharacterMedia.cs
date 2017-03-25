using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMedia : MonoBehaviour {

    private Animator anim;
    private AudioSource audioSource;
    //private DelegateManager dManager;

    void Awake() {
        //Debug.Log("CharacterMedia-->Awake ");
        //dManager = GetComponent<DelegateManager>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable() {
        //Debug.Log("CharacterMedia-->OnEnable ");
        //dManager.addDelegate(DelegateEnum.Animation, updateAnimation);
        //dManager.addDelegate(DelegateEnum.Audio, updateAudio);
        //facingRight = true;
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
            //Debug.Log("CharacterMedia-->updateAnimation " + inputEnum.ToString() + velocity);
        }
        else if (inputEnum == AnimationEnum.Grounded) {
            boolean = (bool)inputData;
            anim.SetBool(inputEnum.ToString(), boolean);
            //Debug.Log("CharacterMedia-->updateAnimation " + inputEnum.ToString() + boolean);
        }
        else if (inputEnum == AnimationEnum.FacingRight) {
            turnAround();
            //Debug.Log("CharacterMedia-->updateMove " + AnimationEnum.FacingRight);
        }
    }

    void turnAround() {
        transform.Rotate(Vector3.up * 180);
    }

    public void playAudio(AudioEnum inputEnum, object inputData = null) {
        AudioClip currentAc;
        currentAc = SceneMode.instance.getAudioClipByEnum(inputEnum);
        //audioSource = this.gameObject.AddComponent<AudioSource>();
        if (currentAc) {
            if (!audioSource.isPlaying) {
                audioSource.clip = currentAc;
                audioSource.Play();
                //Debug.Log("CharacterMedia-->updateAudio " + audioSource.outputAudioMixerGroup.name);
            }
            //Debug.Log("CharacterMedia-->updateAudio " + inputEnum.ToString());
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
