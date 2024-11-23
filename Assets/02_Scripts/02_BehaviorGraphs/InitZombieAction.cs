using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "InitZombie", story: "[ZombieDataSO] 를 이용해 [TraceDistance] 와 [AttackDistance] 를 초기화 한다.", category: "Action", id: "ece31102a4015bc5898ec388dea79024")]
public partial class InitZombieAction : Action
{
    [SerializeReference] public BlackboardVariable<ZombieDataSO> ZombieDataSO;
    [SerializeReference] public BlackboardVariable<float> TraceDistance;
    [SerializeReference] public BlackboardVariable<float> AttackDistance;

    protected override Status OnStart()
    {
        // ScriptableObject를 사용해서 데이터 초기화
        TraceDistance.Value = ZombieDataSO.Value.traceDistance;
        AttackDistance.Value = ZombieDataSO.Value.attackDistance;

        return Status.Running;
    }
}

