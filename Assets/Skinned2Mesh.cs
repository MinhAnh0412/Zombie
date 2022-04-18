using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skinned2Mesh : MonoBehaviour
{
    public SkinnedMeshRenderer[] objs;
    [ContextMenu("Remove Skinned mesh")]
    private void Remove()
    {
        objs = GetComponentsInChildren<SkinnedMeshRenderer>();
        if (objs.Length>0)
        {
            for (int i = 0; i < objs.Length; i++)
            {
                if(objs[i].TryGetComponent<SkinnedMeshRenderer>(out var skinned))
                {
                    var go = objs[i].gameObject;
                    if(!go.TryGetComponent<MeshRenderer>(out var meshRen))
                   meshRen= go.AddComponent<MeshRenderer>();
                    if(!go.TryGetComponent<MeshFilter>(out var meshFil))
                         meshFil= go.AddComponent<MeshFilter>();

                    meshFil.mesh = skinned.sharedMesh;
                    var materials = skinned.sharedMaterials;
                    meshRen.sharedMaterials = materials;
                    DestroyImmediate(skinned);
                }
            }
        }
    }
}
