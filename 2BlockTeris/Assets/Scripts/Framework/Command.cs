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
    public abstract void execute(TerisBlock teris1,TerisBlock teris2);
}

public class MoveCommand : Command
{
    public override void execute(TerisBlock teris1, TerisBlock teris2)
    {
      

    }

}