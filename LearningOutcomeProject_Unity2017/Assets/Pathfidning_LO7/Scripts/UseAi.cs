using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAi : MonoBehaviour
{

	[SerializeField]
	protected Graph graph;
	[SerializeField]
	protected Node start;
	[SerializeField]
	protected Node End;
	[SerializeField]
	protected float Speed = 0.01f;
	protected List<Node> path = new List<Node> ();
	protected Node currentNode;

	void Start ()
	{
		transform.position = start.transform.position;
		path = graph.GetShortestPath ( start, End );
		StartCoroutine ( "FollowPath" );
	}

	IEnumerator FollowPath ()
	{
		var e = path.GetEnumerator ();
		while ( e.MoveNext () )
		{
			currentNode = e.Current;
			yield return new WaitUntil ( () =>
			{
				return transform.position == currentNode.transform.position;
			} );
		}
	}

	void Update ()
	{
		if ( currentNode != null )
		{
			transform.position = Vector3.MoveTowards ( transform.position, currentNode.transform.position, Speed );
		}
	}
	
}
