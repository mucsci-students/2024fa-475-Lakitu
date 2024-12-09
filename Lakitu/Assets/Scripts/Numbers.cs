using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numbers : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 nonactive;
    public Vector3 active;

    public int num;

    public GameObject Top;
    public GameObject TopLeft;
    public GameObject TopRight;
    public GameObject Mid;
    public GameObject BotLeft;
    public GameObject BotRight;
    public GameObject Bot;
    void Start()
    {
        nonactive = new Vector3(0f, 0f, 0f);
        active = new Vector3(.25f, .5f, .05f);

        Top         = this.gameObject.transform.GetChild(0).gameObject;
        TopLeft     = this.gameObject.transform.GetChild(1).gameObject;
        TopRight    = this.gameObject.transform.GetChild(2).gameObject;
        Mid         = this.gameObject.transform.GetChild(3).gameObject;
        BotLeft     = this.gameObject.transform.GetChild(4).gameObject;
        BotRight    = this.gameObject.transform.GetChild(5).gameObject;
        Bot         = this.gameObject.transform.GetChild(6).gameObject;
        

    }

    // Update is called once per frame
    void Update()
    {
        if(num == 0){
            Top.transform.localScale = active;
            TopLeft.transform.localScale = active;
            TopRight.transform.localScale = active;
            Mid.transform.localScale = nonactive;
            BotLeft.transform.localScale = active;
            BotRight.transform.localScale = active;
            Bot.transform.localScale = active;
        }

        else if(num == 1){
            Top.transform.localScale = nonactive;
            TopLeft.transform.localScale = nonactive;
            TopRight.transform.localScale = active;
            Mid.transform.localScale = nonactive;
            BotLeft.transform.localScale = nonactive;
            BotRight.transform.localScale = active;
            Bot.transform.localScale = nonactive;
        }

        else if(num == 2){
            Top.transform.localScale = active;
            TopLeft.transform.localScale = nonactive;
            TopRight.transform.localScale = active;
            Mid.transform.localScale = active;
            BotLeft.transform.localScale = active;
            BotRight.transform.localScale = nonactive;
            Bot.transform.localScale = active;
        }

        else if(num == 3){
            Top.transform.localScale = active;
            TopLeft.transform.localScale = nonactive;
            TopRight.transform.localScale = active;
            Mid.transform.localScale = active;
            BotLeft.transform.localScale = nonactive;
            BotRight.transform.localScale = active;
            Bot.transform.localScale = active;
        }

        else if(num == 4){
            Top.transform.localScale = nonactive;
            TopLeft.transform.localScale = active;
            TopRight.transform.localScale = active;
            Mid.transform.localScale = active;
            BotLeft.transform.localScale = nonactive;
            BotRight.transform.localScale = active;
            Bot.transform.localScale = nonactive;
        }

        else if(num == 5){
            Top.transform.localScale = active;
            TopLeft.transform.localScale = active;
            TopRight.transform.localScale = nonactive;
            Mid.transform.localScale = active;
            BotLeft.transform.localScale = nonactive;
            BotRight.transform.localScale = active;
            Bot.transform.localScale = active;
        }

        else if(num == 6){
            Top.transform.localScale = active;
            TopLeft.transform.localScale = active;
            TopRight.transform.localScale = nonactive;
            Mid.transform.localScale = active;
            BotLeft.transform.localScale = active;
            BotRight.transform.localScale = active;
            Bot.transform.localScale = active;
        }

        else if(num == 7){
            Top.transform.localScale = active;
            TopLeft.transform.localScale = nonactive;
            TopRight.transform.localScale = active;
            Mid.transform.localScale = nonactive;
            BotLeft.transform.localScale = nonactive;
            BotRight.transform.localScale = active;
            Bot.transform.localScale = nonactive;
        }

        else if(num == 8){
            Top.transform.localScale = active;
            TopLeft.transform.localScale = active;
            TopRight.transform.localScale = active;
            Mid.transform.localScale = active;
            BotLeft.transform.localScale = active;
            BotRight.transform.localScale = active;
            Bot.transform.localScale = active;
        }

        else{
            Top.transform.localScale = active;
            TopLeft.transform.localScale = active;
            TopRight.transform.localScale = active;
            Mid.transform.localScale = active;
            BotLeft.transform.localScale = nonactive;
            BotRight.transform.localScale = active;
            Bot.transform.localScale = nonactive;
        }
        
    }
}
