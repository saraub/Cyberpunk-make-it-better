using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class dialogue4Manager : MonoBehaviour
{
    public GameObject goToNextSceneBtn;
    public GameObject answerBtn;
    public GameObject guidePanel;
    public float waitTime;
    public GameObject selectionPanel0;
    public GameObject selectionPanel1;
    public GameObject selectionPanel2;
    public GameObject transitionPanel;

    public TextMeshProUGUI myText;
    public TextMeshProUGUI headDeaprtmetnText;
    string endSentence0 = "I would be very excited to have your new game in our shop. Please, fill this application form and send it to me, I will contact you in order to discuss further details.";
    string endSentence1 = "I see. Thank you for your time, I will discuss it with my co-workers and I will let you know when we decide to include your game in our inventory.";
    string optionA = "This is how it looks.";
    string optionB = "As you see, this game looks amazing. People will love the story and all unique features. Everybody has been waiting for such an immersive gaming experience.";

    string optionAA = "We hope to get it finished before the release.";
    string optionAB = "I’m sure people will love this game. We have learned a lot from our last game and made some improvements.";

    string optionAAA = "The developers are working on a tight schedule. Some features probably will be added with later updates, so that we don’t have to change the release date.";
    string optionAAB = "We will soon start a big marketing campaign. If we manage to keep our release date without delays, we would keep people interested until they can actually play the game.";

    public GameObject continuesBtn;
    string managerText = "What do you mean?";
    string beginSentence = "Hey. Thanks for the appointment. How is it going with the game? Can you show me some stuff? I am very interested!";
    void Start()
    {
        answerBtn.GetComponent<Button>().onClick.AddListener(() => answerBtnFunc(0));
        TempStatic.hasGotFakeMaterial = true;
        if (TempStatic.hasGotFakeMaterial)
        {
            optionBBtn.gameObject.SetActive(true);
        }
        else
        {
            optionBBtn.gameObject.SetActive(false);
        }
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
            if (answeredType == "2")
            {
                selectionPanel2.SetActive(true);
            }
            transitionPanel.SetActive(false);
        }
        if (types == "selectionClose")
        {
            selectionPanel0.SetActive(false);
            selectionPanel1.SetActive(false);
            selectionPanel2.SetActive(false);
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
            if (answeredType == "AA")
            {
                StartCoroutine(type("AA"));
            }
            if (answeredType == "AB")
            {
                StartCoroutine(type("AB"));
            }
            if (answeredType == "AAA")
            {
                StartCoroutine(type("AAA"));
            }
            if (answeredType == "AAB")
            {
                StartCoroutine(type("AAB"));
            }

        }

        if (types == "end")
        {
            continuesBtn.SetActive(false);
            if (answeredType == "end")
            {

                guidePanel.SetActive(true);
                StartCoroutine(waitABitUntilNewSceneBtn());
                transitionPanel.SetActive(false);
            }
            if (answeredType == "second")
            {
                selectionPanel1.SetActive(true);
                transitionPanel.SetActive(false);
            }
            if (answeredType == "normal")
            {
                StartCoroutine(managerType("normal"));
            }

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
                answerBtn.GetComponent<Button>().enabled = true;
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
            StartCoroutine(waitABitUntilOpenPanel("selection", "2"));
            
        }
        

       
    }
    public Button optionABtn;
    public Button optionBBtn;
    public Button optionAABtn;
    public Button optionABBtn;
    public Button optionAAABtn;
    public Button optionAABBtn;
    public void goBackToConb(string answeredType)
    {
        optionABtn.enabled = false;
        optionBBtn.enabled = false;
        
        if (answeredType == "A")
        { 
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "A"));
            
            
        }
        if (answeredType == "B")
        {
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "B"));
            
            TempStatic.unrealisticExpectation += 3;
            savingScript.instance.Save();
        }
    }
    public void goBackToConb1(string answeredType)
    {
        
        optionAABtn.enabled = false;
        optionABBtn.enabled = false;
        

        if (answeredType == "AA")
        {
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "AA"));
           
        }
        if (answeredType == "AB")
        {
            TempStatic.unrealisticExpectation += 1;
            savingScript.instance.Save();
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "AB"));
        }

    }
    public void goBackToConb2(string answeredType)
    {
      
        optionAAABtn.enabled = false;
        optionAABBtn.enabled = false;

        if (answeredType == "AAA")
        {
            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "AAA"));
            TempStatic.unrealisticExpectation += 0;
            TempStatic.isAAA = true;
            savingScript.instance.Save();
            
            
        }
        if (answeredType == "AAB")
        {
            TempStatic.unrealisticExpectation += 0;


            StartCoroutine(waitABitUntilOpenPanel("selectionClose", "AAB"));
        }

    }
    public void continueBtn(string type)
    {
        continuesBtn.GetComponent<Button>().enabled = false;
        if (type == "second")
        {
            StartCoroutine(waitABitUntilOpenPanel("end", "second"));
           
        }
        else if (type == "third")
        {
           
            StartCoroutine(waitABitUntilOpenPanel("end", "normal"));
        }
        else
        {
            StartCoroutine(waitABitUntilOpenPanel("end", "end"));
            
        }

       

    }
    public void goDialogue5Btn()
    {

        goToNextSceneBtn.GetComponent<Button>().enabled = false;
        StartCoroutine(goToNextScene("text"));
       
      
    }
    IEnumerator goToNextScene(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
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
                    headDeaprtmetnText.text = "...";
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                    continuesBtn.GetComponent<Button>().onClick.RemoveAllListeners();
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("second"));
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

                    StartCoroutine(managerType("end0"));
                }
            }

        }
        if (type == "AA")
        {
            for (int i = 0; i < optionAA.Length; i++)
            {
                myText.text += optionAA[i];
                yield return new WaitForSeconds(waitTime);
                if (i == optionAA.Length - 1)
                {
                    headDeaprtmetnText.text = "...";
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                    continuesBtn.GetComponent<Button>().onClick.RemoveAllListeners();
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("third"));
                }
            }

        }
        if (type == "AB")
        {
            for (int i = 0; i < optionAB.Length; i++)
            {
                myText.text += optionAB[i];
                yield return new WaitForSeconds(waitTime);
                if (i == optionAB.Length - 1)
                {
                    headDeaprtmetnText.text = "...";
                    StartCoroutine(managerType("end0"));
                }
            }

        }
        if (type == "AAA")
        {
            for (int i = 0; i < optionAAA.Length; i++)
            {
                myText.text += optionAAA[i];
                yield return new WaitForSeconds(waitTime);
                if (i == optionAAA.Length - 1)
                {
                    headDeaprtmetnText.text = "...";
                    StartCoroutine(managerType("end1"));
                }
            }

        }
        if (type == "AAB")
        {
            for (int i = 0; i < optionAAB.Length; i++)
            {
                myText.text += optionAAB[i];
                yield return new WaitForSeconds(waitTime);
                if (i == optionAAB.Length - 1)
                {
                    headDeaprtmetnText.text = "...";
                    StartCoroutine(managerType("end0"));
                }
            }

        }

    }
    IEnumerator managerType(string type)
    {
        headDeaprtmetnText.text = "";
        if (type == "normal")
        {
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
        if (type == "end0")
        {
            for (int i = 0; i < endSentence0.Length; i++)
            {
                headDeaprtmetnText.text += endSentence0[i];
                yield return new WaitForSeconds(waitTime);
                if (i == endSentence0.Length - 1)
                {
                    myText.text = "...";
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                    continuesBtn.GetComponent<Button>().onClick.RemoveAllListeners();
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("end"));


                }
            }
        }
        if (type == "end1")
        {
            for (int i = 0; i < endSentence1.Length; i++)
            {
                headDeaprtmetnText.text += endSentence1[i];
                yield return new WaitForSeconds(waitTime);
                if (i == endSentence1.Length - 1)
                {
                    myText.text = "...";
                    continuesBtn.SetActive(true);
                    continuesBtn.GetComponent<Button>().enabled = true;
                    continuesBtn.GetComponent<Button>().onClick.RemoveAllListeners();
                    continuesBtn.GetComponent<Button>().onClick.AddListener(() => continueBtn("end"));


                }
            }
        }





    }
}
