using UnityEngine;

public class PlayerJumpAction : FSMAction
{
	[SerializeField] float jumpPower = 10f;

    private CharacterMovement movement = null;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);

        movement = brain.GetComponent<CharacterMovement>();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(movement.IsGround)
            movement.SetVerticalVelocity(jumpPower);
    }
}
