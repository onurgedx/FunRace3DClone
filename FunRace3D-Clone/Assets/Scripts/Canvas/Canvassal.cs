using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Canvassal : MonoBehaviour
{


    public static GameObject retry;

    private static GameObject text;
    private static Text textT;
    public static bool countdown;
    
    
    

    private void Awake()
    {
        text = GameObject.Find("Text");
        textT = text.GetComponent<Text>();
        retry = GameObject.Find("Retry");
    }
    void Start()
    {
       

        StartCoroutine(CountDown2Go());
        
    }

    // Update is called once per frame
    void Update()
    {   
        
    }


    
    public static IEnumerator YouWin()
    {


        text.GetComponent<Text>().text = "Won";
        text.GetComponent<Text>().CrossFadeAlpha(1, 1, false);
        int a = 30;
        textT.fontSize += a;
        
        while(a>0)
        {
            textT.fontSize -= 1;
            a--;
            yield return new WaitForSeconds(Time.deltaTime*5);
            
        }

        while (retry.GetComponent<CanvasGroup>().alpha < 0.99f)
        {
            retry.GetComponent<CanvasGroup>().alpha += Time.deltaTime * 5;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        retry.GetComponent<CanvasGroup>().interactable = true;





    }

    public static IEnumerator YouLost()
    {


        countdown = false;
        text.GetComponent<Text>().text = "Lost";
        text.GetComponent<Text>().CrossFadeAlpha(1, 1, false);


        int a = 30;
        textT.fontSize += a;

        while (a > 0)
        {
            textT.fontSize -= 1;
            a--;
            yield return new WaitForSeconds(Time.deltaTime * 2);

        }

        
        while(retry.GetComponent<CanvasGroup>().alpha<0.99f)
        {
            retry.GetComponent<CanvasGroup>().alpha += Time.deltaTime*5;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        retry.GetComponent<CanvasGroup>().interactable = true;



    }

    public IEnumerator CountDown2Go()
    {


        textT.text = "3";


        yield return new WaitForSeconds(1f);
        textT.text = "2";

        yield return new WaitForSeconds(1f);
        textT.text = "1";

        yield return new WaitForSeconds(1f);
        textT.text = "Go!!!";
        countdown = true;
        text.GetComponent<Text>().CrossFadeAlpha(0, 1.5f, false);
        int fontsize = textT.fontSize;
        
        while(textT.fontSize>0)
        {
            
            yield return new WaitForSeconds(Time.deltaTime);
            textT.fontSize--;


        }
        textT.fontSize = fontsize;

        /*
        yield return new WaitForSeconds(0.2f);
        text.GetComponent<Text>().text = "Go!!!";
        yield return new WaitForSeconds(0.2f);
        text.GetComponent<Text>().text = "Go!!";
        yield return new WaitForSeconds(0.2f);
        text.GetComponent<Text>().text = "Go!";
        yield return new WaitForSeconds(0.2f);
        text.GetComponent<Text>().text = "Go";
        */

        // bu kod alpha degerini istedigimiz sürede istedigimiz degere getiriyor
        // bunun  color hali de var mutus bir sey 
        // text.GetComponent<Text>().CrossFadeAlpha(0, 1, false);
        
        // bu assagidakini yapacaktim az kalsin CrossFadeAlpha yi buldum sukurler olsun 
        /*
        while(text.GetComponent<Text>().color.a!=0)
        {
           
            yield return new WaitForSeconds(Time.deltaTime);
        }
        */



    }



    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
