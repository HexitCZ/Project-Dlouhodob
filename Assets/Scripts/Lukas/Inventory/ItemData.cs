using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Item data")]
public class ItemData : ScriptableObject
{
    public string id;
    public string name;
    public GameObject model;
    void Start()
    {
        
    }

    void Update()
    {
        model.transform.Rotate(0, 10, 0);
    }
}
