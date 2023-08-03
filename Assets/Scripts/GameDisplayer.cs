using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDisplayer : MonoBehaviour
{
    public GameObject shipPrefab;

    private Dictionary<string, Ship> uuidsToShips = new();

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

    private void DisplayZone(Dictionary<string, string> args, string myShipUuid)
    {
        Debug.Log("Displaying zone");
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
                    if (uuidsToShips.ContainsKey(uuid))
                    {
                        Ship ship = uuidsToShips[uuid];
                        ship.DisplayUpdate(position, facing);
                        if (uuid == myShipUuid)
                        {
                            // follow with camera
                            Camera.main.transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y, -10);
                        }
                    }
                    else
                    {
                        GameObject ship = Instantiate(shipPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
                        ship.GetComponent<Ship>().Initialize(position, facing);
                        if (uuid == myShipUuid)
                        {
                            // follow with camera
                            Camera.main.transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y, -10);
                        }
                        uuidsToShips.Add(uuid, ship.GetComponent<Ship>());
                    }
                }
            }
        }
    }
}
