using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gazer : MonoBehaviour {

    private Ray ray;
    private RaycastHit hit;
    private LayerMask gazeMask;
    private IGazeable iGaze, prevIGaze;
    private List<IGazerObserver> observers = new List<IGazerObserver>();

    // Use this for initialization
    protected void Start () {
        ray = new Ray();
        gazeMask = LayerMask.GetMask("Gazeable");

	}

    void NotifyAllObserversOnStartGaze(){
        for(int i = 0; i < observers.Count; i++){
            observers[i].updateOnStartGaze(this);
        }
    }

    void NotifyAllObserversOnStopGaze(){
        for (int i = 0; i < observers.Count; i++){
            observers[i].updateOnStopGaze(this);
        }
    }

    void RegisterObserver(IGazerObserver observer){
        observers.Add(observer);
    }

    // Update is called once per frame
    protected void FixedUpdate () {
        ray.origin = transform.position;
        ray.direction = transform.forward;
        RaycastProcess();
	}

    protected void RaycastProcess(){
        if (Physics.Raycast(ray, out hit, 30f, gazeMask))
        {
            iGaze = (IGazeable)hit.collider.GetComponent<MonoBehaviour>();
            if (!prevIGaze.Equals(iGaze) || prevIGaze.Equals(null)){
                NotifyAllObserversOnStartGaze();
                iGaze.OnStartGazed();
                prevIGaze = iGaze;
            }
            iGaze.OnStayGazed();
        }
        else
        {
            NotifyAllObserversOnStopGaze();
            iGaze.OnStopGazed();
            iGaze = null;
        }
    }
}
