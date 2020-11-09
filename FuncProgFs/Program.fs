// Learn more about F# at http://fsharp.org

open System
open Vertex
open Edge
open PathfindingDijkstra

[<EntryPoint>]
let main argv =
    //let list = generate_vertices()
    //let edges = calculate_edges(list)

    let n = DijkstrasAlgo()
    printfn "Shortest route distance: %f" n

    0 // return an integer exit code
