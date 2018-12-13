## Introducing to Graphs

Graphs as restructures like trees or you prefer tress are a kind of graph, perhaps the main difference is the usage, in computer programming graphs are used in different way to trees. Binary trees are good to search for data and insert new elements, the edges usually represents quick ways to reach the nodes in all levels. The graphs, on the other hand, usually are modeled to solver physical problem; a classical example is node is a graph which represents cities and the edges which represents routes between the cities.

Just to use the same nomenclature, nodes in graphs are called vertices or one vertex, yet

###### Adjacency
When two vertices are connected by a single edge we say they are adjacent.

###### Path
A path is just a sequence of edges.

###### Non-Directed Graphs
That means that the edges don't have a direction; you can go either way on them.

###### Directed Graphs
You can go in only one direction along an edge. This one are

###### Weighted Graphs
In some case you can give a weight to the edges. This number can represent physical distances between two vertices, or the time it takes to gets from one vertex to another or even the cost to travel between these two nodes.

## Representing Graphs

###### Vertices
In most situations a vertex represents some real-world object, for example if it represents a city it may need store the name of the city. Thus, it is convenient tp represent a vertex by object of a vertex class.

    public class Vertex {

        public string id; // Label
    
        public float x; // Horizontal location on screen

        public float y; // Vertical location on screen

        // Construcutor

        public Vertex(string id, float x, float y)

        {

            this.id = id;
    
            this.x = x;
    
            this.y = y;
        
        }
  
        Public override string ToString() {
  
            return (id + " - " + x.ToString() + " - " + y.ToString());
    
        }
  
    }

Vertex object can be places in an array; however in our case I will use a list collection. The List<T> class has properties very similar to C# arrays, one key advantage is it can grow and shrink as the number of stored objects changes. The List<T> class is contained with the System.Collections.Generic namespace. The declaration would be something like this:

    public List<Vertex> Vertices;

###### Edges

As you noticed graphs doesn't have a rigid organization as a tree. In a binary tree each node has a maximum two children, a graph each vertex can be connected to several other vertices. To model this free-form organization we need a different approach, two methods are commonly used for graphs: the adjacency matrix and the adjacency list. I chosen the second option for obvious reasons, it is simply dynamic. An easy way to implement an edge object is to model a class that the two vertices and the distance and additional cost between them. You can understand the cost as heuristic information, for example the one edge which represents an avenue with tree traffic lights can have a cost great than another one representing a parallel avenue with the same distance however with only one traffic light.

    public class Edge

    {
        public Vertex Vertex1; // Vertex one
    
        public Vertex Vertex2; // Vertex two
    
        public float Distance; // DIstance or similar
    
        public float Cost; // Cost or multiplier factor
    
        // Constructor
    
        public Edge(Vertex Vertex1, Vertex Vertex2, float distance, float cost)
    
        {
    
            this.Vertex1 = Vertex1;
        
            this.Vertex2 = Vertex2;
        
            this.Distance = distance;
        
            this.Cost = cost;
        
        }
    
    }

###### Adjacency List

The list in adjacency list is nothing more than a linked list. Each vertex element contains the pointer for the first element to its adjacency list.

Don't confuse the adjacency list with paths. The adjacency list shows which vertices are adjacent to—that is, one edge away

From—a given vertex, not paths from vertex to vertex.

## The Shortest Problem
One of the most common operations performed on weighted and directed graphs is finding the shortest path from one vertex to another. Consider the following example: For vacation, you are going to travel to 10 major league baseball cities to watch games over a two-week period. You want to minimize the number of miles you have to drive to visit all 10 cities using a shortest-path algorithm. Another shortest-path problem involves creating a network of computers, where the cost could be the time to transmit between two computers or the cost of establishing and maintaining the connection. A shortest-path algorithm can determine the most effective way you can build the network.

###### Dijkstra's Algorithm
One of the most famous algorithms in computer science is Dijkstra's algorithm for determining the shortest path of a weighted graph, named for the late computer scientist Edsger Dijkstra, who invented the algorithm in the late 1950s.

Dijkstra's algorithm finds the shortest path from any specified vertex to any other vertex and, it turns out, to all the other vertices in the graph. It does this by using what is commonly termed a greedy strategy or algorithm. A greedy algorithm breaks a problem into pieces, or stages, determining the best solution at each stage, with each sub-solution contributing to the final solution. A classic example of a greedy algorithm is making change with coins. For example, if you buy something at the store for 74 cents using a dollar bill, the cashier, if he or she is using a greedy algorithm and wants to minimize the number of coins returned, will return to you a quarter and a penny. Of course, there are other solutions to making change for 26 cents, but a quarter and a penny is the optimal solution.

We use Dijkstra's algorithm by creating a table to store known distances from the starting vertex to the other vertices in the graph. Each vertex adjacent to the original vertex is visited, and the table is updated with information about the weight of the adjacent edge. If a distance between two vertices is known, but a shorter distance is discovered by visiting a new vertex, that information is changed in the table. The table is also updated by indicating which vertex leads to the shortest path.

Below I show how a Dikstra's algorithm class would be implemented.

    class Dijkstra
    
    {
        public List<Vertex> Vertices;
        
        public List<Edge> edges;
        
        // Constructor
        
        public Dijkstra()
        
        {
            
            Vertices = new List<Vertex>(); // Holds the Vertices
      
            edges = new List<Edge>(); // Holds the connections
            
        }
        
        // Dijkstra calculation algorithm
        
        public void Execute(
        
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
            
                Vertex adjacent = adjacentVertices.ElementAt(i);
                
                float distance = Distance(smallest, adjacent) + smallest.distanceFromStart;
                
                if (distance < adjacent.distanceFromStart)
                
                {
                
                    adjacent.distanceFromStart = distance;
                    
                    adjacent.previous = smallest;
                    
                 }
                 
             }
             
         }
         
     }

     …

## MyApplication
Sometime ago I built an application which implements the Dijkstra's algorithm. I used Visual Studio 2008 and of course C#. I implemented with the classes I explained before, actually this application was the reason for this posting. I tried to become it user-friendly and coder-friendly as well. If this blog has made sense for you and you do need application like that I think would be a good idea you take a look the application running and its code behind.


