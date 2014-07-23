using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

  public GameObject playerPrefab;
  
  // event handlers
  void OnServerInitialized() {
      SpawnPlayer();
  }
   
  void OnConnectedToServer() {
      SpawnPlayer();
  }
  
  // Spawn player on the network from the prefab
  private void SpawnPlayer() {
      Network.Instantiate(playerPrefab, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
  }
  
  // Yup, you guessed it. Starts the server. RLY.
  public void StartServer() {
		Network.InitializeServer (32, 25565, false); // connection number, port, use NAT
		Network.sendRate = 15; // tickrate
		Debug.Log ("Server Started");
	}
	
	// do I really have to explain myself here?
	public void ConnectToServer (string IPAddress) {
		Network.Connect(IPAddress, 25565);
	}
}
