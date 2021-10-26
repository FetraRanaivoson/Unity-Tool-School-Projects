using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyGizmos
{
   [DrawGizmo(GizmoType.Active | GizmoType.Selected)]
   public static void DrawGizmoForGizmoCube(GizmoCube script, GizmoType gizmoType)
   {
      Gizmos.color = Color.cyan;
      Gizmos.DrawSphere(script.transform.position, 5);
   }
}
