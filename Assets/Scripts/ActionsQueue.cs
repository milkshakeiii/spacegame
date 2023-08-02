using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsQueue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // when the mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // get the world position of the mouse
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector2Int boardPosition = new Vector2Int(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y));
            Debug.Log("Clicked at " + boardPosition);
        }
    }

    private void OnMouseDown()
    {
        
    }
}
