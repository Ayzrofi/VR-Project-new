using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolerObject : MonoBehaviour {
   
    public GameObject PooledObject;
    public int JumlahObject;

    List<GameObject> ObjectList;

    void Start()
    {
        ObjectList = new List<GameObject>();

        for (int i = 0; i < JumlahObject; i++)
        {
            GameObject Obj = (GameObject)Instantiate(PooledObject);
            Obj.SetActive(false);
            Obj.transform.SetParent(transform);
            ObjectList.Add(Obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < ObjectList.Count; i++)
        {
            if (!ObjectList[i].activeInHierarchy)
            {
                return ObjectList[i];
            }
        }
        GameObject Obj = (GameObject)Instantiate(PooledObject);
        Obj.SetActive(false);
        ObjectList.Add(Obj);
        return Obj;
    }



}// end class


















