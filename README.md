# Pixel-Guy

A little zelda-like game I have been working on myself using C# in Unity3D.


The core code is part of my own (sorta) framework which handles the following... 

An input system which takes advantage of the bridge pattern to allow ease of changing input buttons and switches between input from 
a controller to keyboard and vise versa. 
A tiled map generator which reads JSON data and generates a map Object with a mesh and UVmapping.
Base Entity class for any general entity that exsists in our game. This can be inherited by more complex entities in our game such as player and enemies. 
Item base classes. Any item in our game will inherite from our basse item class. 
Messaging system which takes advantage if the observer pattern so objects can call eachother without having a direct relationship set up.
Simple enemy AI state machine. 
