using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    // every single playerstate should reference the player

    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void Move(Vector3 motion, float deltaTime) 
    {
        
        stateMachine.Controller.Move((motion + stateMachine.ForceReceiver.Movement) * deltaTime);
    }

    protected void FaceTarget() 
    {
        if(stateMachine.Targeter.CurrentTarget == null)
        {
            return;
        }

        Vector3 lookPos = stateMachine.Targeter.CurrentTarget.transform.position - stateMachine.transform.position;
        lookPos.y = 0;

        stateMachine.transform.rotation = Quaternion.LookRotation(lookPos);
    }
}
