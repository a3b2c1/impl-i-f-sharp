module Vertex

open PathAlgorithms

type Vertex(x_coord, y_coord, visited: bool, index) =
    member this.X_coord = x_coord
    member this.Y_coord = y_coord
    member thisV.Visited = visited
    member this.vertex_name = assign_name(index)


let generate_vertices() =
    let size = 5

    let rec generate_vertices(n) = 
        match n with 
        | 0 -> list.Empty @ [new Vertex(get_random_coord(), get_random_coord(), false, n)]
        | _ -> generate_vertices(n - 1) @ [new Vertex(get_random_coord(), get_random_coord(), false, n)]

    let vertices = generate_vertices(size-1)
    let playerVertice = new Vertex(get_random_coord(), get_random_coord(), true, -1)
    let generated_vertices = vertices @ [playerVertice]

    generated_vertices


        