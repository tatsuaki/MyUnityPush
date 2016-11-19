using UnityEngine;
using UnityEditor;
using System.Collections;

public class Question5Editor {

	[DrawGizmo(GizmoType.Active)]
	static void OnDrawGizmo(Question5 question5, GizmoType type) {
		foreach(Vector3 potison in question5.positions) {
			Gizmos.DrawWireSphere(potison, 0.5f);
		}
	}
}
