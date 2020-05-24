using UnityEngine;
using StateStuff;
using UnityEngine.AI;



public class state_GetPosition : State<AI>
{
    private static state_GetPosition _instance;


    private state_GetPosition()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static state_GetPosition Instance
    {
        get
        {
            if (_instance == null)
            {
                new state_GetPosition();
            }

            return _instance;
        }
    }

    //public object TacticsTable { get; private set; }

    public override void EnterState(AI _owner)
    {
        switch (_owner.name)
        {
            case "Player1":
                _owner.GetComponent<NavMeshAgent>().SetDestination(TacticsTable.Instance.positionForPlayers[0]);
                break;
            case "Player2":
                _owner.GetComponent<NavMeshAgent>().SetDestination(TacticsTable.Instance.positionForPlayers[1]);
                break;
            case "Player3":
                _owner.GetComponent<NavMeshAgent>().SetDestination(TacticsTable.Instance.positionForPlayers[2]);
                break;
            case "Player4":
                _owner.GetComponent<NavMeshAgent>().SetDestination(TacticsTable.Instance.positionForPlayers[3]);
                break;
            case "Player5":
                _owner.GetComponent<NavMeshAgent>().SetDestination(TacticsTable.Instance.positionForPlayers[4]);
                break;
            default:

                break;
        }
    }

    public override void ExitState(AI _owner)
    {
        // Debug.Log("Exiting state_Wait State");
    }

    public override void UpdateState(AI _owner)
    {
        switch (_owner.tag)
        {
            case "Player1":
                if (_owner.transform.position.x == TacticsTable.Instance.positionForPlayers[0].x &&
                     _owner.transform.position.z == TacticsTable.Instance.positionForPlayers[0].z)
                {
                    _owner.stateMachine.ChangeState(state_Wait.Instance);
                    //Debug.Log("Buraya girdi");
                    _owner.settledPosition = true;
                }     
                break;
            case "Player2":
                if (_owner.transform.position.x == TacticsTable.Instance.positionForPlayers[1].x &&
                     _owner.transform.position.z == TacticsTable.Instance.positionForPlayers[1].z) 
                {
                    _owner.stateMachine.ChangeState(state_Wait.Instance);
                    //Debug.Log("Buraya girdi");
                    _owner.settledPosition = true;
                }              
                break;
            case "Player3":
                if (_owner.transform.position.x == TacticsTable.Instance.positionForPlayers[2].x &&
                    _owner.transform.position.z == TacticsTable.Instance.positionForPlayers[2].z) 
                {
                    _owner.stateMachine.ChangeState(state_Wait.Instance);
                    //Debug.Log("Buraya girdi");
                    _owner.settledPosition = true;
                }  
                break;
            case "Player4":
                if (_owner.transform.position.x == TacticsTable.Instance.positionForPlayers[3].x &&
                     _owner.transform.position.z == TacticsTable.Instance.positionForPlayers[3].z) 
                {
                    _owner.stateMachine.ChangeState(state_Wait.Instance);
                    //Debug.Log("Buraya girdi");
                    _owner.settledPosition = true;
                }  
                break;
            case "Player5":
                if (_owner.transform.position.x == TacticsTable.Instance.positionForPlayers[4].x &&
                    _owner.transform.position.z == TacticsTable.Instance.positionForPlayers[4].z) 
                {
                    _owner.stateMachine.ChangeState(state_Wait.Instance);
                    //Debug.Log("Buraya girdi");
                    _owner.settledPosition = true;
                }
                    
                break;
            default:
                break;
        }

       
    }
}


