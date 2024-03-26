using UnityEngine;

public class MoveInputDecision : FSMDecision
{
    [SerializeField] PlayInputSO input = null;

    public override bool MakeDecision()
    {
        return input.MovementInput.sqrMagnitude > 0f;
    }
}
