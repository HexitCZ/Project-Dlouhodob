using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public GameObject fieldHolder;

    public GameObject fieldPrefab;

    private List<GameObject> fields;



    private void Awake()
    {
        fields = new List<GameObject>();
        


    }

    private void Start()
    {
        FPSInteractionManager.instance.DisableFPSInteraction();

        print(fields.Count);

    }

}
