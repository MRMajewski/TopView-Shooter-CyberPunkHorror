using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewState : BaseState
{


    // Stores how much time left in waiting state.
    private float waitTime = 3f;

    /// <summary>
    /// Method called to prepare state to operate - same as Unity's Start()
    /// </summary>
    public override void PrepareState()
    {
        Debug.Log(this);

      //  base.PrepareState();        
     }

    /// <summary>
    /// Method called to update state on every frame - same as Unity's Update()
    /// </summary>
    public override void UpdateState()
    {

        owner.transform.position = Vector2.MoveTowards(owner.transform.position, owner.targetPlayer.transform.position, Time.deltaTime * 1f);

        // After each frame we are subtracting time that passed.
        waitTime -= Time.deltaTime;

        // When wait time is over it's time to change state!
        if (waitTime < 0)
        {
            // Find new place to go!
            owner.ChangeState(new MoveState());
        }

    }

    /// <summary>
    /// Method called to destroy state - same as Unity's OnDestroy() but here it might be important!
    /// </summary>
    public virtual void DestroyState() { }
}
