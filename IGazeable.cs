using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGazeable {
    void OnStartGazed();
    void OnStayGazed();
    void OnStopGazed();
}
