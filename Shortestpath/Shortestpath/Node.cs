using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shortestpath
{
    public class Vertex
    {
        public string id; // Label
        public Vertex previous; // Pointer to next vertex
        public float x; // Horizontal location on screen
        public float y; // Vertical location on screeb
        public float distanceFromStart;
    
        // Construcutor
        public Vertex(string id, float x, float y)
        {
            this.id = id;
            this.previous = null;
            this.x = x;
            this.y = y;
            this.distanceFromStart = Int32.MaxValue;
        }

        public override string ToString()
        {
            return (id + " - " + x.ToString() + " - " + y.ToString());
        }



    }
}
