using UnityEngine;
using KBEngine;
using System; 

public class UI_Chat : MonoBehaviour {
	bool showInput = false;
	UnityEngine.GameObject chatInputObj = null;
    KBEngine.Avatar player = null;
    public UITextList ct ;
	void Awake ()     
	{
	}
	
	void Start () 
	{
        KBEngine.Event.registerOut("recvMsg", this, "recvMsg");
		chatInputObj = UnityEngine.GameObject.Find("chatInput");
		NGUITools.SetActive(chatInputObj, true);
        player = (KBEngine.Avatar)KBEngineApp.app.player();

	}

	void Update()
	{
        if (Input.GetKeyUp(KeyCode.Return))
        {
        	onShowInput();
        }
	}
	
	void onShowInput()
	{
		showInput = !showInput;
		Common.DEBUG_MSG("UI_Chat::onShowInput: bool(" + showInput + ")!");
        //NGUITools.SetActive(chatInputObj, showInput);
        if (showInput)
        {
            if (getInput().Length>0)
            {
                if (player == null)
                {
                    player = (KBEngine.Avatar)KBEngineApp.app.player();
                }
                player.sendMsg(getInput());
                //recvMsg("hello",getInput());
                chatInputObj.GetComponent<UIInput>().value = "";
            }
        }
	}

    public void recvMsg(string name, string msg)
    {
        ct.Clear();
        ct.Add(name + ": " + msg);
    }

	void OnMouseEnter ()
	{
	}
	
	void OnMouseOver ()
	{
	}
	
	void OnMouseExit ()
	{
	}
	
	public string getInput()
	{
        return chatInputObj.GetComponent<UIInput>().value;
	}
}
 