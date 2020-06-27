using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResuable
{
    //当取出时调用
    void OnSpawn();

    //当回收时调用
    void OnUnSpawn();
}
