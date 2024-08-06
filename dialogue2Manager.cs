using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class dialogue2Manager : MonoBehaviour
{
    public GameObject goToNextSceneBtn;
    public GameObject answerBtn;
    public GameObject guidePanel;
    public float waitTime;
    public GameObject selectionPanel0;
    public GameObject selectionPanel1;
    public GameObject transitionPanel;

    public TextMeshProUGUI myText;
    public TextMeshProUGUI headDeaprtmetnText;

    string optionA = "This game will be amazing. We are trying hard to create an unique gaming experience that is worth waiting.";
    string optionB = "This game will not be perfect, but we have to sell it.";

    string optionBA = "Just don’t create unrealistic expectations.";
    string optionBB = "Let people see what is great about the game.";
    public GameObject continuesBtn;
    string managerText= "But how can I tell it to people?";
    string beginSentence = "Can you show me the current situation with the game, so that I can correctly inform the fans on social media? You know, I am still kinda trying to learn things.";
    void Start()
    {
        answerBtn.GetComponent<Button>().onClick.AddListener(() => answerBtnFunc(0));
        StartCoroutine(typeBegin());
    }

    IEnumerator waitABitUntilNewSceneBtn()
    {
        yield return new WaitForSeconds(3f);
        goToNextSceneBtn.SetActive(true);
    }
    IEnumerator waitABitUntilOpenPanel(string types, string answeredType)
    {
        yield return new WaitForSeconds(1f);
        if (types == "selection")
        {
            answerBtn.SetActive(false);
            if (answeredType == "0")
            {
                selectionPanel0.SetActive(true);
            }
            if (answeredType == "1")
            {
                selectionPanel1.SetActive(true);
            }
            transitionPanel.SetActive(false);
        }
        if (types == "selectionClose")
        {
            selectionPanel0.SetActive(false);
            selectionPanel1.SetActive(false);
            transitionPanel.SetActive(true);
            if (answeredType == "A")
            {
                StartCoroutine(type("A"));
            }
            if (answeredType == "B")
            {
                StartCoroutine(type("B"));
            }
            if (answeredType == "C")
            {
                StartCoroutine(type("C"));
            }
            if (answeredType == "BA")
            {
                StartCoroutine(type("BA"));
            }
            if (answeredType == "BB")
            {
                StartCoroutine(type("BB"));
            }

        }
       
        if (types == "end")
        {
            continuesBtn.SetActive(false);
            if (answeredType == "end")
            {
                
                transitionPanel.SetActive(false);
                guidePanel.SetActive(true);
                StartCoroutine(waitABitUntilNewSceneBtn());
            }
            if (answeredType == "nonEnd")
            {
                StartCoroutine(managerType());
            }
           
        }

    }
   
    public void answerBtnFunc(int num)
    {
        answerBtn.GetComponent<Button>().enabled = false;
       
        if (num == 0)
        {
            StartCoroutine(waitABitUntilOpenPanel("selection", "0"));
            
            answerBtn.GetComponent<Button>().onClick.RemoveAllListeners();
        }
        if (num == 1)
        {
            StartCoroutine(waitABitUntilOpenPanel("selection", "1"));
           
        }

       
    }
    IEnumerator typeBegin()
    {
        headDeaprtmetnText.text = "";
        for (int i = 0; i < beginSentence.Length; i++)
        {
            headDeaprtmetnText.text += beginSentence[i];
            yield return new WaitForSeconds(waitTime);
            if (i == beginSentence.Length - 1)
            {
                answerBtn.SetActive(true);

            }
        }

    }
    public Button optionABtn;
    public Button optionBBtn;
    public Button optionBABtn;
    public Button optionBBBtn;

    public void goBackToConb(string answeredType)
    {
        optionABtn.enabled = false;
        optionBBtn.enabled = false;
        
        
        if (answeredType == "A")
        {
            StartCoroutine(waitABitUntilOpenPanel( "selectionClose", "A"));
           
            TempStatic.unrealisticExpectation += 2;
            savingScript.instance.Save();
        }
        if (answeredType == "B")
        {
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "B"));
           

        }
    }
    public void goBackToConb1(string answeredType)
    {
       
        optionBABtn.enabled = false;
        optionBBBtn.enabled = false;

        if (answeredType == "BA")
        {
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "BA"));
            TempStatic.unrealisticExpectation += 0;
            savingScript.instance.Save();
           
        }
        if (answeredType == "BB")
        {
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "BB"));
            TempStatic.unrealisticExpectation += 1;
            savingScript.instance.Save();
            
        }

    }
    public void continueBtn(string type)
    {
        continuesBtn.GetComponent<Button>().enabled = false;
        if (type == "end")
        {
            StartCoroutine(waitABitUntilOpenPanel("end", "end"));
            
        }
        if (type == "others")
        {
            StartCoroutine(waitABitUntilOpenPanel("end", "nonEnd"));
            
        }
       
        

    }
    IEnumerator goToNextScene(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
    public void goDialogue3Btn()
    {
        goToNextSceneBtn.GetComponent<Button>().enabled = false;
        StartCoroutine(goToNextScene("dialogue3"));
           
       
       
    }
    IEnumerator type(string type)
    {
        myText.text = "";
        if (type == "A")
        {
            for (int i = 0; i < optionA.Length; i++)
            {
                myText.text += optionA[i];
                yield return new WaitForSeconds(waitTime);
                if (i == optionA.Length - 1)
                {
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                    continuesBtn.GetComponent<Button>().onClick.RemoveAllListeners();
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("end"));
                }
            }

        }
        if (type == "B")
        {
            for (int i = 0; i < optionB.Length; i++)
            {
                myText.text += optionB[i];
                yield return new WaitForSeconds(waitTime);
                if (i == optionB.Length - 1)
                {
                    headDeaprtmetnText.text = "...";
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                    continuesBtn.GetComponent<Button>().onClick.RemoveAllListeners();
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("others"));
                }
            }

        }
        if (type == "BA")
        {
            for (int i = 0; i < optionBA.Length; i++)
            {
                myText.text += optionBA[i];
                yield return new WaitForSeconds(waitTime);
                if (i == optionBA.Length - 1)
                {
                    headDeaprtmetnText.text = "...";
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                    continuesBtn.GetComponent<Button>().onClick.RemoveAllListeners();
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("end"));

                }
            }

        }
        if (type == "BB")
        {
            for (int i = 0; i < optionBB.Length; i++)
            {
                myText.text += optionBB[i];
                yield return new WaitForSeconds(waitTime);
                if (i == optionBB.Length - 1)
                {
                    headDeaprtmetnText.text = "...";
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                    continuesBtn.GetComponent<Button>().onClick.RemoveAllListeners();
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("end"));

                }
            }

        }

    }
    IEnumerator managerType()
    {
        headDeaprtmetnText.text = "";
       
            for (int i = 0; i < managerText.Length; i++)
            {
                headDeaprtmetnText.text += managerText[i];
                yield return new WaitForSeconds(waitTime);
                if (i == managerText.Length - 1)
                {
                    myText.text = "...";
                    answerBtn.SetActive(true);
                    answerBtn.GetComponent<Button>().enabled = true;
                    answerBtn.GetComponent<Button>().onClick.AddListener(() => answerBtnFunc(1));


                }
            }

        
       

    }
}
