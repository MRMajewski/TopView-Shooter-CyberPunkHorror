using UnityEngine;

/// <summary>
/// State Machine implementation.
/// Uses BaseState as base class for storing currently operating state.
/// </summary>
public class StateMachine : MonoBehaviour
{
    // Reference to currently operating state.
    private BaseState currentState;

    // Reference to movement script of our UFO.
    [SerializeField]
    private ZombieStateMachine zombie;
    public ZombieStateMachine Zombie => zombie;
    public PlayerPC targetPlayer;

    /// <summary>
    /// Unity method called on a first frame as object is enabled.
    /// On start we are changing state so our ship will start patrolling.
    /// </summary>
    private void Awake()
    {
        targetPlayer = FindObjectOfType<PlayerPC>();
    }

    private void Start()
    {
        var waitState = new WaitState();
       // waitState.minWait = 2;

        // And than pass it through
        ChangeState(waitState);
    }

    /// <summary>
    /// Unity method called each frame
    /// </summary>
    private void Update()
    {
        // If we have reference to state, we should update it!
        if (currentState != null)
        {
            currentState.UpdateState();
         
        }
    }

    /// <summary>
    /// Method used to change state
    /// </summary>
    /// <param name="newState">New state.</param>
    public void ChangeState(BaseState newState)
    {
        // If we currently have state, we need to destroy it!
        if (currentState != null)
        {
            currentState.DestroyState();
        }

        // Swap reference
        currentState = newState;
        Debug.Log(currentState);

        // If we passed reference to new state, we should assign owner of that state and initialize it!
        // If we decided to pass null as new state, nothing will happened.
        if (currentState != null)
        {
            currentState.owner = this;
            currentState.PrepareState();
        }
    }
}

