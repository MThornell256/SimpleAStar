# SimpleAStar
A simple implementation of A* Designed in a way that it can be easily dropped into any existing project with little effort.

# How To Use
There are 2 easy steps to interate this into your existing code.

Step 1:
Create A Class That Extends AStarSolver; you will have to implement a function that defines the heristic for the solver. Most of the time if you are using this for pathfinding you will be using some distence equation.

Step 2:
Define a class that represents your nodes and have it inherit from IAStarNode; This will enfore you to create an array of AStarConnection. An AStarConnection defines a node that you can travel to from the current node.
Each Connection has a Traversal Cost(float) And The Node It Travels To

The code is pretty heavily commented, see tests as an exmple of use.
