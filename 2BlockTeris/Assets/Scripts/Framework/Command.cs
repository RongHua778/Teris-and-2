using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    right,
    left,
    up,
    down
}

public abstract class Command
{
    public abstract void execute(Animator anim,Direction dir);
}

public class MoveCommand : Command
{
    public override void execute(Animator anim,Direction dir)
    {
        switch (dir)
        {
            case Direction.right:
                anim.SetTrigger("moveright");
                break;
            case Direction.left:
                anim.SetTrigger("moveleft");
                break;
            case Direction.up:
                anim.SetTrigger("moveup");
                break;
            case Direction.down:
                anim.SetTrigger("movedown");
                break;
        }

    }

}