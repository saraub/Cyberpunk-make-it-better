using UnityEngine;
using UnityEngine.UI;
public class mouseOver : MonoBehaviour
{
    public GameObject expansionPanel;
    
    public Sprite thisSprite;
    GameObject manager;
    public Button yesBtn;
    
    void Start()
    {
        
        manager = GameObject.FindGameObjectWithTag("Man");
    }
   
   
}
