using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBuildPreview : MonoBehaviour
{
    [SerializeField] BuildingsPlacer buildingsPlacer;
    [SerializeField] GameObject Preview;
    [SerializeField] GameObject buildType;

    public void OnMouseClick()
    {
        buildingsPlacer.spawnPreview(Preview, buildType, transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
