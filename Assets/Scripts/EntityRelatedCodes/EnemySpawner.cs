using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    //Make a Empty Game Object on where the enemies will randomly spawn.
    //Take note of the values of X and Y for how big your spawner is
    //Refer to this Link i used: https://www.youtube.com/watch?v=AI8XNNRpTTw

    public GameObject Enemy; //What to Spawn
    float randX; //Where it will Spawn (Random Spawning)
    Vector2 SpawnWhere; //Where the Spawning Takes Place
    public float SpawnRate = 2.0f; //How long it takes till the next arrives
    float NextSpawn = 0.0f; //Goes in Sync with SpawnRate

    private float CurrCreat = 0; //just leave this at 0
    public float MaxCreat = 15; //How many total enemies will spawn
    public float CreatChecker = 0; //simply a checker for later

    private void Update()
    {
        WinCon(); //Check to see if spawner done and can move to win condition

        //"If WinCon isnt active, keep spawning Enemies"
    	if(CurrCreat >= MaxCreat)
        {
            CreatChecker = MaxCreat + 1;
            return;
        }
    	SpawnEnemies();

       
    }

    public void WinCon()
    {
        if (CreatChecker == MaxCreat + 1)
        {
            Invoke("TransferWinCon", 5f); //"Run the next function after Xf seconds"
        }
    }

    public void TransferWinCon()
    {
        //This part is initiating the Win Condition - Once Enemies are done, Transfer to Different Scene
        //FindObjectOfType<GameManager>().GameWin();

        //You do not really need this part. If the spawner reached its limit,
        //just stop spawning creatures
    }

    private void SpawnEnemies(){
        
    		if(Time.time > NextSpawn)
        	{
            	NextSpawn = Time.time + SpawnRate; 
            	randX = Random.Range(-7.0f, 7.0f); //Declare the Area in which the Spawn will happen || Do match the size with the EmptyObject's x and y
            	SpawnWhere = new Vector2(randX, transform.position.y); //Where it will Spawn (Fixed)
           		Instantiate(Enemy, SpawnWhere, Quaternion.identity); //Spawn Time
           		CurrCreat++; //Per Enemy Spawned, +1 Spawn Count
        	}
    	
    }
}
