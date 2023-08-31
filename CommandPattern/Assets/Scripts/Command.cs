using UnityEngine;

public abstract class Command
{
    public abstract void Execute(Animator anim, bool forward);
}

public class MoveForward : Command
{
    public override void Execute(Animator anim, bool forward)
    {
        anim.SetTrigger(forward ? "isWalking" : "isWalkingR");
    }
}

public class PerformJump : Command
{
    private static readonly int IsJumping = Animator.StringToHash("isJumping");
    private static readonly int IsJumpingR = Animator.StringToHash("isJumpingR");

    public override void Execute(Animator anim, bool forward)
    {
        anim.SetTrigger(forward ? IsJumping : IsJumpingR);
    }
}

public class PerformKick : Command
{
    private static readonly int IsKicking = Animator.StringToHash("isKicking");
    private static readonly int IsKickingR = Animator.StringToHash("isKickingR");

    public override void Execute(Animator anim, bool forward)
    {
        anim.SetTrigger(forward ? IsKicking : IsKickingR);
    }
}

public class PerformPunch : Command
{
    private static readonly int IsPunching = Animator.StringToHash("isPunching");
    private static readonly int IsPunchingR = Animator.StringToHash("isPunchingR");

    public override void Execute(Animator anim, bool forward)
    {
        anim.SetTrigger(forward ? IsPunching : IsPunchingR);
    }
}