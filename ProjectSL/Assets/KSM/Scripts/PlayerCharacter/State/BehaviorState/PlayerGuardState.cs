using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuardState : PlayerBaseState
{
    public PlayerGuardState(PlayerStateMachine currentContext, PlayerStateFactory stateFactory) : base(currentContext, stateFactory)
    {
        IsRootState = true;
        InitializeSubState();
    }
    public override void EnterState(PlayerBaseState prevState = null)
    {
        Debug.Log("Enter Guard State");
        Ctx.CombatController.OnGuard(prevState);
        Ctx.CharacterAnimator.SetLayerWeight(AnimationController.LAYERINDEX_BASELAYER, 1);
    }
    public override void UpdateState()
    {
        CheckSwitchStates();

    }
    public override void FixedUpdateState()
    {
        
    }
    public override void ExitState(PlayerBaseState nextState = null)
    {
        Ctx.CombatController.OffGuard(nextState);
    }
    public override void CheckSwitchStates()
    {
        if(!Ctx.IsGuardPressed)
        {
            SwitchState(Factory.Grounded());
        }
        else if(Ctx.IsAttackPressed)
        {
            SwitchState(Factory.Attack());
        }
        else if (Ctx.IsRollPressed || Ctx.IsBackStepPressed)
        {
            SwitchState(Factory.Roll());
        }
        else if (Ctx.BlockFlag)
        {
            SwitchState(Factory.Block());
        }
        else if(Ctx.HitFlag)
        {
            SwitchState(Factory.Hit());
        }
    }
    public override void InitializeSubState()
    {
        if (!Ctx.IsMovementPressed && !Ctx.IsRunPressed)
        {
            //Debug.Log("GroundedState SetSubState Idle");
            SetSubState(Factory.Idle());
        }
        else if (Ctx.IsMovementPressed && !Ctx.IsRunPressed && !Ctx.IsWalkPressed)
        {
            //Debug.Log("GroundedState SetSubState Jog");
            SetSubState(Factory.Jog());
        }
    }
}
