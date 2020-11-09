module PathfindingDijkstra

open System
open Vertex
open Edge

let DijkstrasAlgo() =
    let rec mark_visited_vertex(edge : Edge, lst : list<Edge>) : list<Edge> =
        match lst with
        | [] -> []
        | head::tail when edge.End = head.End || edge.Start = head.Start -> mark_visited_vertex(edge, tail) @ [new Edge(head.Distance, head.Start, head.End, true)]
        | head::tail -> mark_visited_vertex(edge, tail) @ [head]
          
    let rec unvisited_vertex_exists(lst : list<Edge>) =
        match lst with
        | [] -> false
        | head::tail when head.EndVisited = false -> true
        | head::tail -> unvisited_vertex_exists(tail)

        
    let rec find_start_locations(vertex_name : string, lst : list<Edge>) =
        match lst with 
        | [] -> []
        | head::tail when head.Start = vertex_name -> head :: find_start_locations(vertex_name, tail)
        | head:: tail -> find_start_locations(vertex_name, tail)
    
    let find_shortest_edge(from_player : list<Edge>) =
        let found_shortest_edge = 
            from_player
            |> Seq.filter(fun e -> not e.EndVisited)
            |> Seq.minBy(fun e -> e.Distance)
        
        found_shortest_edge

    let rec calculate_shortest_route(from_player : list<Edge>, lst : list<Edge>) =
        let shortest_edge = find_shortest_edge(from_player)
        let lstt = mark_visited_vertex(shortest_edge, lst)
        let next_vertex = find_start_locations(shortest_edge.End, lstt)

        match lst with 
        | [] -> []
        | head::tail when unvisited_vertex_exists(lstt) -> shortest_edge :: calculate_shortest_route(next_vertex, lstt)
        | head::tail -> shortest_edge :: []


    let rec shortest_edge_name(from_player : Edge, lst: list<Edge>) =
        match lst with 
        | [] -> []
        | head::tail when from_player.Distance > head.Distance && head.EndVisited = false -> shortest_edge_name(head, tail)
        | head::tail -> shortest_edge_name(from_player, tail)
    
    let reverse_list(lst) = 
        let rec loop(lstt) =
            function
            | [] -> lst
            | head::tail -> loop(head::lstt) tail
        loop [] lst

    let rec get_route_name(lst : list<Edge>) =
        match lst with
        | [] -> "Player"
        | head::tail -> get_route_name(tail) 

    let rec count_shortest_route(lst : list<Edge>) =
        match lst with
        | [] -> 0.0
        | head::tail -> head.Distance + count_shortest_route(tail)

    let edges = calculate_edges(generate_vertices())
    let v = generate_vertices()

    let sorte_edges =
        edges
        |> List.sortBy (fun e -> e.RouteName)

    let from_player = find_start_locations("Player", edges)
    let shortest_route = calculate_shortest_route(from_player, edges)
    
    
    let reversed_list = reverse_list(shortest_route)
    let route_name = get_route_name(reversed_list)
    let shortest_distance = count_shortest_route(shortest_route);

    shortest_distance

