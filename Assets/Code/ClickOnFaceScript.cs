using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnFaceScript : MonoBehaviour {

    // Public fields are visible and their values can be changed directly in the editor
    // rrepresents the position displacement needed to compure the position of the new instance
    public Vector3 delta;

    // This function is triggered when the mouse cursor is over the GameObject on which this scrpit runs
    void OnMouseOver()
    {
        // If the left mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            // Display a message in the Console tab
            Debug.Log("Left click!");
            // Destroy the parent of the face we clicked
            Destroy(this.transform.parent.gameObject);
        }

        // If the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Display a message in the Console tab
            Debug.Log("Right click!");
            WorldGenerator.CloneAndPlace(this.transform.parent.transform.position + delta, // N = C + delta
                this.transform.parent.gameObject);
        }
    }
}
