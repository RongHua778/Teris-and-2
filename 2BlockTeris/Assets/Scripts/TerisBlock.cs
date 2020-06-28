using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerisBlock : MonoBehaviour
{

    public Vector3 rotationPoint;

    public float falltime = 0.8f;

    public Vector3 LastMoveDir = Vector3.zero;
    public List<Vector3> currentPoints = new List<Vector3>();

    public bool isBomb = false;

    public int ID;

    void Start()
    {

    }

    public void Rot()
    {
        transform.RotateAround(transform.TransformPoint(rotationPoint), Vector3.forward, 90f);
        SetPoints();
    }

    public void RotBack()
    {
        transform.RotateAround(transform.TransformPoint(rotationPoint), Vector3.forward, -90f);
        SetPoints();
    }

    public void Move(Vector3 dir)
    {
        transform.position += dir;
        LastMoveDir = dir;
        SetPoints();
    }

    public void MoveBack()
    {
        transform.position -= LastMoveDir;
        SetPoints();
    }
    void SetPoints()
    {
        currentPoints.Clear();
        foreach (Transform children in transform)
        {
            Vector3 pos = new Vector3(Mathf.RoundToInt(children.position.x), Mathf.RoundToInt(children.position.y), Mathf.RoundToInt(children.position.z));
            currentPoints.Add(pos);
        }
    }

    public void CheckClash(TerisBlock another)
    {
        foreach (Vector3 pos in currentPoints)
        {
            if (another.currentPoints.Contains(pos))
            {
                another.MoveBack();
                break;
            }
        }
    }

    public bool CheckRotClash(TerisBlock another, bool isBlock)
    {
        foreach (Vector3 pos in currentPoints)
        {
            if (another.currentPoints.Contains(pos))
            {
                if (isBlock)
                {
                    another.RotBack();
                    return false;
                }
                else
                {
                    RotBack();
                    another.RotBack();
                    return false;
                }
                
            }
        }
        return true;

    }



    // Update is called once per frame
    void Update()
    {

    }
}




