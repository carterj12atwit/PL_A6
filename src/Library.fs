namespace wit.comp3350

module a6 =
    /// <summary> sorts the contents of a string list in a case insensitive manner </summary>
    /// <params> a string list </params>
    /// <returns> the sorted string list </returns>
    let sortCaseInsensitive (l: string list) =
        l |> List.sortBy (fun x -> x.ToUpper())

    /// <summary> sorts the names within a tuple pair, and then sorts the tuples themselves </summary>
    /// <params> a list of string pairs </params>
    /// <returns> an internally and externally sorted string pair list </returns>
    let sortPairs (l: (string*string) list) =
        l 
        |> List.map (fun (x, y) -> if x.ToUpper() <= y.ToUpper() then x, y else y, x)
        |> List.sortBy (fun (x, y) -> x.ToUpper(), y.ToUpper())  

    /// List of valid characters for Flipper
    let validChars = ['I'; 'O'; 'S'; 'H'; 'Z'; 'X'; 'N']
    
    /// <summary> determines if the word could theoretically be flipped and still be legible </summary>
    /// <params> a list of valid characters and  a list of chars in the word </params>
    /// <returns> a boolean value indicating whether the word is valid </returns>
    let rotatingLetters l =
        l |> List.forall (fun x -> List.contains x validChars)
    
    /// <summary> function that can flip a grid of numbers either horizontally and vertically </summary>
    /// <params> a grid and an either horizontal or vertical command </params>
    /// <returns> either a horizontally or vertically flipped version of the given grid </returns>
    let flip grid command =
        match grid, command with
        | (a, b, c, d), 'h' -> c, d, a, b
        | (a, b, c, d), 'v' -> b, a, d, c 

    /// <summary> function that calls the horizontal and vertical flips </summary>
    /// <params> a list of commands </params>
    /// <returns> the final list after all horizontal/vertical flips have been executed </returns>
    let flipAll commands =
        List.fold flip (1, 2, 3, 4) commands

    /// <summary>This type represents a binary tree. A binary tree can either be
    ///  - An empty node
    ///  - An inner node that also contains data
    /// </summary>
    type BinaryTree<'a> =
        | EmptyN
        | InnerN of BinaryTree<'a> * 'a * BinaryTree<'a>

    /// <summary> finds the lowest value in a binary search tree </summary>
    /// <params> a binary search tree </params>
    /// <returns> the lowest value in the binary search tree </returns>
    let rec bstMin tr =
        match tr with
        | EmptyN -> None
        | InnerN (lt, x, rt) -> if lt = EmptyN then Some x else bstMin lt


    /// <summary> finds the biggest value in a binary search tree </summary>
    /// <params> a binary search tree </params>
    /// <returns> the biggest value in the binary search tree </returns>
    let rec bstMax tr =
        match tr with
        | EmptyN -> None
        | InnerN (lt, x, rt) -> if rt = EmptyN then Some x else bstMax rt

    /// <summary>
    /// Checks if a value x is between the minimum and maximum values.
    /// The minimum and maximum can be None, which means no limit on that side.
    /// </summary>
    let between x (theMin, theMax) =
        match theMin, theMax with
        | None, None -> true
        | Some y, None -> if x > y then true else false
        | None, Some y -> if x < y then true else false
        | Some y, Some z -> if x > y && x < z then true else false


    /// <summary> Checks if a binary tree is a valid Binary Search Tree (BST).</summary>
    /// <param name="tr">The binary tree to check</param>
    let isBST tr =
        /// <summary> determines whether a binary search tree is a valid one or not </summary>
        /// <params> a binary search tree and a minimum and maximum value </params>
        /// <returns> a boolean indicating whether the binary search tree is valid or not </returns>
        let rec helper tr theMin theMax =
            match tr with
            | EmptyN -> true
            | InnerN (lt, x, rt) ->
                match lt, rt with
                | EmptyN, EmptyN -> true
                | InnerN (lt0, y, rt0), EmptyN -> 
                    if between x (Some y, None)
                    then helper lt theMin theMax 
                    else false
                | EmptyN, InnerN (lt0, y, rt0) -> 
                    if between x (None, Some y)
                    then helper rt theMin theMax 
                    else false  
                | InnerN (lt0, y, rt0), InnerN (lt1, z, rt1) -> 
                    if between x (Some y, Some z) then
                        helper lt theMin theMax
                        helper rt theMin theMax
                    else false

        // Leave this part alone
        helper tr None None
