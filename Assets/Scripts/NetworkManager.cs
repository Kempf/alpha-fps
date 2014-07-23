public class NetworkManager : MonoBehaviour {

  public GameObject playerPrefab;
   
  void OnServerInitialized()
  {
      SpawnPlayer();
  }
   
  void OnConnectedToServer()
  {
      SpawnPlayer();
  }
   
  private void SpawnPlayer()
  {
      Network.Instantiate(playerPrefab, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
  }
}
