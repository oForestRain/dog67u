using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTransformManager : MonoBehaviour {

    public ParticleEnumTransform[] particleEnumTransform;
    private Dictionary<ParticleEnum, Transform> transformMapping;

    //private DelegateManager dManager;

    void Awake() {
        //dManager = GetComponent<DelegateManager>();
        transformMapping = new Dictionary<ParticleEnum, Transform>();
    }

    void OnEnable() {
        //dManager.addDelegate(DelegateEnum.Particle, playParticle);
        transformMapping = new Dictionary<ParticleEnum, Transform>();

        int len = particleEnumTransform.Length;
        for (int i = 0; i < len; i++) {
            transformMapping.Add(particleEnumTransform[i].pEnum, particleEnumTransform[i].pTransform);
        }
    }

    void Disable() {
        //dManager.decreaseDelegate(DelegateEnum.Particle, playParticle);

        transformMapping.Clear();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("ParticleTransformManager-->Update " + transformMapping[ParticleEnum.Jump].position);
    }

    public void playParticle(ParticleEnum inputEnum) {
         Transform particle = SceneMode.instance.getParticleByEnum(inputEnum);
        if (transformMapping.ContainsKey(inputEnum) && particle != null) {
            Instantiate(particle, transformMapping[inputEnum].position, transform.rotation);
        }
    }

    //void playParticle(object[] rMsgData) {
    //    ParticleEnum inputEnum;
    //    Transform particle;

    //    if (rMsgData.Length >= 2) {
    //        inputEnum = (ParticleEnum)rMsgData[0];
    //        particle = SceneMode.instance.getParticleByEnum(inputEnum);
    //        if (transformMapping.ContainsKey(inputEnum) && particle!=null) {
    //            Instantiate(particle, transformMapping[inputEnum].position,transform.rotation);
    //        }            
    //    }
    //}
}
