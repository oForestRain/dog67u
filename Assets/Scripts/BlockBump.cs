using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBump : MonoBehaviour {

    public RendererEnum currentType;
    public RendererEnum nextType;
    public ItemPickupEnum hidePickup;
    public int amount =1;

    public SpriteRenderer sRenderer;
    public ObjectMedia cMeidia;
    public ParticleTransformManager cParticle;
        
    public bool animate;
 
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        EnumRenderer currentRendererSprite = SceneMode.instance.getRendererByEnum(currentType);

        if (!ReferenceEquals(currentRendererSprite, null)) {
            sRenderer.sprite = currentRendererSprite.rSprite;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == TagEnum.Head.ToString()) {
            if (!ReferenceEquals(other.transform.parent, null) && other.transform.parent.tag == TagEnum.Player.ToString()){
                cMeidia.playAnimation(AnimationEnum.Bumped, true);
                cMeidia.playAudio(AudioEnum.Bump);
            }            
        }
    }

    void bumpedAnimationComplete() {
        cMeidia.playAnimation(AnimationEnum.Bumped, false);
    }
}
