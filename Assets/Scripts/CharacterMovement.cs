using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public delegate void MovementStateUpdatedEventargs(MovementDirection newMovementDirection);

    public MovementStateUpdatedEventargs OnMovementStateUpdatedEvent;

    int eventTest = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnMovementStateUpdatedEvent?.Invoke((MovementDirection)(eventTest % 5));
            eventTest++;
        }
    }
}
