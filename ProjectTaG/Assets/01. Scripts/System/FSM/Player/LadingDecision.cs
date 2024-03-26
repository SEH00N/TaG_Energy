using UnityEngine;

public class LadingDecision : FSMDecision
{
    private CharacterMovement movement = null;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);

        movement = brain.GetComponent<CharacterMovement>();
    }

    public override bool MakeDecision()
    {
        return movement.IsGround;
    }
}
