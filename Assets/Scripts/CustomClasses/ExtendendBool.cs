
using UnityEngine;

[System.Serializable]
public class ExtendedBool {


    private bool state_;

    public bool state {
        get {return state_;}
        set {
            if(this.state_ != value) {
                lastChange = Time.timeSinceLevelLoad;
            } 

            state_ = value; 
        }
    }

    private float lastChange_;

    public float lastChange {
        get {return lastChange_;}
        private set{lastChange_ = value;}
    }

    public ExtendedBool() {

      this.state_ = false;
    }

    public ExtendedBool(bool state) {

      this.state_ = state;
    }
}
