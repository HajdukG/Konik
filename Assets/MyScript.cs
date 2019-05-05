using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class MyScript : MonoBehaviour
{
    public Transform camera;
    public GameObject[] markers;
    public GameObject myObject;
    DefaultTrackableEventHandler[] dt;
    GameObject trackingObject;
    Renderer rendererComponents;
    Collider colliderComponents;
    bool awaken;
    // Canvas canvasComponents;
    // Start is called before the first frame update
    void Awake()
    {
        awaken = false;
        int i = 0;
        dt = new DefaultTrackableEventHandler[markers.Length];
        foreach(GameObject obj in markers)
        {
            dt[i] = obj.GetComponent<DefaultTrackableEventHandler>();
            i++;
        }
        Vector3 vectorObj = positionOfObject(markers[0].transform.position, markers[1].transform.position, markers[2].transform.position);
        Quaternion qua = new Quaternion(0, 0, 0, 0);
        trackingObject = Instantiate(myObject, vectorObj, qua);
        
        rendererComponents = trackingObject.GetComponent<Renderer>();
        colliderComponents = trackingObject.GetComponent<Collider>();
        if (rendererComponents != null)
            rendererComponents.enabled = false;
        if (colliderComponents != null)
            colliderComponents.enabled = false;
        trackingObject.SetActive(false);

        var childrenRenderer = trackingObject.GetComponentsInChildren<Renderer>(true);
        var childrenCollider = trackingObject.GetComponentsInChildren<Collider>(true);
        foreach (var component in childrenRenderer)
            component.enabled = false;
        foreach (var components in childrenCollider)
            components.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDetected(dt[0].detected, dt[1].detected, dt[2].detected))
        {
            trackingObject.SetActive(true);
            if (rendererComponents != null)
                rendererComponents.enabled = true;
            if (colliderComponents != null)
                colliderComponents.enabled = true;
            Vector3 vectorObj = positionOfObject(markers[0].transform.position, markers[1].transform.position, markers[2].transform.position);
            trackingObject.transform.position = vectorObj;
            //trackingObject.transform.LookAt(camera);
            Debug.Log("Moja pozycja: " + trackingObject.transform.position);
            var childrenRenderer = trackingObject.GetComponentsInChildren<Renderer>(true);
            var childrenCollider = trackingObject.GetComponentsInChildren<Collider>(true);
            foreach (var component in childrenRenderer)
                component.enabled = true;
            foreach (var components in childrenCollider)
                components.enabled = true;
            var AudioChild = trackingObject.GetComponentInChildren<AudioSource>(true);
            if (!AudioChild.isPlaying && !awaken)
                AudioChild.Play();
            awaken = true;
        }
        else
        {
            var AudioChild = trackingObject.GetComponentInChildren<AudioSource>(true);
            if (AudioChild.isPlaying && !awaken)
                AudioChild.Pause();
            awaken = false;
            var childrenRenderer = trackingObject.GetComponentsInChildren<Renderer>(true);
            var childrenCollider = trackingObject.GetComponentsInChildren<Collider>(true);
            foreach (var component in childrenRenderer)
                component.enabled = false;
            foreach (var components in childrenCollider)
                components.enabled = false;
            if (rendererComponents != null)
                rendererComponents.enabled = false;
            if (colliderComponents != null)
                colliderComponents.enabled = false;
            trackingObject.SetActive(false);
        }
    }

    bool isDetected(bool one, bool two, bool three)
    {
        if (one && two && three)
            return true;
        else
            return false;
    }

    Vector3 positionOfObject(Vector3 one, Vector3 two, Vector3 three)
    {
        float minX = 1000f, maxX = -1000f, minY = 1000f, maxY = -1000f, minZ = 1000f, maxZ = -1000f, x, y, z;
        minX = minX > one.x ? one.x : minX;
        minX = minX > two.x ? two.x : minX;
        minX = minX > three.x ? three.x : minX;

        minY = minY > one.y ? one.y : minY;
        minY = minY > two.y ? two.y : minY;
        minY = minY > three.y ? three.y : minY;

        minZ = minZ > one.z ? one.z : minZ;
        minZ = minZ > two.z ? two.z : minZ;
        minZ = minZ > three.z ? three.z : minZ;

        maxX = maxX < one.x ? one.x : maxX;
        maxX = maxX < two.x ? two.x : maxX;
        maxX = maxX < three.x ? three.x : maxX;

        maxY = maxY < one.y ? one.y : maxY;
        maxY = maxY < two.y ? two.y : maxY;
        maxY = maxY < three.y ? three.y : maxY;

        maxZ = maxZ < one.z ? one.z : maxZ;
        maxZ = maxZ < two.z ? two.z : maxZ;
        maxZ = maxZ < three.z ? three.z : maxZ;
        x = (minX + maxX) / 2;
        y = (minY + maxY) / 2;
        z = (minZ + maxZ) / 2;
        Vector3 returningVector = new Vector3(x, y, z);
        return returningVector;
    }
}
