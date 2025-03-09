using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PathNode
{
    public GameObject tile {  get; private set; }
    public List<PathConnection> connections { get; private set; }
    public PathNode(GameObject tile)
    {
        this.tile = tile;
        connections = new List<PathConnection>();
    }
    public void AddConnection(PathConnection connection)
    {
        connections.Add(connection);
    }
}
public class PathConnection
{
    public PathNode fromNode { get; private set; }
    public PathNode toNode { get; private set;}
    public float cost { get; set; } // This is a new cost from tile  to tile we'll use distance between 
    public PathConnection(PathNode from, PathNode to, float cost)
    {
        fromNode = from;
        toNode = to;
        this.cost = cost;
    }
}

public class NodeRecord
{
    public PathNode node { get;  set; }
    public NodeRecord fromRecord { get; set; }
    public PathConnection pathconnection { get; set; }
    public float costSoFar { get; set; }
    public NodeRecord(PathNode node = null)
    {
        this.node = node;
        pathconnection = null;
        fromRecord = null;
        costSoFar = 0;
    }


}
public class PathManager : MonoBehaviour
{
    public List<NodeRecord> openList;
    public List<NodeRecord> closeList;
    // this is path we provide 
    public List<PathConnection> path;

    //----- singleton-----//
    public static PathManager Instance {get; private set;} 
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null) // if the object or the instance doesn't exist yet 
        {
            Instance = this;
            Initialize();
        }
        else
        {
            Destroy(gameObject); // destroying duplicated instances 
        }
    }
    private void Initialize()// --> singleton
    {
        openList = new List<NodeRecord>();
        closeList = new List<NodeRecord>();
        path = new List<PathConnection>();
    }
    public void GetShortestPath(PathNode start, PathNode goal)
    {
        if (path.Count >0)
        {
            // Clear up the path and grid 
            // To Do : Clear tile status of grid 
            path.Clear();
        }
        NodeRecord currentRecord = null;
        openList.Add(new NodeRecord(start));
        while (openList.Count > 0)
        {
            currentRecord = GetSmallestNode();
            if (currentRecord.node == goal)
            {
                // we found the goal !!!!
                openList.Remove(currentRecord);
                closeList.Add(currentRecord);
                currentRecord.node.tile.GetComponent<TileScript>().SetStatus(TileStatus.CLOSED);
                break;
            }
            List<PathConnection> connections = currentRecord.node.connections;
            for (int i = 0; i < connections.Count; i++)
            {
                PathNode endNode = connections[i].toNode;
                NodeRecord endNodeRecord;
                float endNodeCost =  currentRecord.costSoFar + connections[i].cost;
                if(ContainNode(closeList, endNode)) continue;
                else if (ContainNode(openList, endNode))
                {
                    endNodeRecord = GetNodeRecord(openList, endNode);
                    if (endNodeRecord.costSoFar <= endNodeCost)
                    {
                        continue;
                    }
                    else
                    {
                        endNodeRecord = new NodeRecord();
                        endNodeRecord.node = endNode;
                    }
                    endNodeRecord.costSoFar = endNodeCost;
                    endNodeRecord.pathconnection = connections[i];
                    endNodeRecord.fromRecord = currentRecord; // setting the chosen node s to current node
                    if (!ContainNode(openList, endNode))
                    {
                        openList.Add(endNodeRecord);
                        endNodeRecord.node.tile.GetComponent<TileScript>().SetStatus(TileStatus.CLOSED);
                    }
                }
            }
            openList.Remove(currentRecord);
            closeList.Add(currentRecord);
            currentRecord.node.tile.GetComponent<TileScript>().SetStatus(TileStatus.CLOSED );
        }
        if (currentRecord == null) return;
        if (currentRecord.node != goal)
        {
           UnityEngine.Debug.LogError("Cloudn't find the path to the goal");
        }
        else
        {
            UnityEngine.Debug.LogError("Found Path to the goal");
            while(currentRecord.node != start)
            {
                path.Add(currentRecord.pathconnection);
                currentRecord.node.tile.GetComponent<TileScript>().SetStatus(TileStatus.PATH);
                currentRecord = currentRecord.fromRecord;
            }
            path.Reverse();
        }
        openList.Clear();
        closeList.Clear();
    }
    public NodeRecord GetSmallestNode()
    {
        NodeRecord smallestNode = openList[0];
        // Iterate trough the  rest  of the NodeRecords  int the list 
        for (int i = 1; i  < openList.Count; i++)
        {
            // if current nodeRecord has a smaller costSoFar than the smallestNode , update smallestNode    
            if (openList[i].costSoFar < smallestNode.costSoFar)
            {
                smallestNode = openList[i];
            }
            // if they are same filp a coin its optional but looks better  for dijktra ai
            else if (openList[i].costSoFar > smallestNode.costSoFar)
            {
                smallestNode = (Random.value < 0.5f ? openList[i] : smallestNode);
            }
        }
        return smallestNode;
    }
    public bool ContainNode(List<NodeRecord> list , PathNode node)
    {
        foreach (NodeRecord record in list)
        {
            if (record.node == node) return true;
        }
        return false;
    }
    public NodeRecord GetNodeRecord(List<NodeRecord> list , PathNode node)
    {
        foreach (NodeRecord record in list)
        {
            if (record.node == node) return record;
        }
        return null;
    }
}
