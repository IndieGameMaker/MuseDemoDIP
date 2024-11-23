using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CheckState", story: "[Agent] 와 [Player] 의 거리를 [TraceDistance] 와 [AttackDistance] 를 사용해 [State] 를 변경", category: "Action", id: "1cbed8639027d3b7727386872426a707")]
public partial class CheckStateAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<Transform> Player;
    [SerializeReference] public BlackboardVariable<float> TraceDistance;
    [SerializeReference] public BlackboardVariable<float> AttackDistance;
    [SerializeReference] public BlackboardVariable<State> State;

    protected override Status OnUpdate()
    {
        // 거리 계산 
        var distance = Vector3.Distance(Agent.Value.transform.position, Player.Value.position);
        // 거리에 따라서 State 변경
        if (distance <= AttackDistance.Value)
        {
            State.Value = global::State.ATTACK;
        }
        else if (distance <= TraceDistance.Value)
        {
            State.Value = global::State.TRACE;
        }
        else
        {
            State.Value = global::State.PATROL;
        }

        // Debug.Log($"State : {State.Value}");

        return Status.Success;
    }
}

