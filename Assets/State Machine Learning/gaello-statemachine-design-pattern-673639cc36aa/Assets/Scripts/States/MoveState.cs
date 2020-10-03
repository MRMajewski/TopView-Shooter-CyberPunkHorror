using UnityEngine;

/// <summary>
/// Move state.
/// Its picking new position to go to and than go back to wait state.
/// </summary>
public class MoveState : BaseState
{
    // Store picked position to go to
    private Vector2 targetPosition;
    float waitTime = 5f;
    //  private float waitTime;

    public override void PrepareState()
    {
        Debug.Log(this);

        base.PrepareState();

        // Picking random position
        targetPosition = new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-5.0f, 5.0f));
    }

    public override void UpdateState()
    {
        base.UpdateState();

        // Calculating direction in which UFO has to go to get to the destination
        var direction = targetPosition - new Vector2(owner.transform.position.x, owner.transform.position.y);
        if (direction.magnitude > 1)
        {
            direction.Normalize();
        }

        // Passing direction to our SimpleMovement component
        owner.Zombie.Move(direction);
        //if (direction.magnitude < 0.2f)
        //{
        //    // Now wait!
        //    owner.ChangeState(new NewState());
        //}

        waitTime -= Time.deltaTime;

        if (waitTime < 0)
        {
            // Find new place to go!
            owner.ChangeState(new WaitState());
        }
    }
}

