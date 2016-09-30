using UnityEngine;
using System.Collections;

public class path_finder : MonoBehaviour {

	public TextAsset csv_file; 

	void Start () {
		string[,] grid = csv_reader.SplitCsvGrid(csv_file.text);
		//Debug.Log("size = " + (1+ grid.GetUpperBound(0)) + "," + (1 + grid.GetUpperBound(1))); 

		//csv_reader.DebugOutputGrid(grid); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
