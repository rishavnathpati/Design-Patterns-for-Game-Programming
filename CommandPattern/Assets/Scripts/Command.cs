using UnityEngine;

public abstract class Command
{
    public abstract void Execute(Animator animator);
}

public class PerformPunch : Command
{
    private static readonly int IsPunching = Animator.StringToHash("isPunching");

    public override void Execute(Animator animator)
    {
        animator.SetTrigger(IsPunching);
    }
}

public class PerformJump : Command
{
    private static readonly int IsJumping = Animator.StringToHash("isJumping");

    public override void Execute(Animator animator)
    {
        animator.SetTrigger(IsJumping);
    }
}

public class PerformKick : Command
{
    private static readonly int IsKicking = Animator.StringToHash("isKicking");

    public override void Execute(Animator animator)
    {
        animator.SetTrigger(IsKicking);
    }
}


public class DoNothing : Command
{
    public override void Execute(Animator animator)
    {
    }
}