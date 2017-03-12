using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMode : MonoBehaviour {

    public static SceneMode instance;

    public EnumAudioClip[] enumAudioClip;
    private Dictionary<AudioEnum, AudioClip> audioMapping;

    public EnumParticle[] enumParticle;
    private Dictionary<ParticleEnum, Transform> particleMapping;

    void Awake() {
        //Debug.Log("SceneMode-->Awake " + GameInstance.Instance());
        instance = this;

        audioMapping = new Dictionary<AudioEnum, AudioClip>();
        particleMapping = new Dictionary<ParticleEnum, Transform>();

        //Debug.Log("SceneMode-->Awake " + audioMapping.Count);
    }

    void OnEnable() {
        //Debug.Log("SceneMode-->OnEnable " + GameInstance.Instance());
        //Debug.Log("SceneMode-->OnEnable " + this);

        audioMapping = new Dictionary<AudioEnum, AudioClip>();
        particleMapping = new Dictionary<ParticleEnum, Transform>();

        int len = enumAudioClip.Length;
        for (int i = 0; i < len; i++) {
            audioMapping.Add(enumAudioClip[i].aEnum, enumAudioClip[i].aAudioClip);
        }

        len = enumParticle.Length;
        for (int i = 0; i < len; i++) {
            particleMapping.Add(enumParticle[i].pEnum, enumParticle[i].pTransform);
        }

        //Debug.Log("SceneMode-->OnEnable " + audioMapping.Count);
    }

    void Disable() {
        audioMapping.Clear();
        particleMapping.Clear();

        //Debug.Log("SceneMode-->Disable " + audioMapping.Count);
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public AudioClip getAudioClipByEnum(AudioEnum aEnum) {
        //Debug.Log("SceneMode-->getAudioClipByEnum " + audioMapping.Count);
        //foreach (KeyValuePair<AudioEnum, AudioClip> kvp in audioMapping) {
        //    Debug.Log("SceneMode-->getAudioClipByEnum " + kvp.Key.ToString() + " " +kvp.Value);
        //}
        if (!audioMapping.ContainsKey(aEnum)) {
            return null;
        }
        return audioMapping[aEnum];
    }

    public Transform getParticleByEnum(ParticleEnum pEnum) {
        //Debug.Log("SceneMode-->getParticleByEnum " + pEnum.ToString() + " " + particleMapping[pEnum]);
        if (!particleMapping.ContainsKey(pEnum)) {
            return null;
        }
        return particleMapping[pEnum];
    }
}
