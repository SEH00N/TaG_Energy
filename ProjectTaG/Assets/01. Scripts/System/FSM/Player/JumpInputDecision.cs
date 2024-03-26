using UnityEngine;

public class JumpInputDecision : FSMDecision
{
    [SerializeField] PlayInputSO input = null;
    private bool jumpPressed = false;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);

        input.OnJumpEvent += HandleJump;
    }

    public override bool MakeDecision()
    {
        return jumpPressed;
    }

    private void HandleJump(bool active)
    {
        jumpPressed = active;
    }
}
