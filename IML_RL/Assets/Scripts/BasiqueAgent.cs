using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class BasiqueAgent : Agent
{

    
    public AreneManager manager;
    private Rigidbody rb;
    [SerializeField]
    private GameObject Objectif;

    public float speed;
    public float jumpForce;

    private float dirX;
    private float dirZ;


    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    public override void OnEpisodeBegin()
    {
        base.OnEpisodeBegin();       
        manager.resetRun();

        /*if(manager.GetType() == typeof(AreneManagerAdvanced))
        {
            AreneManagerAdvanced managerAdvanced = (AreneManagerAdvanced)manager;
            managerAdvanced.resetRun();
            managerAdvanced.SuccesTask();

        }*/
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");

        //jump temp
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }


    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        //base.OnActionReceived(actions);
        dirX = actions.ContinuousActions[0];
        dirZ = actions.ContinuousActions[1];

        moveAgent(dirX,dirZ,0);
    }

    public void moveAgent(float dirX, float dirZ, int jump)
    {
        var movement = new Vector3(dirX, 0, dirZ) * speed * Time.fixedDeltaTime * 10;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //base.CollectObservations(sensor);
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(Objectif.transform.localPosition);

    }

    //Gestion du Reward
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("objectif"))
        {
            //getReward
            SetReward(1f);
            manager.SuccesTask();
            EndEpisode();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("wall"))
        {
            //getPunition
            SetReward(-1f);
            manager.FailedTask();
            EndEpisode();
        }

        if (collision.collider.CompareTag("obs"))
        {
            //getPunition
            SetReward(-1f);
            manager.FailedTask();
            EndEpisode();
        }

    }
}
