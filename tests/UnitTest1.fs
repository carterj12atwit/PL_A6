namespace wit.comp3350

open NUnit.Framework
open wit.comp3350.a6
open wit.comp3350.TestHelper

[<CancelAfter(400)>]
[<TestFixture>]
module tests =

    [<Test>]
    let testSortCaseInsensitive () =
        assertListEquals ["Alice"; "Bob"] (sortCaseInsensitive ["Alice"; "Bob"])
        assertListEquals ["alice"; "Bob"] (sortCaseInsensitive ["alice"; "Bob"])
        assertListEquals ["Alice"; "bob"] (sortCaseInsensitive ["Alice"; "bob"])

 
    [<Test>]
    let testSortPairs () =
        assertListEquals [("Alice", "Bob")] (sortPairs [("Alice", "Bob")])
        assertListEquals [("Alice", "Bob")] (sortPairs [("Bob", "Alice")])
        assertListEquals [("alice", "andrew"); ("Alice", "Bob")] (sortPairs [("Bob", "Alice"); ("andrew", "alice")])
        assertListEquals [("Alice", "Bob"); ("Charles", "Dennis")] (sortPairs [("Bob", "Alice"); ("Charles", "Dennis")])
        assertListEquals [("Alice", "Bob"); ("Charles", "Dennis"); ("Charles", "Emma")] (sortPairs
        [("Bob", "Alice"); ("Charles", "Dennis"); ("Emma", "Charles")])

    [<Test>]
    let testRotating () =
        assertTrue (rotatingLetters ['X'])
        assertTrue (rotatingLetters ['I'])
        assertTrue (rotatingLetters ['O'])
        assertTrue (rotatingLetters ['S'])
        assertTrue (rotatingLetters ['H'])
        assertFalse (rotatingLetters ['T'])
        assertTrue ("NOSHO".ToCharArray() |> Array.toList |> rotatingLetters)
        assertFalse ("ISHOT".ToCharArray() |> Array.toList |> rotatingLetters)

    [<Test>]
    let testFlipper () =
        assertEquals (3, 4, 1, 2) (flip (1, 2, 3, 4)'h')
        assertEquals (2, 1, 4, 3) (flip (1, 2, 3, 4) 'v')

        assertEquals (4, 3, 2, 1) (flipAll ['h'; 'v'])
        assertEquals (2, 1, 4, 3) (flipAll ['h'; 'v'; 'h'])
        assertEquals (1, 2, 3, 4) (flipAll ['h'; 'v'; 'v'; 'h'])

    // A single-entry tree with just 3
    let tree3 = InnerN (EmptyN, 3, EmptyN)

    // A tree with 3 as root, and 1, 6 on either side
    // i.e.   3
    //       1 6
    let tree316 = 
        let lf = InnerN (EmptyN, 1, EmptyN)
        let rt = InnerN (EmptyN, 6, EmptyN)
        InnerN (lf, 3, rt)

    // A tree with 3 as root, and 4, 6 on either side
    // i.e.   3
    //       4 6
    let tree346 = 
        let lf = InnerN (EmptyN, 4, EmptyN)
        let rt = InnerN (EmptyN, 6, EmptyN)
        InnerN (lf, 3, rt)

    // A tree with 3 as root, 5 and 6 on right, and 9 under 6
    // i.e.  3
    //         6
    //        5 9
    let tree3659 = 
        let c9 = InnerN (EmptyN, 9, EmptyN)
        let c5 = InnerN (EmptyN, 5, EmptyN)
        let c6 = InnerN (c5, 6, c9)
        InnerN (EmptyN, 3, c6)
        
    // A tree with 3 as root, 5 and 6 on right, and 9 under 6
    // i.e.  3
    //         6
    //        7 9
    let tree3679 = 
        let c9 = InnerN (EmptyN, 9, EmptyN)
        let c7 = InnerN (EmptyN, 7, EmptyN)
        let c6 = InnerN (c7, 6, c9)
        InnerN (EmptyN, 3, c6)

    // A tree with 3 as root, 5 and 6 on right, and 9 under 6
    // i.e.  3
    //     1
    //      2
    let tree123 = 
        let c2 = InnerN (EmptyN, 2, EmptyN)
        let c1 = InnerN (EmptyN, 1, c2)
        InnerN (c1, 3, EmptyN)

    // A tree with 3 as root, 5 and 6 on right, and 9 under 6
    // i.e.  3
    //     2
    //      1
    let tree213 = 
        let c1 = InnerN (EmptyN, 1, EmptyN)
        let c2 = InnerN (EmptyN, 2, c1)
        InnerN (c2, 3, EmptyN)

    // A tree with 3 as root, 5 and 6 on right, and 9 under 6
    // i.e.  3
    //     1   6
    //        5 9
    let tree13659 = 
        let c9 = InnerN (EmptyN, 9, EmptyN)
        let c5 = InnerN (EmptyN, 5, EmptyN)
        let c6 = InnerN (c5, 6, c9)
        let c1 = InnerN (EmptyN, 1, EmptyN)
        InnerN (c1, 3, c6)

    [<Test>]
    let testBstMin () =
        assertEquals (Some 3) (bstMin tree3)
        assertEquals (Some 1) (bstMin tree123)
        assertEquals (Some 1) (bstMin tree316)
        assertEquals (Some 3) (bstMin tree3659)
        assertEquals (Some 1) (bstMin tree13659)

        assertEquals None (bstMin EmptyN)

    [<Test>]
    let testBstMax () =
        assertEquals (Some 3) (bstMax tree3)
        assertEquals (Some 3) (bstMax tree123)
        assertEquals (Some 6) (bstMax tree316)
        assertEquals (Some 9) (bstMax tree3659)
        assertEquals (Some 9) (bstMax tree13659)

        assertEquals None (bstMax EmptyN)
    
    [<Test>]
    let testBetween () =
        assertTrue (between 5 (Some 3, Some 6))
        assertTrue (between 5 (Some 3, None))
        assertTrue (between 5 (None, Some 6))
        assertTrue (between 5 (None, None))

        assertFalse (between 2 (Some 3, Some 6))
        assertFalse (between 7 (Some 3, Some 6))
        assertFalse (between 2 (None, Some 1))
        assertFalse (between 7 (Some 8, None))

    [<Test>]
    let testIsBST () =
        assertTrue (isBST tree3)
        assertTrue (isBST tree123)
        assertTrue (isBST tree316)
        assertTrue (isBST tree3659)
        assertTrue (isBST tree13659)

        assertFalse (isBST tree213)
        assertFalse (isBST tree346)
        assertFalse (isBST tree3679)