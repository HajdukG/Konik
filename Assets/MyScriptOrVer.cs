using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class MyScriptOrVer : MonoBehaviour
{
    public GameObject[] markers;
    public GameObject[] displayObjects;
    private DefaultTrackableEventHandler[] dteh;
    private Renderer[] rendererComponents;
    private Collider[] colliderComponents;
    void Awake()
    {
        int i = 0;
        dteh = new DefaultTrackableEventHandler[markers.Length];
        foreach (GameObject obj in markers)
        {
            dteh[i] = obj.GetComponent<DefaultTrackableEventHandler>();
            i++;
        }
        rendererComponents = new Renderer[markers.Length];
        colliderComponents = new Collider[markers.Length];
        for(int zxc = 0; zxc<3; zxc++)
        {
            rendererComponents[zxc] = displayObjects[zxc].GetComponent<Renderer>();
            colliderComponents[zxc] = displayObjects[zxc].GetComponent<Collider>();
            if (rendererComponents[zxc] != null)
                rendererComponents[zxc].enabled = false;
            if (colliderComponents[zxc] != null)
                colliderComponents[zxc].enabled = false;
            displayObjects[zxc].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dteh[0].detected)
        {
            if (rendererComponents[0] != null)
                rendererComponents[0].enabled = true;
            if (colliderComponents[0] != null)
                colliderComponents[0].enabled = true;
            displayObjects[0].SetActive(true);

            if (rendererComponents[1] != null)
                rendererComponents[1].enabled = false;
            if (colliderComponents[1] != null)
                colliderComponents[1].enabled = false;
            displayObjects[1].SetActive(false);

            if (rendererComponents[2] != null)
                rendererComponents[2].enabled = false;
            if (colliderComponents[2] != null)
                colliderComponents[2].enabled = false;
            displayObjects[2].SetActive(false);
        }
        if (dteh[1].detected)
        {
            if (rendererComponents[1] != null)
                rendererComponents[1].enabled = true;
            if (colliderComponents[1] != null)
                colliderComponents[1].enabled = true;
            displayObjects[1].SetActive(true);

            if (rendererComponents[2] != null)
                rendererComponents[2].enabled = false;
            if (colliderComponents[2] != null)
                colliderComponents[2].enabled = false;
            displayObjects[2].SetActive(false);

            if (rendererComponents[0] != null)
                rendererComponents[0].enabled = false;
            if (colliderComponents[0] != null)
                colliderComponents[0].enabled = false;
            displayObjects[0].SetActive(false);
        }
        if (dteh[2].detected)
        {
            if (rendererComponents[2] != null)
                rendererComponents[2].enabled = true;
            if (colliderComponents[2] != null)
                colliderComponents[2].enabled = true;
            displayObjects[2].SetActive(true);

            if (rendererComponents[1] != null)
                rendererComponents[1].enabled = false;
            if (colliderComponents[1] != null)
                colliderComponents[1].enabled = false;
            displayObjects[1].SetActive(false);

            if (rendererComponents[0] != null)
                rendererComponents[0].enabled = false;
            if (colliderComponents[0] != null)
                colliderComponents[0].enabled = false;
            displayObjects[0].SetActive(false);
        }
       /* else
        {
            if (rendererComponents[2] != null)
                rendererComponents[2].enabled = false;
            if (colliderComponents[2] != null)
                colliderComponents[2].enabled = false;
            displayObjects[2].SetActive(false);

            if (rendererComponents[1] != null)
                rendererComponents[1].enabled = false;
            if (colliderComponents[1] != null)
                colliderComponents[1].enabled = false;
            displayObjects[1].SetActive(false);

            if (rendererComponents[0] != null)
                rendererComponents[0].enabled = false;
            if (colliderComponents[0] != null)
                colliderComponents[0].enabled = false;
            displayObjects[0].SetActive(false);
        }
        */
    }
}
