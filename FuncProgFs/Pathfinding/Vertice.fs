module Vertice

open System.Collections.Generic
open PathAlgorithms

type Vertice(x_coord, y_coord, visited: bool, index) =
    member this.X_coord = x_coord
    member this.Y_coord = y_coord
    member thisV.Visited = visited
    member this.vertice_name = assign_name(index)


let generate_vertices() =
    let array_size = 4
    let rand = System.Random()
    let generated_vertices = new List<Vertice>()
    

    for i = 0 to array_size do 
        let x_coord = rand.NextDouble() * 99.0
        let y_coord = rand.NextDouble() * 99.0
        let vertice = new Vertice(x_coord, y_coord, false, i)
         
        generated_vertices.Add(vertice)

    let x_coord = rand.NextDouble() * 99.0;
    let y_coord = rand.NextDouble() * 99.0;

    let playerVertice = new Vertice(x_coord, y_coord, true, -1)
    generated_vertices.Add(playerVertice);
    
    generated_vertices
        