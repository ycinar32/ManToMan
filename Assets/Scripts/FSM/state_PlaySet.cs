using UnityEngine;
using StateStuff;
using UnityEngine.AI;

public class state_SetPlay : State<AI>
{
    private static state_SetPlay _instance;

    private state_SetPlay()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static state_SetPlay Instance
    {
        get
        {
            if (_instance == null)
            {
                new state_SetPlay();
            }

            return _instance;
        }
    }

    public override void EnterState(AI _owner)
    {
        // Debug.Log("Entering state_Wait State");
    }

    public override void ExitState(AI _owner)
    {
        // Debug.Log("Exiting state_Wait State");
    }

    public override void UpdateState(AI _owner)
    {
        if (_owner.hasBall)
        { 
            _owner.stateMachine.ChangeState(state_Pass.Instance);
        }
        else
        {
            _owner.stateMachine.ChangeState(state_Wait.Instance);
        }
    }
}