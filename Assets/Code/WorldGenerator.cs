using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {

    // Drag and drop here the voxel from the scene
    // Used to create new instances
    public GameObject Voxel;

    //Specify the dimensions of the world
    public float SizeX;
    public float SizeZ;
    public float SizeY;

	// Use this for initialization
	void Start () {
        //Start the world generation coroutine
        // StartCoroutine function always returns immediately, however you can yield the result
        StartCoroutine(SimpleGenerator());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void CloneAndPlace(Vector3 newPosition,
                                    GameObject originalGameObject)
    {
        // Clone
        GameObject clone = (GameObject)Instantiate(originalGameObject, newPosition, Quaternion.identity);

        //Place
        clone.transform.position = newPosition;
        //Rename
        clone.name = "Cube@" + clone.transform.position;
    }

    IEnumerator SimpleGenerator()
    {
        uint numberOfInstances = 0;
        uint instancesPerFrame = 50;

        for(int x = 1; x <= SizeX; x++)
        {
            for(int z = 1; z <= SizeZ; z++)
            {
                //compute a random height
                float height = Random.Range(0, SizeY);
                for (int y = 0; y <= height; y++)
                {
                    Vector3 newPosition = new Vector3(x, y, z);
                    CloneAndPlace(newPosition, Voxel);
                    numberOfInstances++;

                    if (numberOfInstances == instancesPerFrame)
                    {
                        numberOfInstances = 0;
                        yield return new WaitForEndOfFrame();
                    }
                }
            }
        }
    }
}
