using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// The Graph.
public class Graph : MonoBehaviour
{

	/// The nodes.
	[SerializeField]
	protected List<Node> Nodes = new List<Node> ();

	/// Gets the nodes.
	public virtual List<Node> nodes
	{
		get
		{
			return Nodes;
		}
	}

	/// Gets the shortest path from the starting Node to the ending Node.
	///Returns the shortest path, from the start to the end.
	public virtual List<Node> GetShortestPath ( Node start, Node end )
	{
		
		// The final path
		List<Node> path = new List<Node> ();
		
		// The list of unvisited nodes
		List<Node> unvisited = new List<Node> ();
		
		// Previous nodes in optimal path from source
		Dictionary<Node, Node> previous = new Dictionary<Node, Node> ();
		
		// The calculated distances, set all to Infinity at start, except the start Node
		Dictionary<Node, float> distances = new Dictionary<Node, float> ();
		
		for ( int i = 0; i < Nodes.Count; i++ )
		{
			Node node = Nodes [ i ];
			unvisited.Add ( node );
			
			// Setting the node distance to Infinity
			distances.Add ( node, float.MaxValue );
		}
		
		// Set the starting Node distance to zero
		distances [ start ] = 0f;
		while ( unvisited.Count != 0 )
		{
			
			// Ordering the unvisited list by distance, smallest distance at start and largest at end
			unvisited = unvisited.OrderBy ( node => distances [ node ] ).ToList ();
			
			// Getting the Node with smallest distance
			Node current = unvisited [ 0 ];
			
			// Remove the current node from unvisisted list
			unvisited.Remove ( current );
			
			// When the current node is equal to the end node, then we can break and return the path
			if ( current == end )
			{
				
				// Construct the shortest path
				while ( previous.ContainsKey ( current ) )
				{
					
					// Insert the node onto the final result
					path.Insert ( 0, current );
					
					// Traverse from start to end
					current = previous [ current ];
				}
				
				// Insert the source onto the final result
				path.Insert ( 0, current );
				break;
			}
			
			// Looping through the Node connections (neighbors) and where the connection (neighbor) is available at unvisited list
			for ( int i = 0; i < current.connections.Count; i++ )
			{
				Node neighbor = current.connections [ i ];
				
				// Getting the distance between the current node and the connection (neighbor)
				float length = Vector3.Distance ( current.transform.position, neighbor.transform.position );
				
				// The distance from start node to this connection (neighbor) of current node
				float alt = distances [ current ] + length;
				
				// A shorter path to the connection (neighbor) has been found
				if ( alt < distances [ neighbor ] )
				{
					distances [ neighbor ] = alt;
					previous [ neighbor ] = current;
				}
			}
		}
		return path;
	}
	
}
