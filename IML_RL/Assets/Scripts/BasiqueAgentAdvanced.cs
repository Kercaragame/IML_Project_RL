using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class BasiqueAgentAdvanced : BasiqueAgent
{
    [SerializeField]
    private AreneManagerAdvanced managerAdvanced;

    [SerializeField]
    private List<GameObject> _obsList = new List<GameObject>();


    private void Update()
    {
        Vector3 targetPostition = new Vector3(Objectif.transform.position.x,this.transform.position.y, Objectif.transform.position.z);
        this.transform.LookAt(targetPostition);
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        base.CollectObservations(sensor);
        foreach(GameObject obs in _obsList)
        {
            sensor.AddObservation(obs.transform.position);
        }

    }

    public override void OnEpisodeBegin()
    {
        managerAdvanced.resetRun();
    }

    public void setObs(List<GameObject> obsList)
    {
        _obsList = obsList;
    }

    //Gestion du Reward
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("objectif"))
        {
            //getReward
            SetReward(1f);
            managerAdvanced.SuccesTask();
            EndEpisode();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("wall"))
        {
            //getPunition
            SetReward(-1f);
            managerAdvanced.FailedTask();
            EndEpisode();
        }

        if (collision.collider.CompareTag("obs"))
        {
            //getPunition
            SetReward(-1f);
            managerAdvanced.FailedTask();
            EndEpisode();
        }

    }
}
