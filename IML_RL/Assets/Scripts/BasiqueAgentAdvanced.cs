using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Actuators;
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
        //base.CollectObservations(sensor);
        sensor.AddObservation(this.transform.localPosition);
        sensor.AddObservation(Objectif.transform.localPosition);
        foreach (GameObject obs in _obsList)
        {
            sensor.AddObservation(obs.transform.localPosition);
        }

    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        base.OnActionReceived(actions);
        customRewardToGoal();
    }

    public override void OnEpisodeBegin()
    {
        managerAdvanced.resetRun();
    }

    private void customRewardToGoal()
    {
        float distanceToGoal = Vector3.Distance(this.transform.localPosition, Objectif.transform.localPosition);
        //print(1/distanceToGoal * 0.001f);
        AddReward(1 / distanceToGoal * 0.001f);
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
            //SetReward(-1f);
            AddReward(-1f);
            managerAdvanced.FailedTask();
            EndEpisode();
        }

        if (collision.collider.CompareTag("obs"))
        {
  
            //getPunition
            //SetReward(-1f);
            AddReward(-2f);
            managerAdvanced.FailedTask();
            EndEpisode();
        }

    }
}
