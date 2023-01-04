using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreneManagerAdvanced : AreneManager
{

    [Header("OBSTACLES\n")]
    public GameObject obstacle;
    public int nombreObstacle;
    public float margeBtwObsX;
    public float margeBtwObsZ;
    public float margeToObjectif;

    [SerializeField]
    private List<GameObject> obsList = new List<GameObject>();

    public BasiqueAgentAdvanced agentScript;

    public override void resetRun()
    {
        resetOBS();
        createOBS(nombreObstacle);
        agentScript.setObs(obsList);
        setAgentAndGoalPosition();

    }

    private void setAgentAndGoalPosition()
    {

        resetObjectifPos = new Vector3(Random.Range(-7f, 9f), 1.07f, Random.Range(-9f, 8f));
        resetAgentPos = new Vector3(Random.Range(-4.4f, 3.3f), 1.5f, Random.Range(-4.4f, 3.4f));
        float distance = Vector3.Distance(resetObjectifPos, resetAgentPos);


        while (distance < margeToObjectif)
        {
            resetAgentPos = new Vector3(Random.Range(-4.4f, 3.3f), 1.5f, Random.Range(-4.4f, 3.4f));
            distance = Vector3.Distance(resetObjectifPos, resetAgentPos);
        }

        agent.transform.localPosition = resetAgentPos;
        objectif.transform.localPosition = resetObjectifPos;
    }
    private void Update()
    {
        float distance = Vector3.Distance(objectif.transform.position, agent.transform.position);
        Debug.DrawLine(objectif.transform.position, agent.transform.position, Color.green);
    }

    private void createOBS(int nbOBS)
    {
        for(int i = 0; i < nbOBS; i++)
        {
            Vector3 obsPos = new Vector3(Random.Range(-8f, 8f), 2.02f, Random.Range(-7f, 8f));
            Quaternion obsRot = Quaternion.Euler(0, Random.Range(0, 360), 0);

            if(checkDistance(obsPos) == false)
            {
                obsPos = new Vector3(Random.Range(-8f, 8f), 2.02f, Random.Range(-7f, 8f));
                obsRot = Quaternion.Euler(0, Random.Range(0, 360), 0);
                i--;
            }
            else
            {
                GameObject myObs = Instantiate(obstacle, obsPos, obsRot);
                myObs.transform.SetParent(this.transform);
                obsList.Add(myObs);
            }


        }
    }
   
    private bool checkDistance(Vector3 my_obs)
    {
        foreach(GameObject obs in obsList)
        {
            float distance_x = Mathf.Abs(my_obs.x - obs.transform.position.x);
            float distance_z = Mathf.Abs(my_obs.z - obs.transform.position.z);

            if (Mathf.Abs(distance_x) < margeBtwObsX)
            {
                return false;
            }
            if (Mathf.Abs(distance_z) < margeBtwObsZ)
            {
                return false;
            }

        }
        return true;
    }

    private void resetOBS()
    {

        for(int i=0;i < obsList.Count; i=0)
        {
            GameObject obs = obsList[i];
            obsList.RemoveAt(i);
            Destroy(obs);
        }
    }

}

/*
 int minSpawnHealth = 10;
 int maxSpawnHealth = 30;
 int stepSize = 5;
 
 int GetRandomHealth () {
     int randomHealth = Random.Range(minSpawnHealth, maxSpawnHealth);
     int numSteps = Mathf.Floor (randomHealth / stepSize);
     int adjustedHealth = numSteps * stepSize;
 
     return adjustedHealth;
 }
}*/
