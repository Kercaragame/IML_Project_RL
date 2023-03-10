using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AreneManagerAdvanced : AreneManager
{

    [Header("OBSTACLES\n")]
    public GameObject obstacle;
    public int nombreObstacle;
    public float margeBtwObsX;
    public float margeBtwObsZ;
    public float margeToObjectif;
    public float margeToOBS;

    [Header("MODES GENERATED\n")]
    public bool generateOBSOnce;
    public bool isMainArene;
    public bool isSubscribeArene;
    public bool testTraining;


    [Header("TEST ENV")]
    public List<Vector3> posSpawnOBS = new List<Vector3>();
    public List<Quaternion> rotSpawnOBS = new List<Quaternion>();



    [SerializeField]
    private List<GameObject> obsList = new List<GameObject>();
    private Vector3 obsPos;
    private Quaternion obsRot;

    public BasiqueAgentAdvanced agentScript;

    public void initRun()
    {
        if (isMainArene &&  generateOBSOnce)
        {
            resetOBS();
            createOBS(nombreObstacle);

            var arenes = GameObject.FindGameObjectsWithTag("areneManager");
            foreach(GameObject a in arenes)
            {
                var arene = a.GetComponent<AreneManagerAdvanced>();
                if (arene.isSubscribeArene)
                {
                    arene.subscribeOBS(obsList);
                }
            }

        }else if(testTraining && generateOBSOnce)
        {
            generatedObsFromSave(posSpawnOBS,rotSpawnOBS);
        }
    }
    public override void resetRun()
    {
        if (!generateOBSOnce)
        {
            resetOBS();
            createOBS(nombreObstacle);
        }
        setAgentAndGoalPosition();


    }

    private void setAgentAndGoalPosition()
    {

        resetObjectifPos = new Vector3(UnityEngine.Random.Range(-7f, 9f), 1.07f, UnityEngine.Random.Range(-9f, 8f));
        resetAgentPos = new Vector3(UnityEngine.Random.Range(-4.4f, 3.3f), 1.5f, UnityEngine.Random.Range(-4.4f, 3.4f));
        float distance = Vector3.Distance(resetObjectifPos, resetAgentPos);
        float distanceToObs;
        bool isFarObs = false;

        try
        {
            // Call a method that might throw an exception
            while (distance < margeToObjectif || isFarObs == false)
            {
                isFarObs = true;
                resetAgentPos = new Vector3(UnityEngine.Random.Range(-4.4f, 3.3f), 1.5f, UnityEngine.Random.Range(-4.4f, 3.4f));
                foreach (GameObject obs in obsList)
                {
                    if (isFarObs)
                    {
                        distanceToObs = Vector3.Distance(obs.transform.localPosition, resetAgentPos);

                        if (distanceToObs < margeToOBS)
                        {
                            //print("distance to obs : " + distanceToObs);
                            isFarObs = false;
                        }

                    }

                }
                distance = Vector3.Distance(resetObjectifPos, resetAgentPos);
            }
        }
        catch (Exception e)
        {
            print("while crashed : " + e);
            // Catch all exception cases individually
        }


        agent.transform.localPosition = resetAgentPos;
        objectif.transform.localPosition = resetObjectifPos;
    }
    private void Update()
    {
        Debug.DrawLine(objectif.transform.position, agent.transform.position, Color.green);
        foreach(GameObject obs in obsList)
        {
            Debug.DrawLine(obs.transform.position, agent.transform.position, Color.red);
        }
    }

    private void createOBS(int nbOBS)
    {
        for(int i = 0; i < nbOBS; i++)
        {
            obsPos = new Vector3(UnityEngine.Random.Range(-8f, 8f), 2.02f, UnityEngine.Random.Range(-7f, 8f));
            obsRot = Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0);

            if(checkDistance(obsPos) == false)
            {
                i--;
            }
            else
            {
                GameObject myObs = Instantiate(obstacle, this.transform);
                myObs.transform.localPosition = obsPos;
                myObs.transform.rotation = obsRot;
                obsList.Add(myObs);
            }


        }
    }

    private void subscribeOBS(List<GameObject> copyOBS)
    {
        foreach(GameObject obs in copyOBS)
        {
            GameObject myObs = Instantiate(obs, this.transform);
            obsList.Add(myObs);
        }
    }
    private void generatedObsFromSave(List<Vector3> obsPos,List<Quaternion> obsRot)
    {
        int i = 0;
        foreach (Vector3 pos in obsPos)
        {
            Quaternion rot = obsRot[i];
            i++;
            GameObject myObs = Instantiate(obstacle, this.transform);
            myObs.transform.localPosition = pos;
            myObs.transform.rotation = rot;
            obsList.Add(myObs);
        }
    }

    private bool checkDistance(Vector3 my_obs)
    {
        foreach(GameObject obs in obsList)
        {
            float distance_x = Mathf.Abs(my_obs.x - obs.transform.localPosition.x);
            float distance_z = Mathf.Abs(my_obs.z - obs.transform.localPosition.z);

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
        foreach(var obs in obsList)
        {
            obs.SetActive(false);
            Destroy(obs);
        }
        obsList.Clear();
    }

}
