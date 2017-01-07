using System;

//Color record for drawing
  public struct color : ICloneable {
    public int red;
    public int green;
    public int blue;
    public int alpha;
    
  //It must be clonable, see ColorHandler class
    public object Clone(){
      return this.MemberwiseClone();
    }
  }