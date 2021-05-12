using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ArTapToPlaceObj : MonoBehaviour
{

    public GameObject prefabObj;

    private GameObject spawnedObject;
    private ARRaycastManager aRRaycastManager;
    private Vector2 touchpos;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }
    
    bool TryGetTouchPos(out Vector2 touchpos)
    {
        if(Input.touchCount > 0)
        {
            touchpos = Input.GetTouch(0).position;
            return true;
        }

        touchpos = default;
        return false;
    }

    private void Update()
    {
        if(!TryGetTouchPos(out touchpos) || touchpos.y<500)
        {
            return;
        }
        Debug.Log(touchpos.y);
        if (aRRaycastManager.Raycast(touchpos, hits, TrackableType.PlaneWithinPolygon))
        {
            var hit = hits[0].pose;

            if(Interaction.objinscene == null)
            {
                prefabObj = LoadAssetBundles.objinscene;
                Interaction.objinscene =  Instantiate(Interaction.objinscene, hit.position,hit.rotation);
                LoadAssetBundles.objinscene = spawnedObject;
            }
            else
            {
                Interaction.objinscene.transform.position = hit.position;
            }
        }
    }


}
