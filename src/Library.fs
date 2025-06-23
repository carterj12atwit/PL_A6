namespace wit.comp3350

module a6 =
    /// TODO: Complete and document
    let sortCaseInsensitive (l: string list) =
        ["A"]

    /// TODO: Complete and document
    let sortPairs (l: (string*string) list) =
        [("A", "B")]        

    /// List of valid characters for Flipper
    let validChars = ['I'; 'O'; 'S'; 'H'; 'Z'; 'X'; 'N']
    
    /// TODO: Complete and document
    let rotatingLetters l =
        false
    
    /// TODO: Complete and document
    let flip grid command =
        let a, b, c, d = grid
        (a, b, c, d)

    /// TODO: Complete and document
    let flipAll commands =
        (1, 2, 3, 4)

    /// <summary>This type represents a binary tree. A binary tree can either be
    ///  - An empty node
    ///  - An inner node that also contains data
    /// </summary>
    type BinaryTree<'a> =
        | EmptyN
        | InnerN of BinaryTree<'a> * 'a * BinaryTree<'a>

    /// TODO: Complete and document
    let rec bstMin tr =
        None

    /// TODO: Complete and document
    let rec bstMax tr =
        None

    /// <summary>
    /// Checks if a value x is between the minimum and maximum values.
    /// The minimum and maximum can be None, which means no limit on that side.
    /// </summary>
    let between x (theMin, theMax) =
        false

    /// <summary> Checks if a binary tree is a valid Binary Search Tree (BST).</summary>
    /// <param name="tr">The binary tree to check</param>
    let isBST tr =
        /// TODO: Complete and document
        let rec helper tr theMin theMax =
            false

        // Leave this part alone
        helper tr None None
