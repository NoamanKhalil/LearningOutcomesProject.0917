using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEditor;

/// The Node.
public class Node : MonoBehaviour
{

	/// The connections (neighbors).
	[SerializeField]
	protected List<Node> myConnections = new List<Node> ();

	/// Gets the connections (neighbors).
	public virtual List<Node> connections
	{
		get
		{
			return myConnections;
		}
	}

	public Node this [ int index ]
	{
		get
		{
			return myConnections [ index ];
		}
	}

	void OnValidate ()
	{
		
		// Removing duplicate elements
		myConnections = myConnections.Distinct ().ToList ();
	}
	
}
