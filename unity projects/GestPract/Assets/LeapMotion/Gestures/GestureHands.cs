using UnityEngine;
using System.Collections;
using Leap;

public class GestureHands : MonoBehaviour {
	Controller controller;
	Timer timer;

	public GameObject block1;
	public GameObject block2;
	public GameObject sphere;
	public GameObject sphere1;
	public GameObject sphere2;
	public GameObject sphere3;
	public GameObject sphere4;
	public GameObject sphere5;
	public GameObject sphere6;
	public GameObject sphere7;
	int score = 0;


	/*
	int spawnTime = 0;
	public GameObject blocks;
	public Vector3 ObjectSpawnPosition = new Vector3(0,2,0);
	public GameObject obj;


	void spawn_cube(){

		GameObject cubeSpawn = (GameObject)Instantiate (obj, new Vector3 (0, 2, 0), Quaternion.identity);
		//Instantiate(obj, ObjectSpawnPosition, Quaternion.identity);


	}
	*/

	//public int numSpheres = 5;
	//public GameObject[] sphereArr;






	// Use this for initialization
	void Start () {
		timer = new Timer();
		controller = new Controller();

		//Array of game objects
		//sphereArr = new GameObject[numSpheres];

		// Swipe Gesture for getting rid of bad balls
		controller.EnableGesture(Gesture.GestureType.TYPESWIPE);
		controller.Config.SetFloat("Gesture.Swipe.MinLength", 200.0f);
		controller.Config.SetFloat("Gesture.Swipe.MinVelocity", 750f);

		// Grab/pinch Gesture
		/*
		Frame frame = controller.Frame(); // controller is a Controller object
		HandList hands = frame.Hands;
		Hand firstHand = hands[0];
		*/
		timer.starTimer();
		controller.Config.Save();
	
	
	}

	//making box/GUI to show time and score of game. Also runs every frame like update function
	void OnGUI(){
		if (timer != null) {
			GUILayout.Box("Time: " +timer.getTime()+ "");

		}
		GUILayout.Box("Score: " +score+ "");
	}
	
	// point dection on made baskets
	void OnTriggerEnter(Collider Sphere) {
       			//Destroy(other.gameObject);
       			//Debug.Log(other.transform.name); to see which shape it detects
		if(Sphere.gameObject == sphere || Sphere.gameObject == sphere1 || Sphere.gameObject == sphere2 || Sphere.gameObject == sphere3 || Sphere.gameObject == sphere4 || Sphere.gameObject == sphere5 || Sphere.gameObject == sphere6 || Sphere.gameObject == sphere7){
       				//Sphere.gameObject.renderer.material.color = Color.green; code to change color of object
       				score = score + 1;
					
       	}
       			
       	Debug.Log(score);
    }

    void OnTriggerExit(Collider sphere1) {
       			// Destroy(other.gameObject);
       			// Debug.Log("left the area");
    }

	
	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame();
		GestureList gestures = frame.Gestures();
		for (int  i = 0; i< gestures.Count; i++){
			Gesture gesture = gestures[i];
			if(gesture.Type == Gesture.GestureType.TYPESWIPE){
				SwipeGesture Swipe = new SwipeGesture(gesture);
				Vector swipeDirection = Swipe.Direction;
				if(swipeDirection.x < 0){
					Debug.Log("Left");
					DestroyObject(block1);
				} 
				else if(swipeDirection.x > 0){
					Debug.Log("Right");
					DestroyObject(block2);
				}
			}
		}
	
	}
	
	public class Timer{
		
		int startTime;
		int	stopTime;
		bool timeRunning = false;
		public Timer(){}
		
		public int getTime(){
			if (timeRunning) {
				return	(int)Time.time - startTime;
			}
			else {
				return	stopTime - startTime;
			}
			
		}
		
		public void starTimer(){
			startTime = (int)Time.time;
			timeRunning = true;
			Debug.Log ("timer start:" + getTime());
		}
		
		public void stopTimer(){
			stopTime = (int)Time.time;
			timeRunning = false;
			Debug.Log ("Stopped Timer at:" +getTime()+ " seconds.");
		}
		
	}

}
