module Edge

open PathAlgorithms
open Vertex

type Edge(distance, start_name, end_name, end_visited) =
    member this.Distance = distance
    member this.Start = start_name
    member this.End = end_name
    member this.RouteName = start_name + " to " + end_name
    member this.EndVisited = end_visited




let calculate_edges(vertices) =
    let rec create_edges(vertex : Vertex, lst : list<Vertex>) : list<Edge> =
        match lst with 
        | [] -> []
        | head::tail when head.vertex_name = vertex.vertex_name || head.vertex_name = "Player" -> create_edges(vertex, tail)  
        | head::tail -> create_edges(vertex, tail) @ [new Edge(calculate_distance(vertex.X_coord, vertex.Y_coord, head.X_coord, head.Y_coord), vertex.vertex_name, head.vertex_name, false)] 

    let rec loop_vertices(unvisited_vertices: list<Vertex>) : list<Edge> =
        match unvisited_vertices with 
        | [] -> []
        | head::tail -> loop_vertices(tail) @ create_edges(head, vertices)

    let edges = loop_vertices(vertices)

    edges

let edges_merge_sort_test(unsorted_edges : list<Edge>) =
    let middle_index = unsorted_edges.Length / 2

    let rec sort_edges(index) : list<Edge> =
        match index with
        | 1 -> []
        | _ -> sort_edges(unsorted_edges.Length / 2)

    unsorted_edges

    