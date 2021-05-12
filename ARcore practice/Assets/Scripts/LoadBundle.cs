using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBundle : MonoBehaviour
{

    public string BundleURL;
    AssetBundle bundle;
    bool Loaded;

    private void Start()
    {
        WWW www = new WWW(BundleURL);
        StartCoroutine(WebReq(www));
    }

    public void PlaceObj(string name)
    {
        if (!Loaded) return;
        if(Interaction.objinscene != null)
        {
            Destroy(Interaction.objinscene);
        }
        var prefab = bundle.LoadAsset(name);
        Interaction.objinscene = (GameObject)Instantiate(prefab);
    }

    IEnumerator WebReq(WWW www)
    {
        yield return www;

        while(www.isDone == false)
        {
            yield return null;
        }

        bundle = www.assetBundle;

        if(www.error == null)
        {
            Loaded = true;
            Debug.Log("loaded");
        }
        else
        {
            Debug.Log(www.error);
        }
    }
}

