module Vertex

open PathAlgorithms

type Vertex(x_coord, y_coord, index) =
    member this.X_coord = x_coord
    member this.Y_coord = y_coord
    member this.vertex_name = assign_name(index)


let generate_vertices() =
    let rec generate_vertices(n) = 
        match n with 
        | 0 -> [] @ [new Vertex(get_random_coord(), get_random_coord(), n)]
        | _ -> generate_vertices(n - 1) @ [new Vertex(get_random_coord(), get_random_coord(), n)]
        
    let size = 5
    let vertices = generate_vertices(size-1)
    let playerVertice = new Vertex(get_random_coord(), get_random_coord(), -1)
    let generated_vertices = playerVertice :: vertices

    generated_vertices


        