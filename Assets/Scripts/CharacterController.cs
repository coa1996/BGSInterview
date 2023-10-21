using UnityEngine;
using UnityEngine.Assertions;

public class CharacterController : MonoBehaviour
{
    private BodyAnimator[] _bodyAnimators;

    private CharacterMovement _movementLogic;

    private void Awake()
    {
        _bodyAnimators = GetComponentsInChildren<BodyAnimator>();
        _movementLogic = GetComponent<CharacterMovement>();

        Assert.IsNotNull(_movementLogic, "CharacterController :: MovementLogic component is missing from the character Game Object!");

        _movementLogic.OnMovementStateUpdatedEvent += onCharacterMovementStateUpdatedEventHandler;
    }

    private void onCharacterMovementStateUpdatedEventHandler(MovementDirection movementDirection)
    {
        Debug.Log(movementDirection.ToString());
        foreach (BodyAnimator bodyAnimator in _bodyAnimators)
        {
            bodyAnimator.SetAnimationCategory(movementDirection.ToString());
        }
    }
}
