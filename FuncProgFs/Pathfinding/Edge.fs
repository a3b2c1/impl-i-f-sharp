module Edge

open PathAlgorithms
open Vertex

type Edge(start_x, start_y, end_x, end_y, start_name, end_name) =
    member this.Distance = calculate_distance(start_x, start_y, end_x, end_y)
    member this.Start = start_name
    member this.End = end_name
    member this.RouteName = start_name + " to " + end_name


let calculate_edges(vertices) =
    vertices
