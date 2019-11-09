using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickControl : MonoBehaviour
{
    public OptionsMenuController options;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !options.isActive())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                // should probably lock this to a specific layer or object
                GetComponent<NavMeshAgent>().SetDestination(hit.point);
            }
        }
    }
}
