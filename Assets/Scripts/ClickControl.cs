using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickControl : MonoBehaviour
{
    private NavMeshAgent agent;
    public LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (line)
        {
            line.transform.position = Vector3.up; // simplifies line.SetPosition calls later
            line.positionCount = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                // should probably lock this to a specific layer or object
                agent.path.ClearCorners();
                agent.SetDestination(hit.point);
            }
        }

        // adjust the line child so that we can see a visible path
        if (line && agent.remainingDistance > agent.stoppingDistance)
        {
            line.positionCount = agent.path.corners.Length;
            line.SetPositions(agent.path.corners);
        }

    }
}
