using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDisplayer : MonoBehaviour
{
    public GameObject shipPrefab;
    public GameObject shipGhostPrefab;
    public GameObject courseLinePrefab;

    private Dictionary<string, Ship> uuidsToShips = new();
    private Dictionary<Vector2Int, bool> occupiedDict = new();

    private string myCurrentShipUuid;

    private void OnEnable()
    {
        ServerPinger.OnZoneStateReceived += DisplayZone;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetActionsToReachPoint(string myShipUuid, Vector2Int targetPoint)
    {
        // TODO
    }

    public void DisplayActionQueue(string actionQueue, string myShipUuid)
    {
        // TODO
    }

    private void DisplayZone(Dictionary<string, string> args, string myShipUuid)
    {
        Debug.Log("Displaying zone");
        myCurrentShipUuid = myShipUuid;
        occupiedDict.Clear();
        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                if (args.ContainsKey(i + "," + j + ",type"))
                {
                    Debug.Log("Found ship at " + i + "," + j);
                    //string type = args[i + "," + j + ",type"];
                    string uuid = args[i + "," + j + ",uuid"];
                    string facing = args[i + "," + j + ",facing"];
                    Vector2Int position = new Vector2Int(i, j);
                    occupiedDict[position] = true;
                    Ship ship;
                    if (uuidsToShips.ContainsKey(uuid))
                    {
                        ship = uuidsToShips[uuid];
                        ship.DisplayUpdate(position, facing);
                    }
                    else
                    {
                        GameObject shipObject = Instantiate(shipPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
                        shipObject.GetComponent<Ship>().Initialize(position, facing);
                        ship = shipObject.GetComponent<Ship>();
                        uuidsToShips.Add(uuid, ship);
                    }
                    if (uuid == myShipUuid)
                    {
                        // follow with camera
                        Camera.main.transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y, -10);
                    }
                }
            }
        }
    }
}
