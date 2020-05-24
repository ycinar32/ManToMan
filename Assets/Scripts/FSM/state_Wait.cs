using UnityEngine;
using StateStuff;
using UnityEngine.AI;

public class state_Wait : State<AI>
{
    private static state_Wait _instance;

    private state_Wait()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static state_Wait Instance
    {
        get
        {
            if (_instance == null)
            {
                new state_Wait();
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

        
        if((Team.Instance.teamHasBall) && _owner.stateMachine.currentState == state_Wait.Instance && (!Team.Instance.teamSettledPosition))
        {
            _owner.stateMachine.ChangeState(state_GetPosition.Instance);
        }
        /*if (_owner.hasBall)
        {
            _owner.stateMachine.ChangeState(state_Pass.Instance);
        }*/
        if (_owner.receivingPass)
        {
            _owner.stateMachine.ChangeState(state_ReceivePass.Instance);
        }
        if ((!_owner.ball.GetComponent<Ball>().ball_on_air) && _owner.isClosestTeamMemberToBall() && !(_owner.hasBall) && !(_owner.wasLastOwner) && !(_owner.TeamMember1.GetComponent<AI>().receivingPass) &&
                                                                                                 !(_owner.TeamMember2.GetComponent<AI>().receivingPass) &&
                                                                                                 !(_owner.TeamMember3.GetComponent<AI>().receivingPass) &&
                                                                                                 !(_owner.TeamMember4.GetComponent<AI>().receivingPass)     )   
        {
            _owner.stateMachine.ChangeState(state_ChaseBall.Instance);
        }
        if (Team.Instance.teamSettledPosition && _owner.hasBall && (!_owner.ball.GetComponent<Ball>().ball_on_air) && !_owner.dribbleSuccessed)
        {
            //_owner.stateMachine.ChangeState(state_Dribble.Instance);
        }    
    }
}