using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class skillSelectionManager : MonoBehaviour
{
    public GameObject attentionPanel;
    int hireCounter;
    public GameObject goToNextSceneBtn;
    public GameObject guidePanelToDialogue ;
    public Image expansionSprite;
    public List<Sprite> sprites = new List<Sprite>();
    
    public GameObject expansionPanel;
    public int totalUsedBudget=12000;
   
    public TextMeshProUGUI currentBudgetText;
    public Button yesBtn;
    public Button noBtn;
    public List<GameObject> cards = new List<GameObject>();
    public List<GameObject> cardsListToRemove = new List<GameObject>();
   
    bool checkIfMoreThanTwo()
    {
        if (hireCounter >= 2)
        {
            return true;
        }
        else
        {
            attentionPanel.SetActive(true);
            return false;
        }
    }
    public void goDialogues()
    {
        goToNextSceneBtn.GetComponent<Button>().enabled = false;
        StartCoroutine(goToNextScene("dialogue0"));
       
    }
    IEnumerator goToNextScene(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
    void Update()
    {
        if (attentionPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                attentionPanel.SetActive(false);
            }
        }
        currentBudgetText.text = totalUsedBudget + "$";
        
    }
    IEnumerator waitABitUntilNewSceneBtn()
    {
        yield return new WaitForSeconds(3f);
        goToNextSceneBtn.SetActive(true);
    }
    public void freezeAllCards()
    {
       
        foreach (GameObject g in cards)
        {
            g.GetComponent<Button>().interactable = false;
        }
    }
    IEnumerator waitABitUntilOpenPanel(string type)
    {
        yield return new WaitForSeconds(1f);
        if (type == "expansion")
        {
            expansionPanel.SetActive(true);
        }
        if (type == "expansionClose")
        {
            expansionPanel.SetActive(false);
            yesBtn.enabled = true;
            noBtn.enabled = true;
        }
        if (type == "end")
        {
           
                guidePanelToDialogue.SetActive(true);
                StartCoroutine(waitABitUntilNewSceneBtn());
            
           
        }
       
    }
    
    public void hideCards(int type)
    {
        if (type == 0)
        {
            foreach(GameObject g in cardsListToRemove)
            {
                g.GetComponent<Button>().interactable = false;
            }
        }
        if (type == 4499)
        {


           

        }
        if (type == 3999)
        {
            

            cards[2].GetComponent<Button>().interactable = false;

            cards[4].GetComponent<Button>().interactable = false;

            cards[8].GetComponent<Button>().interactable = false;

        }
        if (type == 3499)
        {
            cards[0].GetComponent<Button>().interactable = false;
            
            cards[2].GetComponent<Button>().interactable = false;

            cards[4].GetComponent<Button>().interactable = false;
            
            cards[8].GetComponent<Button>().interactable = false;

        }
        if (type == 2999)
        {
            cards[0].GetComponent<Button>().interactable = false;
            cards[1].GetComponent<Button>().interactable = false;
            cards[2].GetComponent<Button>().interactable = false;
            
            cards[4].GetComponent<Button>().interactable = false;
            cards[6].GetComponent<Button>().interactable = false;
            cards[7].GetComponent<Button>().interactable = false;
            cards[8].GetComponent<Button>().interactable = false;

        }
        if (type == 2499)
        {
            cards[0].GetComponent<Button>().interactable = false;
            cards[1].GetComponent<Button>().interactable = false;
            cards[2].GetComponent<Button>().interactable = false;
            cards[3].GetComponent<Button>().interactable = false;
            cards[4].GetComponent<Button>().interactable = false;
            cards[6].GetComponent<Button>().interactable = false;
            cards[7].GetComponent<Button>().interactable = false;
            cards[8].GetComponent<Button>().interactable = false;
            

        }
        
        if (type == 1999)
        {
            cards[0].GetComponent<Button>().interactable = false;
            cards[1].GetComponent<Button>().interactable = false;
            cards[2].GetComponent<Button>().interactable = false;
            cards[3].GetComponent<Button>().interactable = false;
            cards[4].GetComponent<Button>().interactable = false;
            cards[6].GetComponent<Button>().interactable = false;
            cards[7].GetComponent<Button>().interactable = false;
            cards[8].GetComponent<Button>().interactable = false;
            cards[9].GetComponent<Button>().interactable = false;

        }

        if (type == 1499)
        {
            cards[0].GetComponent<Button>().interactable = false;
            cards[1].GetComponent<Button>().interactable = false;
            cards[2].GetComponent<Button>().interactable = false;
            cards[3].GetComponent<Button>().interactable = false;
            cards[4].GetComponent<Button>().interactable = false;
            cards[5].GetComponent<Button>().interactable = false;
            cards[6].GetComponent<Button>().interactable = false;
            cards[7].GetComponent<Button>().interactable = false;
            cards[8].GetComponent<Button>().interactable = false;
            cards[9].GetComponent<Button>().interactable = false;
        }
        
       
    }
    public void enableAllCards()
    {
        foreach (GameObject g in cards)
        {
            g.GetComponent<Button>().interactable = false;
        }
        foreach (GameObject g in cardsListToRemove)
        {
            g.GetComponent<Button>().interactable = true;
          
        
        }
       
        yesBtn.onClick.RemoveAllListeners();
        noBtn.onClick.RemoveAllListeners();
        if (totalUsedBudget < 1500)
        {
            hideCards(1499);
        }
       
        else if (totalUsedBudget <2000)
        {

            hideCards(1999);
        }
        else if (totalUsedBudget < 2500)
        {
            hideCards(2499);
        }
        else if (totalUsedBudget < 3000)
        {

            hideCards(2999);
        }
        else if (totalUsedBudget < 3500)
        {

            hideCards(3499);
        }
        else if (totalUsedBudget < 4000)
        {

            hideCards(3999);
        }
       
        else
        {
            //show everything
        }

    }
    
    public void butnFunc(int num)
    {
        freezeAllCards();
        
        StartCoroutine(waitABitUntilOpenPanel("expansion"));
        
        expansionSprite.sprite = sprites[num];

        yesBtn.onClick.AddListener(() => addBtnFunc(num));
        noBtn.onClick.AddListener(() => noBtnFunc());
    }
    public void continueBtnFunc()
    {
        if (TempStatic.gameArtP >= 10)
        {
            TempStatic.gameArt = "amazing";
            TempStatic.bigPoint += 3;
        }
        else if (TempStatic.gameArtP >= 7)
        {
            TempStatic.gameArt = "good";
            TempStatic.bigPoint += 2;
        }
        else if (TempStatic.gameArtP >= 5)
        {
            TempStatic.gameArt = "ok";
            TempStatic.bigPoint += 1;
        }
        else
        {
            TempStatic.gameArt = "poor";
            TempStatic.bigPoint += 0;
        }
        if (TempStatic.programmingP >= 10)
        {
            TempStatic.programming = "amazing";
            TempStatic.bigPoint += 3;
        }
        else if (TempStatic.programmingP >= 7)
        {
            TempStatic.programming = "good";
            TempStatic.bigPoint += 2;
        }
        else if (TempStatic.programmingP >= 5)
        {
            TempStatic.programming = "ok";
            TempStatic.bigPoint += 1;
        }
        else
        {
            TempStatic.programming = "poor";
            TempStatic.bigPoint += 0;
        }
        if (TempStatic.narrativeWritingP >= 10)
        {
            TempStatic.narrativeWriting = "amazing";
            TempStatic.bigPoint += 3;
        }
        else if (TempStatic.narrativeWritingP >= 7)
        {
            TempStatic.narrativeWriting = "good";
            TempStatic.bigPoint += 2;
        }
        else if (TempStatic.narrativeWritingP >= 5)
        {
            TempStatic.narrativeWriting = "ok";
            TempStatic.bigPoint += 1;
        }
        else
        {
            TempStatic.narrativeWriting = "poor";
            TempStatic.bigPoint += 0;
        }
        savingScript.instance.Save();

        if (checkIfMoreThanTwo())
        {
            hideCards(0);
            
            StartCoroutine(waitABitUntilOpenPanel("end"));
           
        }
           
        
        
       
    }
    public void addBtnFunc(int num)
    {
       
        if (num == 0)
        {
            TempStatic.gameArtP += 2;
            TempStatic.programmingP += 0;
            TempStatic.narrativeWritingP += 4;
           
            
                totalUsedBudget -= 3500;

                cards[0].transform.GetChild(0).gameObject.SetActive(true);
                
                cardsListToRemove.Remove(cards[0]);
            
            
        }
        else if (num == 1)
        {
            TempStatic.gameArtP += 1;
            TempStatic.programmingP += 4;
            TempStatic.narrativeWritingP += 0;

           
                totalUsedBudget -= 3000;

                cards[1].transform.GetChild(0).gameObject.SetActive(true);
                cardsListToRemove.Remove(cards[1]);
            
        }
        else if (num == 2)
        {
            TempStatic.gameArtP += 1;
            TempStatic.programmingP += 4;
            TempStatic.narrativeWritingP += 2;


          
                totalUsedBudget -= 3500;

                cards[2].transform.GetChild(0).gameObject.SetActive(true);
                cardsListToRemove.Remove(cards[2]);
            
        }
        else if (num == 3)
        {
            TempStatic.gameArtP += 0;
            TempStatic.programmingP += 1;
            TempStatic.narrativeWritingP += 3;


           
                totalUsedBudget -= 2500;

                cards[3].transform.GetChild(0).gameObject.SetActive(true);
                cardsListToRemove.Remove(cards[3]);
            
        }
        else if (num == 4)
        {
            TempStatic.gameArtP += 4;
            TempStatic.programmingP += 0;
            TempStatic.narrativeWritingP += 3;


           
                totalUsedBudget -= 4000;

                cards[4].transform.GetChild(0).gameObject.SetActive(true);
                cardsListToRemove.Remove(cards[4]);
            
        }
        else if (num == 5)
        {
            TempStatic.gameArtP += 1;
            TempStatic.programmingP += 0;
            TempStatic.narrativeWritingP += 0;


           
                totalUsedBudget -= 1500;

                cards[5].transform.GetChild(0).gameObject.SetActive(true);
                cardsListToRemove.Remove(cards[5]);
            
        }
        else if (num == 6)
        {
            TempStatic.gameArtP += 2;
            TempStatic.programmingP += 2;
            TempStatic.narrativeWritingP += 1;


            
                totalUsedBudget -= 3000;

                cards[6].transform.GetChild(0).gameObject.SetActive(true);
                cardsListToRemove.Remove(cards[6]);
            
        }
        else if (num == 7)
        {
            TempStatic.gameArtP += 0;
            TempStatic.programmingP += 3;
            TempStatic.narrativeWritingP += 2;


           
                totalUsedBudget -= 3000;

                cards[7].transform.GetChild(0).gameObject.SetActive(true);
                cardsListToRemove.Remove(cards[7]);
            
        }
        else if (num == 8)
        {
            TempStatic.gameArtP += 3;
            TempStatic.programmingP += 2;
            TempStatic.narrativeWritingP += 2;


           
                totalUsedBudget -= 4000;

                cards[8].transform.GetChild(0).gameObject.SetActive(true);
                cardsListToRemove.Remove(cards[8]);
            
        }
        else if (num == 9)
        {
            TempStatic.gameArtP += 2;
            TempStatic.programmingP += 0;
            TempStatic.narrativeWritingP += 1;


           
                totalUsedBudget -= 2000;

                cards[9].transform.GetChild(0).gameObject.SetActive(true);
                cardsListToRemove.Remove(cards[9]);

            
        }
       
        hireCounter++;
        noBtnFunc();


    }
    public void noBtnFunc()
    {
        yesBtn.enabled = false;
        noBtn.enabled = false;
        StartCoroutine(waitABitUntilOpenPanel("expansionClose"));
        
        enableAllCards();
        
    }
   

}
