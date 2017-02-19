//if ((status & MotionStatusEnum.FacingRight) == MotionStatusEnum.FacingRight)

//status &= ~MotionStatusEnum.FacingRight;

public enum MassageEnum {
    msgSetMoveInput,
    msgSetJumpInput,
    msgSetActioinInput,

    msgSetJumpStatus,
    msgFlipHorizontal,
}

public enum InputEnum {
    None,
    WalkLeft,
    WalkRight,
    RunLeft,
    RunRight,
    Crouch,
    Jump,
    RunJump,
    CrouchJump,
    GoTube,
}

[System.Flags]
public enum CharacterState {
    FacingRight = 1 << 0,
    Crouch = 1<<1,
}

public enum MoveStatus {
    Stay,
    Walk,
    Run,
}

public enum JumpStatus {
    Landed,
    Jump,
    DoubleJump,
    Fall,
}
