using UnityEngine;
using StateStuff;

public class state_PassAndWait : State<AI>
{
    private static state_PassAndWait _instance;

    private state_PassAndWait()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static state_PassAndWait Instance
    {
        get
        {
            if (_instance == null)
            {
                new state_PassAndWait();
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
        _owner.distanceFromBall = Vector3.Distance(_owner.ball.transform.position, _owner.transform.position);
        if (_owner.distanceFromBall > 10f)
        {
            _owner.stateMachine.ChangeState(state_Wait.Instance);
        }
    }
}