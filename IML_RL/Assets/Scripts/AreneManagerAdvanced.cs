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


    [SerializeField]
    private List<GameObject> obsList = new List<GameObject>();

    public override void resetRun()
    {
        resetOBS();
        createOBS(nombreObstacle);

        resetAgentPos = new Vector3(Random.Range(-4.4f, 3.3f), 1.5f, Random.Range(-4.4f, 3.4f));
        agent.transform.localPosition = resetAgentPos;

        //new implementation
    }

    private void createOBS(int nbOBS)
    {
        for(int i = 0; i < nbOBS; i++)
        {
            Vector3 obsPos = new Vector3(Random.Range(-8f, 8f), 0.68f, Random.Range(-7f, 8f));
            Quaternion obsRot = Quaternion.Euler(0, Random.Range(0, 360), 0);

            if(checkDistance(obsPos) == false)
            {
                obsPos = new Vector3(Random.Range(-8f, 8f), 0.68f, Random.Range(-7f, 8f));
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
            print(obsList.Count);
        }
    }

}

/*  public void resetRun()
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
