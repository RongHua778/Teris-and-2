using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ReusableObject : MonoBehaviour,IResuable
{
    public abstract void OnSpawn();
    public abstract void OnUnSpawn();
}
