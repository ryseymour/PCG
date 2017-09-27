using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//This will store all the cells. Note that because it is 'static' we can refer to it from other
	//	scripts without needing to call "GameObject.Find" and such.
	public static CellScript[,] grid;
	//public static Tree[,] trgrid;

	public static int numCellsW = 30;
	public static int numCellsH = 30;

	public static int numCellstW = 30;
	public static int numCellstH = 30;

	//float cellWidth = .5f;
	//float cellHeight = .5f;
	//float cellSpacing = 0.1f;

	float cellWidth = 1.0f;
	float cellHeight = 1.0f;
	float cellSpacing = 0.0f;

	float simulationTimer = 0;
	float simulationRate = 0.2f;



	public static bool emerge = true;

	public static bool simulate = false;



	// Use this for initialization
	void Start () {
		//Instantiate the empty two dimesnional array
		grid = new CellScript[GameManager.numCellsW, GameManager.numCellsH];

		//Using 'nested for loops', instantiate cubes with cell scripts in a way such that
		//	each cell will be places in a top left oriented coodinate system.
		//	I.e. the top left cell will have the x, y coordinates of (0,0), and the bottom right will
		//	have the coodinate (numCellsW-1, numCellsH-1)
		for (int y = 0; y < GameManager.numCellsH; y++) {
			for (int x = 0; x < GameManager.numCellsW; x++) {
				GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				//GameObject cocoPre = (GameObject)Instantiate (Resources.Load ("Cube"), transform.position, transform.rotation);
				CellScript cellScript = cube.AddComponent<CellScript> ();
				//instantiate material here
				//get reference to renderer in cellscript.  
				//GameObject TreePre = (GameObject)Instantiate (Resources.Load ("CntPrev2"), transform.position, transform.rotation);
				//TreePre.transform.parent = this.transform;
				//CellScript trscript = (GameObject)Instantiate (Resources.Load ("Cube"), transform.position, transform.rotation);
				//TreeScript treeScript = cube.AddComponent<TreeScript> ();
				cellScript.x = x;
				cellScript.y = y;
				GameManager.grid [x, y] = cellScript;
				//Create the position of the cube that represents the cell, based on the cell's x,y coordinate
				//	Note that by making the x,y positions be something like "x * (cellWidth + cellSpacing)" we 
				//	can have arbitrarily sized cells with spacing.
				Vector3 pos = new Vector3 (x * ((cellWidth) + cellSpacing), y * ((cellHeight) + cellSpacing), 0);
				cube.transform.position = pos;

				//Vector3 pos = new Vector3 (x * ((cellWidth) + cellSpacing), 0, y * ((cellHeight) + cellSpacing);
				//cube.transform.position = pos;
			}
		}

		//trgrid = new Tree[GameManager.numCellstW, GameManager.numCellstH];

		//Using 'nested for loops', instantiate cubes with cell scripts in a way such that
		//	each cell will be places in a top left oriented coodinate system.
		//	I.e. the top left cell will have the x, y coordinates of (0,0), and the bottom right will
		//	have the coodinate (numCellsW-1, numCellsH-1)
		//for (int y = 0; y < GameManager.numCellstH; y++) {
			//for (int x = 0; x < GameManager.numCellstW; x++) {
				//GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				//GameObject cocoPre = (GameObject)Instantiate (Resources.Load ("CocoPre"), transform.position, transform.rotation);
				//TreeScript trScript = GameObject.AddComponent<TreeScript> ();
				//TreeScript treeScript = cube.AddComponent<TreeScript> ();
				//trScript.x = x;
				//trScript.y = y;
				//GameManager.trgrid [x, y] = trScript;
				//Create the position of the cube that represents the cell, based on the cell's x,y coordinate
				//	Note that by making the x,y positions be something like "x * (cellWidth + cellSpacing)" we 
				//	can have arbitrarily sized cells with spacing.
				//Vector3 pos = new Vector3 (x * (cellWidth + cellSpacing), y * (cellHeight + cellSpacing), 0);
				//GameObject.transform.position = pos;
	}
		//}
	//}

	void Update() {
		if (GameManager.simulate) {
			simulationTimer -= Time.deltaTime/20;

			if (simulationTimer < 0) {
				simulationTimer = simulationRate;

				//Update grid based on sweet game of life rules
				for (int y = 0; y < GameManager.numCellsH; y++) {
					for (int x = 0; x < GameManager.numCellsW; x++) {
						//GameManager.grid[x, y]
						List<CellScript> neighbors = GameManager.getNeighbors (x, y);
						List<CellScript> liveNeighbors = new List<CellScript> ();
						foreach (CellScript neighbor in neighbors) {
							if (neighbor.alive) {
								liveNeighbors.Add (neighbor);
							}
						}
						GameManager.grid [x, y].newAliveState = GameManager.grid [x, y].alive;
						//GameManager.grid [x, y].emergent = GameManager.emerge;

					
						//Apply the 4 rules from Conway's Gaem of Life (https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life)
						//1. Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
						if (GameManager.grid [x, y].alive && liveNeighbors.Count < 2) {
							GameManager.grid [x, y].newAliveState = false;
							//CellScript.growthrate = CellScript.growthrate + 1;
							//CellScript.growing = 0;
						}
						//2. Any live cell with two or three live neighbours lives on to the next generation.
						else if (GameManager.grid [x, y].alive && (liveNeighbors.Count == 2 || liveNeighbors.Count == 3)) {
							GameManager.grid [x, y].newAliveState = true;
							//GameManager.grid [x, y] = GameManager.emerge;
							//CellScript.growthrate = CellScript.growthrate + 1;
						}
						//3. Any live cell with more than three live neighbours dies, as if by overpopulation.
						else if (GameManager.grid [x, y].alive && liveNeighbors.Count > 3) {
							GameManager.grid [x, y].newAliveState = false;
							//CellScript.deathrate = CellScript.deathrate + 1;
							//CellScript.growing = 0;
						}
						//4. Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
						else if (!GameManager.grid [x, y].alive && liveNeighbors.Count == 3) {
							GameManager.grid [x, y].newAliveState = true;
							//CellScript.growthrate = CellScript.growthrate + 1;
						}
					}
				}
				//Now that we have looped through all of the cells in the grid, and stored what their alive status should
				//	be in each cell's newAliveState variable, update each cell's alive state to be that value.
				for (int y = 0; y < GameManager.numCellsH; y++) {
					for (int x = 0; x < GameManager.numCellsW; x++) {
						GameManager.grid [x, y].alive = GameManager.grid [x, y].newAliveState;
					}
				}
					
			}
		}
	}

	public static List<CellScript> getNeighbors(int x, int y) {
		List<CellScript> neighbors = new List<CellScript> ();

		//Collect all the cells in surrounding 8 cells of the cells at grid[x,y]
		for (int i = Mathf.Max(0, x - 1); i <= Mathf.Min(GameManager.numCellsW - 1, x + 1); i++) {
			for (int j = Mathf.Max(0, y - 1); j <= Mathf.Min(GameManager.numCellsH - 1, y + 1); j++) {
				if ((i == x && j == y) == false) {
					neighbors.Add (GameManager.grid [i, j]);
				}
			}
		}

		return neighbors;
	}

	//This function is called by the UI toggle's event system (look at the Toggle child of the Canvas)
	public void toggleSimulate(bool value) {
		GameManager.simulate = value;
	}
}