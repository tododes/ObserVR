using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGazerObserver {
    void updateOnStartGaze(Gazer gazer);
    void updateOnStopGaze(Gazer gazer);
}
