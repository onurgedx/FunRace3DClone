using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalController : ChaController
{
    public static bool alive2;
    private float speed2;

    public override void Awake()
    {

        alive2 = true;
        speed2 = 5f;

    }
    protected override bool alive
    {
        get
        {
            return alive2;
        }
        set
        {
            alive2 = value;
        }
    }

    protected override bool runAcces
    {
        get
        {
            return GoBro();
        }
    }

    private bool GoBro()
    {   
        RaycastHit hit;

        if (Physics.Raycast(transform.position+Vector3.up, Vector3.forward, out hit,Mathf.Infinity))
        {
            //Debug.Log(hit.distance);
            
            if(hit.distance>2 || hit.collider.gameObject.tag=="Finish" || hit.collider.gameObject.tag == "checkpoint")
            { return true; }
            else { return false; }
        }


        return true;

    }

    
    protected override void finishIt()
    {

        Debug.Log("you lost");
        StartCoroutine(Canvassal.YouLost());

        
    }
    
    


    protected override float speed
    {
        get

        {
            return speed2;

        }

        set
        {
            speed2 = value;
        }


    }

}
