using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class convert : MonoBehaviour
{
   [ContextMenu("convert to")]
   void Convert()
    {
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.sharedMesh = skinnedMeshRenderer.sharedMesh;
        meshRenderer.sharedMaterials = skinnedMeshRenderer.sharedMaterials;
        DestroyImmediate(skinnedMeshRenderer);
        DestroyImmediate(this);
    }
}
