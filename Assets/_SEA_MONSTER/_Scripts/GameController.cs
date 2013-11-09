/*
Maintaince Logs:
2013-04-26    Waigo    Initial version.  Controlling the game. 

*/

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public GameObject seaMonsterObj;
	
	
	private SeaMonster seaMonster;
	
    #region Init / Add singleton
    private static GameController instance;
    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                //instance = new GameController();
				instance = (GameController)FindObjectOfType(typeof(GameController)); 
            }
			if (!instance)
            {
                Debug.LogError("GameController could not find itself!");
             } 

            return instance;
        }
    }
    #endregion 	
	
	// Use this for initialization
	void Start () {
		seaMonster = seaMonsterObj.GetComponent<SeaMonster>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	
	public void DoJump(){
		seaMonster.DoJump();
	}
}
