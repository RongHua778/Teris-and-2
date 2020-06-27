using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPool
{
    GameObject m_prefab;
    string m_Name;
    List<GameObject> m_objects = new List<GameObject>();
    public string Name
    {
        //get { return m_prefab.name; }
        get { return m_Name; }
    }
    public SubPool(string name,GameObject prefab)
    {
        this.m_prefab = prefab;
        m_Name = name;
    }



    public GameObject Spawn()
    {
        GameObject go = null;
        foreach (GameObject obj in m_objects)
        {
            if (!obj.activeSelf)
            {
                go = obj;
                break;
            }
        }

        if (go == null)
        {
            go = GameObject.Instantiate<GameObject>(m_prefab);
            m_objects.Add(go);
        }

        go.SetActive(true);
        go.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);
        return go;
    }

    //回收对象
    public void UnSpawn(GameObject go)
    {
        if (Contains(go))
        {
            go.SendMessage("OnUnSpawn", SendMessageOptions.DontRequireReceiver);
            go.SetActive(false);
        }
    }

    public void UnSpawnAll()
    {
        foreach (GameObject item in m_objects)
        {
            if (item.activeSelf)
            {
                UnSpawn(item);
            }
        }
    }

    public bool Contains(GameObject go)
    {
        return m_objects.Contains(go);
    }
}
