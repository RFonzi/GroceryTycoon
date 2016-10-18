using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Timestamp {
    int time = 0;

    public Timestamp() {
        this.time = (int)System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1)).TotalSeconds;
    }

    public Timestamp(Timestamp timestamp) {
        this.time = timestamp.getTime();
    }

    public int getTime() {
        return this.time;
    }

    public void fastForward(int seconds) {
        
    }
}

