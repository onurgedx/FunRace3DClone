using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaController : MonoBehaviour
{


    public bool touch2Run;



    public static bool _alive;
    public static float _speed;

    protected Animator animator;

    protected Vector3 refPos;

    protected GameObject Blow;


    public virtual void Awake()
    {
        _alive = true;
        _speed = 10f;

    }

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        refPos = transform.position;

        Blow = transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    protected virtual void Update()
    {

        if(alive && Canvassal.countdown)
        {

            if(runAcces )
            {

                transform.position += transform.forward*Time.deltaTime*speed;
                animator.SetBool("run", true);

            }
            else
            {
                animator.SetBool("run", false);

            }


        }


        
    }


    protected virtual bool runAcces
    {
        get
        {
            return Input.touchCount > 0 || touch2Run;
        }
    }

    protected virtual bool alive
    {
        get
        {
            return _alive;
        }
        set
        {
            _alive = value;
        }
    }

    protected virtual float speed
    {
        get
        {
            return _speed;

        }

        set
        {
            _speed = value;
        }


    }


    protected virtual IEnumerator Rearkarnasyon()
    {
        yield return new WaitForSeconds(2f);
        Refresh();

    }

    protected virtual void Refresh()
    {   
        animator.SetBool("dead", false);
        transform.position = refPos;
        setAliveTrue();
        


    }


    protected virtual void finishIt()
    {
        Debug.Log("you win");
        Canvassal.countdown = false;

        StartCoroutine(Canvassal.YouWin());

    }

    protected virtual void deadPls()
    {   
        Debug.Log("dead");
        setAliveFalse();
        AnimDead();
        Blow.GetComponent<ParticleSystem>().Play();
        StartCoroutine(Rearkarnasyon());
        

    }

    

    
    protected virtual void setAliveFalse()
    {
        alive = false;
    }
    protected virtual void setAliveTrue()
    {
        alive = true;
    }

    protected virtual void AnimDead()
    {
        animator.SetBool("run", false);
        animator.SetBool("dead", true);

    }



    protected virtual void OnCollisionEnter(Collision coll)
    {

        Debug.Log(coll.gameObject.name);

        if(coll.gameObject.tag=="deadpls")
        {
            deadPls();
        }

        if(coll.gameObject.tag=="Finish")
        {
            
            finishIt();


        }


        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("checkpoint"))
        {
            refPos = transform.position;

        }
        
    }









}
