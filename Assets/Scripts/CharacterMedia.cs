using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMedia : MonoBehaviour {
    
    private Rigidbody2D rb2D;
    private Animator anim;

    private bool landed;
    private MoveStatus moveStatus;

    void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void OnEnable() {
       
    }

    void Disable() {

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        playAnimation();
    }

    public void msgSetJumpStatus(JumpStatus msgData) {
        //Debug.Log("CharacterMedia-->msgSetJumpStatus " + System.Enum.GetName(typeof(JumpStatus), msgData));
        landed = (JumpStatus.Landed == msgData);
    }

    void playAnimation() {
        anim.SetBool("Landed", landed);
        anim.SetFloat("SpeedX", Mathf.Abs(rb2D.velocity.x));
        anim.SetFloat("SpeedY", rb2D.velocity.y);
    }

    void msgFlipHorizontal() {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
