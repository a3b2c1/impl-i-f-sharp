module Edge

open PathAlgorithms
open Vertice

type Edge(start_x, start_y, end_x, end_y, start_name, end_name) =
    member this.Distance = calculate_distance(start_x, start_y, end_x, end_y)
    member this.Start = start_name
    member this.End = end_name
    member this.RouteName = start_name + " to " + end_name


let calculate_vertice_distances(vertices: List<Vertice>) =
    let rec loop vertices =
        match vertices with
        |

