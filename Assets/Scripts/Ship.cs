using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Ship : MonoBehaviour
{
    private Vector2Int gamePosition;
    private string gameRotation;

    public void Initialize(Vector2Int newGamePosition, string newGameRotation)
    {
        gamePosition = newGamePosition;
        transform.transform.position = new Vector3(gamePosition.x, gamePosition.y, 0);

        gameRotation = newGameRotation;
        if (newGameRotation == "N")
        {
            transform.Rotate(0, 0, 0);
        }
        else if (newGameRotation == "S")
        {
            transform.Rotate(0, 0, -180);
        }
        else if (newGameRotation == "W")
        {
            transform.Rotate(0, 0, 270);
        }
        else if (newGameRotation == "E")
        {
            transform.Rotate(0, 0, 90);
        }
    }

    public void DisplayUpdate(Vector2Int newGamePosition, string newGameRotation)
    {
        Initialize(newGamePosition, newGameRotation);
    }
}
