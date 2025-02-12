using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileStatus
{
    UNVISITED,
    OPEN,
    CLOSED,
    IMPASSABLE,
    GOAL,
    START
};

public enum NeighbourTile
{
    TOP_TILE,
    RIGHT_TILE,
    BOTTOM_TILE,
    LEFT_TILE,
    NUM_OF_NEIGHBOUR_TILES
};

public class GridManager : MonoBehaviour
{
    // Fill in for Lab 4 Part 1.
    [SerializeField]
    private GameObject tilePrefab;
    [SerializeField]
    private GameObject tilePanelPrefab;
    [SerializeField]
    private GameObject tilePanelParent;
    [SerializeField]
    private GameObject minePrefab;
    [SerializeField]
    private Color[] colors;
    private GameObject[,] grid;
    private int rows = 12;
    private int columns = 16;
    private List<GameObject> mines = new List<GameObject>();
    
    

    public static GridManager Instance { get; private set; } // Static object of the class.

    void Awake()
    {
        if (Instance == null) // If the object/instance doesn't exist yet.
        {
            Instance = this;
            Initialize();
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances.
        }
    }

    private void Initialize()
    {
        // Fill in for Lab 4 Part 1.
        BuildGrid();
        ConnectGrid();
    }

    void Update()
    {
        // Fill in for Lab 4 Part 1.
        if (Input.GetKeyDown(KeyCode.G))
        {
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(!child.gameObject.activeSelf); // toggle tiles
            }
            if(Input.GetKeyDown(KeyCode.M))
            {
                Vector2 gridPosition = GetGridPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                GameObject mineInst =Instantiate(minePrefab, new Vector3(gridPosition.x, gridPosition.y, 0f), Quaternion.identity);
                mineInst.GetComponent<NavigationObject>().SetGridIndex();
                Vector2 mineIndex = mineInst.GetComponent<NavigationObject>().GetGridIndex();
                grid[(int)mineIndex.y, (int)mineIndex.x].GetComponent<TileScript>().SetStatus(TileStatus.IMPASSABLE);
                mines.Add(mineInst);
            }
            if(Input.GetKeyDown(KeyCode.C))
            {
                foreach(GameObject mine in mines)
                {
                    Vector2 mineIndex = mine.GetComponent<NavigationObject>().GetGridIndex();
                    grid[(int)mineIndex.y, (int)mineIndex.x].GetComponent<TileScript>().SetStatus(TileStatus.UNVISITED);
                    Destroy(mine);
                }
                mines.Clear();
            }
        }
    }

    private void BuildGrid()
    {
        grid = new GameObject[rows, columns];
        int count = 0;
        float rowPos = 5.5f;
        for (int row =0; row < rows; row++, rowPos--)
        {
            float colPos = -7.5f;
            for (int col =0; columns < col++; colPos++)
            {
                GameObject tileInst = GameObject.Instantiate(tilePrefab, new Vector3(colPos, rowPos, 0f), Quaternion.identity);
                tileInst.GetComponent<TileScript>().SetColor(colors[System.Convert.ToInt32(count++ %2 == 0)]);
                tileInst.transform.parent = transform;
                grid[row, col] = tileInst;
                GameObject tilePanelInst = Instantiate(tilePrefab, tilePanelPrefab.transform.position
            }
            count--;
        }
        
            
    }
    // Set the tile under the ship to start
   // GameObject ship = GameObject.FindGameObjectWithTag("Ship");
    //Vector2 shipIndices = ship.GetComponent<NavigationObject>().GetGridIndex;
    
    private void ConnectGrid()
    {
        // Fill in for Lab 4 Part 1.
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {

               TileScript tileScript = grid[row, col].GetComponent<TileScript>();
                if (row > 0)// Set top neigbour if tile is not in the top row 
                {
                    tileScript.SetNeighbourTile((int)NeighbourTile.TOP_TILE, grid[row - 1, col]);
                }
                if(col < columns -1)
                {
                    tileScript.SetNeighbourTile((int)NeighbourTile.RIGHT_TILE, grid[row, col +1]);

                }
                if (row < rows  -1) // set borrom neightbour if tile is not in the bottom row 
                {
                    tileScript.SetNeighbourTile((int)NeighbourTile.BOTTOM_TILE, grid[row + 1, col]);

                }
                if (col > 0 )   // set neighbour if tile is not leftmost tile
                {
                    tileScript.SetNeighbourTile((int)NeighbourTile.LEFT_TILE, grid[row , col - 1]);
                }
            }
        }
    }

    public GameObject[,] GetGrid()
    {
        // Fix for Lab 4 Part 1.
        //
        // return grid;
        return grid;
    }

    // The following utility function creates the snapping to the center of a tile.
    public Vector2 GetGridPosition(Vector2 worldPosition)
    {
        float xPos = Mathf.Floor(worldPosition.x) + 0.5f;
        float yPos = Mathf.Floor(worldPosition.y) + 0.5f;
        return new Vector2(xPos, yPos);
    }
}
