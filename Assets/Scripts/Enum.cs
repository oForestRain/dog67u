//if ((status & MotionStatusEnum.FacingRight) == MotionStatusEnum.FacingRight)
//status &= ~MotionStatusEnum.FacingRight;

public enum StaticDelegateEnum {
    Input,
    Update,
    Motion,
    Action,   
    Animation,
    Audio,
}

public enum DelegateEnum {
    Input,
    Update,
    Motion,
    Action,
    Animation,
    Audio,
    Particle,
    Camera,
}

public enum CollisionEnum {
    
}


public enum UpdateEnum {
    JumpStatus,
}

public enum AnimationEnum {
    VelocityX, 
    FacingRight,
    VelocityY,
    Grounded,
}

public enum AudioEnum {
    Jump,
}

public enum ParticleEnum {
    Jump,
}

public enum CameraEnum {
    GroundedYAxis,
    Target,
    Anchoring,
    Following,
    Zooming,
}

public enum InputEnum {
    None,
    HorizontalMove,
    VerticalMove,
    Crouch,
    Jump,
    Action,
}

public enum MotionEnum {
    XAxis,
    YAxis,
    ZAxis,
    AddXAxis,
    AddYAxis,
    AddZAxis,
    ReverseXAxis,
    ReverseYAxis,
    ReverseZAxis,
}

[System.Flags]
public enum CharacterState {
    Crouch = 1<<0,
}

public enum MoveStatus {
    Stay,
    Run,
}

public enum JumpStatus {
    Grounded,
    Jump,
}
