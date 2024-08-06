using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class menuManager : MonoBehaviour
{

    public GameObject resetConfirmPanel;

    public GameObject startConfirmPanel;
   
    IEnumerator goToNextScene(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

 
    public void yesBtnFUnc()
    {
        yesBtn.enabled = false;
        noBtn.enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("answerYes"));
       
    }
    public void noBtnFunc()
    {
        yesBtn.enabled = false;
        noBtn.enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("answerNo"));
    }
    
    public GameObject realPlayBtn;
    public void playBtnFunc()
    {
        resetStuff();
        playBtn.GetComponent<Button>().enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("start"));
           

        
    }
    public Button yesBtn;
    public Button noBtn;
    public void realPlayBtnFunc()
    {
        realPlayBtn.GetComponent<Button>().enabled = false;
        StartCoroutine(goToNextScene("skillSelection"));
    }
    public void reserBtnFunc()
    {
        resetBtn.GetComponent<Button>().enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("reset"));
    }
    public GameObject playBtn;
    public GameObject resetBtn;

    void resetStuff()
    {

        savingScript.instance.DeleteData();

        resetConfirmPanel.SetActive(false);
        resetBtn.GetComponent<Button>().enabled = true;
        yesBtn.enabled = true;
        noBtn.enabled = true;
    }

    IEnumerator waitABitUntilOpenPanel(string types)
    {
        yield return new WaitForSeconds(1f);
        if (types == "reset")
        {
            resetConfirmPanel.SetActive(true);
        }
        if (types == "start")
        {
            startConfirmPanel.SetActive(true);
        }
        if (types == "answerNo")
        {
            resetConfirmPanel.SetActive(false);
            resetBtn.GetComponent<Button>().enabled = true;
            yesBtn.enabled = true;
            noBtn.enabled = true;
        }
        if (types == "answerYes")
        {
            resetStuff();
        }
    }
}
