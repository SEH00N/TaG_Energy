using UnityEngine;

public class PlayerMoveAction : FSMAction
{
	[SerializeField] PlayInputSO input = null;

    [Space(15f)]
    [SerializeField] float moveSpeed = 10f;

    private CharacterMovement movement = null;

    public override void Init(FSMBrain brain, FSMState state)
    {
        base.Init(brain, state);

        movement = brain.GetComponent<CharacterMovement>();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        Vector3 velocity = Vector3.zero;
        velocity += brain.transform.right * input.MovementInput.x * moveSpeed;
        velocity += brain.transform.forward * input.MovementInput.y * moveSpeed;
        movement.SetVelocity(velocity);
    }

    public override void ExitState()
    {
        base.ExitState();
        movement.SetVelocity(Vector3.zero);
    }
}
