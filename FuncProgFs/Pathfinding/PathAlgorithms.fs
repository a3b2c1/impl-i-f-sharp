module PathAlgorithms

let assign_name(index) =
    let alphabeth = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    match index with 
    | -1 -> "Player"
    | index -> alphabeth.[index].ToString()

let calculate_distance(start_x: double, start_y: double, end_x: double, end_y: double) =
    let a = start_x - end_x
    let b = start_y - end_y
    let c_2 = a ** 2.0 + b ** 2.0
    sqrt c_2
