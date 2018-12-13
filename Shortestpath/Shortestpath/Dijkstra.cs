using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace Shortestpath
{
    class Dijkstra
    {
        public List<Vertex> Vertices; 
        public List<Edge> edges;
        private List<Vertex> bkVertices;

        public Dijkstra()
        {
            Vertices = new List<Vertex>(); // Holds the Vertices
            edges = new List<Edge>(); // Holds the connections
            // Used to recovery the original vertices when the path is found
            bkVertices = new List<Vertex>(); 
        }

        // Dijkstra calculation algorithm
        public void Execute()
        {
            while (Vertices.Count > 0)
            {
                // For each smallset Vertex
                Vertex smallest = ExtractSmallest();

                // Get the adjacents
                List<Vertex> adjacentVertices = AdjacentRemainingVertices(smallest);

                // for each adjacent Vertex calculate the distance
                int size = adjacentVertices.Count;
                for (int i = 0; i < size; ++i)
                {
                    // Get the adjacent vertice of each vertice in the list
                    Vertex adjacent = adjacentVertices.ElementAt(i); 
                    // Calculate de the distance
                    float distance = Distance(smallest, adjacent) + smallest.distanceFromStart;

                    // Update the table if the distance is fewer than
                    if (distance < adjacent.distanceFromStart)
                    {
                        adjacent.distanceFromStart = distance;
                        adjacent.previous = smallest;
                    }
                }
            }
        }

        // Cerify if two Vertices are connecteds
        public bool Connected(Vertex origin, Vertex target)
        {
            int size = edges.Count;
            for (int i = 0; i < size; ++i)
            {
                Edge edge = edges.ElementAt(i);
                if (edge.Connects(origin, target)) return true;
            }
            return false;
        }

        // Create the Vertex and insert in the Vertex list
        public Vertex CreateVertex( string label, float x, float y)
        {
            Vertex tmp = new Vertex(label, x, y);
            Vertices.Add(tmp); // Add to list
            bkVertices.Add(tmp); // Add the same pointer to the backup list
            return tmp;
        }

        // Delete the Vertex
        public void DeleteVertex(Vertex delVertex)
        {
	        int size = Vertices.Count;
            // Look for the vertex in the list
	        for (int i=0; i<size; ++i)
	        {
		        Vertex current = Vertices.ElementAt(i); 
                if(current.Equals(delVertex)) // If equal remove it
                {
                    Vertices.RemoveAt(i);
                    bkVertices.RemoveAt(i);
                    return;
                }
            }
            // Del all connections that use that Vertex
            size = edges.Count;
            for (int i = 0; i < size; ++i)
            {
                Edge edge = edges.ElementAt(i);
                if (edge.Vertex1.Equals(delVertex) || edge.Vertex2.Equals(delVertex))
                {
                    edges.RemoveAt(i);
                    return;
                }
            }
            delVertex = null; // Work for garbage collection

        }

        // Create the connections and insert in the connection list
        public Edge CreateEdge(Vertex origin, Vertex target, float cost, float distance)
        {
            Edge tmp = new Edge(origin, target, distance, cost);
            edges.Add(tmp);
            return tmp;
        }

        // Delete a connection
        public void DeleteEdge(Vertex origin, Vertex target)
        {
            int size = edges.Count;
            for (int i = 0; i < size; ++i)
            {
                Edge edge = edges.ElementAt(i);
                if (edge.Vertex1.Equals(origin) && edge.Vertex2.Equals(target))
                {
                    edges.RemoveAt(i);
                    return;
                }
             }
        }

        // Find the Vertex with the smallest distance,
        // remove it, and return it.
        Vertex ExtractSmallest()
        {
	        int size = Vertices.Count;
	        if (size == 0) return null;
	        int smallestPosition = 0;
	        Vertex smallest = Vertices.ElementAt(0); 
	        for (int i=1; i<size; ++i)
	        {
		        Vertex current = Vertices.ElementAt(i); 
		        if (current.distanceFromStart < smallest.distanceFromStart)
		        {
			        smallest = current;
			        smallestPosition = i;
		        }
	        }
	        Vertices.RemoveAt(smallestPosition);
	        return smallest;
        }

        // Return all Vertices adjacent to 'Vertex' which are still
        // in the 'Vertices' collection.
        List<Vertex> AdjacentRemainingVertices(Vertex Vertex)
        {
            List<Vertex> adjacentVertices = new List<Vertex>();
            int size = edges.Count;
            for (int i = 0; i < size; ++i)
            {
                Edge edge = edges.ElementAt(i);
                Vertex adjacent = null;
                if (edge.Vertex1 == Vertex)
                {
                    adjacent = edge.Vertex2;
                }
                else if (edge.Vertex2 == Vertex)
                {
                    adjacent = edge.Vertex1;
                }
                if (adjacent != null && Contains(adjacent))
                {
                    adjacentVertices.Add(adjacent);
                }
            }
            return adjacentVertices;
        }

        // Return distance between two connected Vertices
        float Distance(Vertex Vertex1, Vertex Vertex2)
        {
            int size = edges.Count;
            for (int i = 0; i < size; ++i)
            {
                Edge edge = edges.ElementAt(i);
                if (edge.Connects(Vertex1, Vertex2))
                {
                    return edge.Distance * edge.Cost;
                }
            }
            return -1; // should never happen
        }

        // Does the 'Vertices' vector contain 'Vertex'
        bool Contains(Vertex Vertex)
        {
	        int size = Vertices.Count;
	        for(int i=0; i<size; ++i)
	        {
		        if (Vertex == Vertices.ElementAt(i))
		        {
			        return true;
		        }
	        }
	        return false;
        }

        // Get Vertex form the ID
        Vertex GetVertex(string id)
        {
            int size = Vertices.Count;
            for (int i = 0; i < size; ++i)
            {
                if (Vertices.ElementAt(i).id.Trim().ToUpper() == id.Trim().ToUpper())
                {
                    return Vertices.ElementAt(i);
                }
            }
            return null;
        }

        // PLot the path and create the report
        public string PrintShortestRouteTo(Vertex destination, System.Windows.Forms.PictureBox pictureBox1)
        {
            Vertex previous = destination;
            float x1, y1, x2, y2;
            x1 = y1 = x2 = y2 = -1;

            Pen pen = new Pen(Color.Yellow,3);
            Graphics objGraphics = pictureBox1.CreateGraphics();

            string output = "Distance from start: " + destination.distanceFromStart + Environment.NewLine;
            output = output + Environment.NewLine + "Path: " + Environment.NewLine;

            // For each two vertices draw the line
            // use x and y variables with -1 to hold while all points are not fullfilled
            while (previous != null)
            {
                // Get the coordinates
                if (x1 == -1 && y1 == -1)
                {
                    x1 = previous.x;
                    y1 = previous.y;
                }
                if (x2 == -1 && y2 == -1)
                {
                    x2 = previous.x;
                    y2 = previous.y;
                }

                // Path concactation
                output = output  + previous.id;
                if (previous.previous != null)
                    output = output + " <- ";

                // Trace when we have all points
                if(x1 != -1 && y1 != -1 && x2 != -1 && y2 != -1)
                {
                    // Draw
                    objGraphics.DrawLine(pen, x1+6, y1+6, x2, y2+6);
                    // Swap
                    x1 = x2;
                    y1 = y2;
                    x2 = -1; // Set up to get the next point
                    y2 = -1;
                }
                previous = previous.previous;
            }
            return output;
        }

        // Plot the vertices, edges and labels
        public void PrintVertices(System.Windows.Forms.PictureBox pictureBox1)
        {
            Graphics objGraphics = pictureBox1.CreateGraphics();
            Brush brush = new SolidBrush(Color.Red);
            Pen pen = new Pen(Color.DarkBlue,3);
            Font font = new Font("Tahoma", 14);

            // Scan all vetices
            // Draw lines
            int size = edges.Count;
            for (int i = 0; i < size; ++i)
            {
                Edge edge = edges.ElementAt(i);
                objGraphics.DrawLine(pen, edge.Vertex1.x+6, edge.Vertex1.y+6, edge.Vertex2.x, edge.Vertex2.y+6);

                // Draw the associated cost
                float meanx, meany;
                float x,y;
                meanx = Math.Abs(edge.Vertex2.x - edge.Vertex1.x) / 2;
                meany = Math.Abs(edge.Vertex2.y - edge.Vertex1.y) / 2;
                if (edge.Vertex2.x < edge.Vertex1.x)
                    x = edge.Vertex2.x + meanx;
                else
                    x = edge.Vertex1.x + meanx;

                if (edge.Vertex2.y < edge.Vertex1.y)
                    y = edge.Vertex2.y + meany;
                else
                    y = edge.Vertex1.y + meany;
                objGraphics.DrawString(edge.Cost.ToString(), font, Brushes.Goldenrod, x,y);
            }

            // Draw points labels
            size = Vertices.Count;
            for (int i = 0; i < size; ++i)
            {
                Vertex Vertex = Vertices.ElementAt(i);
                objGraphics.FillEllipse(brush, Vertex.x, Vertex.y, 12, 12);
                objGraphics.DrawString(Vertex.id, font, Brushes.Black, Vertex.x, Vertex.y+15);
            }
        }

        // Save the vetices and edges (connections)
        public void SaveVertices(string filename)
        {
            int size = Vertices.Count;
    
            // create a writer and open the file
            TextWriter tw = new StreamWriter(filename);
	        
            // First save the vertices
            for (int i=0; i<size; i++)
            {   
	            Vertex current = Vertices.ElementAt(i); 

                // write a line with the current Vertex
                tw.WriteLine("Vertex");
                tw.WriteLine(current.id+" "+current.x+" "+current.y);
            }

            // Second Save edges
            size = edges.Count;
            for (int i = 0; i < size; ++i)
            {
                Edge edge = edges.ElementAt(i);
                tw.WriteLine("CONNECTION");
                tw.WriteLine(edge.Vertex1.id+" "+edge.Vertex2.id+" "+edge.Cost+" "+edge.Distance);
            }
            // close the stream
            tw.Close();

        }

        public void LoadVertices(string filename)
        {
            // create reader & open file
            StreamReader tr = new StreamReader(filename);

            // read a line of text
            string line = tr.ReadLine();
            while(line != null)
            {
                if(line.ToUpper().Trim() == "VERTEX")
                {
                    line = tr.ReadLine();
                    string[] tokens = line.Split(' ');
                    Vertex tmp = CreateVertex(tokens[0], float.Parse(tokens[1]), float.Parse(tokens[2]));
                }
                else if(line.ToUpper().Trim() == "CONNECTION")
                {
                    line = tr.ReadLine();
                    string[] tokens = line.Split(' ');
                    Vertex origin, destination;
                    origin = GetVertex(tokens[0]);
                    destination = GetVertex(tokens[1]);
                    if (origin == null || destination == null)
                    {
                        throw new System.InvalidOperationException("Vertex files Bad format");
                    }

                    Edge e1 = CreateEdge(origin, destination, float.Parse(tokens[2]), float.Parse(tokens[3]) );

                }
                else{
                    throw new System.InvalidOperationException("Vertex files Bad format");
                }

                line = tr.ReadLine();
            }

            // close the stream
            tr.Close();
        }

        // Re-set the elements up to the inital state
        public void Renew()
        {
            for (int i = 0; i < bkVertices.Count; ++i)
            {
                bkVertices[i].distanceFromStart = int.MaxValue;
                bkVertices.ElementAt(i).previous = null;
                Vertices.Add(bkVertices.ElementAt(i));
            }
        }

        // Release everything
        public void Dispose()
        {

            for (int i = 0; i < bkVertices.Count; ++i)
                bkVertices[i]= null;

            for (int i = 0; i < edges.Count; ++i)
                edges[i] = null;

            Vertices.RemoveAll(delegate(Vertex n)
            {
                return true;
            });

            bkVertices.RemoveAll(delegate(Vertex n)
            {
                return true;
            });

            edges.RemoveAll(delegate(Edge ed)
            {
                return true;
            });
        }

            
     }
  }

