using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RoadBuilder : MonoBehaviour
{
    //* to gameManager
    
    public GameObject home;
    public  GameObject target;

    public Vector3 addPos;
    public bool areRoadsCompleted;
    public GameObject roads;
    public LineRenderer lr;
    
    private int roadIndex=0;
    public LineRenderer roadTemplate;
    LineRenderer roadToBuild;

    //We are going to deal with it by using instantia method. we need to make roads prefabs that includes their own line renderer. 

    void Start()
    {        
        roadToBuild = roadTemplate;
    }
    public void BuildRoads()
    {
             //The vehicle will be placed on a road. So each road need a mainTarget and 
        if(!PairChecker(target.GetComponent<OnMouseDownS>().pairs, home))
        {
            lr.SetPosition(0, home.transform.position);
            lr.GetComponent<Road>().home=home;
            lr.SetPosition(1, target.transform.position);
            lr.GetComponent<Road>().target=target;
            AttachPairs();
            CreateNewLiner();
        }
    }
    void CreateNewLiner()
    {
        Instantiate(roadToBuild, Vector3.zero, Quaternion.identity);
        lr=roadTemplate;
    }

    void AttachPairs()
    {
        home.GetComponent<OnMouseDownS>().pairs[home.GetComponent<OnMouseDownS>().pairIndex]=target;
        target.GetComponent<OnMouseDownS>().pairs[target.GetComponent<OnMouseDownS>().pairIndex]=home;
        
        home.GetComponent<OnMouseDownS>().pairIndex++;
        target.GetComponent<OnMouseDownS>().pairIndex++;
    }

    bool PairChecker(GameObject[] _pairs, GameObject goToCheckPair)
    {
        foreach(GameObject gobj in _pairs)
        {
            if(gobj== goToCheckPair)
            {
                Debug.Log("You can not build another road in between these nodes.");
                return true;
            }
        }
        return false;
    }
}
