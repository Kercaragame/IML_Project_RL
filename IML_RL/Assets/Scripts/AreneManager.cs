using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreneManager : MonoBehaviour
{

    protected Vector3 resetAgentPos;
    protected Vector3 resetObjectifPos;

    [SerializeField]
    protected GameObject objectif;
    [SerializeField]
    protected GameObject agent;
    [SerializeField]
    protected Material winMaterial;
    [SerializeField]
    protected Material looseMaterial;
    [SerializeField]
    protected MeshRenderer floorMeshRenderer;


    public virtual void resetRun()
    {
        float margePos = 3f;
        resetObjectifPos = new Vector3(Random.Range(-5.8f, 2f), 0.16f, Random.Range(-4.57f, 3.3f));
        resetAgentPos = new Vector3(Random.Range(-4.4f, 3.3f), 1.5f, Random.Range(-4.4f, 3.4f));
        //print("Distance : " + Mathf.Abs(resetObjectifPos.x - resetAgentPos.x));


        while (Mathf.Abs(resetObjectifPos.x - resetAgentPos.x) < margePos)
        {
            resetAgentPos = new Vector3(Random.Range(-4.4f, 3.3f), 1.5f, Random.Range(-4.4f, 3.4f));

        }
        agent.transform.localPosition = resetAgentPos;
        objectif.transform.localPosition = resetObjectifPos;


    }

    public virtual void SuccesTask()
    {
        floorMeshRenderer.material = winMaterial;
    }

    public void FailedTask()
    {
        floorMeshRenderer.material = looseMaterial;
    }
}
