using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SceneMode : MonoBehaviour {

    public static SceneMode instance;

    public const int rendererSize = 4;
    public const int audioSize = 13;
    public const int particleSize = 1;
    public const int instantiationSize = 9;

    public RendererMapping rendererMapping;
    public AudioMapping audioMapping;
    public ParticleMapping particleMapping;
    public InstantiationMapping instantiationMapping;    

    void Awake() {
        //Debug.Log("SceneMode-->Awake " + GameInstance.Instance());
        instance = this;
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public EnumRenderer getRendererByEnum(RendererEnum rEnum) {
        return rendererMapping.getRendererByEnum(rEnum);
    }

    public EnumAudioClip getAudioByEnum(AudioEnum aEnum) {
        //Debug.Log("SceneMode-->getAudioByEnum " + audioMapping.getAudioByEnum(aEnum));
        return audioMapping.getAudioByEnum(aEnum);
    }
    
    public EnumParticle getParticleByEnum(ParticleEnum pEnum) {
        return particleMapping.getAudioByEnum(pEnum);
    }

    public EnumInstantiation getInstantiationByEnum(InstantiationEnum iEnum) {
        return instantiationMapping.getInstantiationByEnum(iEnum);
    }
}
