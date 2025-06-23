# Take-home Assignment 6

## Introduction

This assignment provides a comprehensive overview of various F# programming constructs.

## Background

### Running Tests

There are two ways of running the tests. First is to use the terminal (menubar "Terminal" > "New
Terminal" and use the following command:

    dotnet test

Another is to install the "Ionide for F#" extension in Visual Studio Code. In the "Testing" tab
(looks like a chemistry flask), you should be able to run the tests there.

### Grading

There are unit tests provided. Make sure you pass all the unit tests *completely*. Partially passing
a test will not be enough.

In addition to correctness, I will be grading the following items:

- Documentation: Every function should have the correct style of documentation (see below for
  details).
- Code Formatting: The code should be "neat" with proper indentation
- Code Quality: I may deduct points for "quality" but you can earn them back after fixing them.

### Documentation

Every function should have a corresponding XML documentation.

    /// <summary>Returns the absolute value of a number</summary>
    /// <param name="x">The number</param>
    /// <returns>The absolute value </returns>
    let abs x =
        if (x >= 0) then x
        else (-x)

## Your Tasks

### sortCaseInsensitive

This function takes a list that contains names (strings). Your task is to sort the list.

For example,

|        List    |      Returns   |
| -------------- | -------------- |
| "Bob"; "Alice" | "Alice"; "Bob" |
| "Bob"; "alice" | "alice"; "Bob" |
| "alice"; "Bob" | "alice"; "Bob" |

Hint: To compare strings alphabetically in a case-insensitive manner, the `ToUpper` method. This is
actually a C# method under the covers, so you need to call it like so:

     let x = "abc"
     let x2 = x.ToUpper() // returns "ABC"

### sortPairs

This function takes a list that contains a pair of names (strings). Your task is to sort the list so
that a user can visually inspect the list for any mistakes.

You should convert each pair so that the first string contains the name that alphabetically
(case-insensitive) comes first. *Then* sort each pair so that the pairs are sorted alphabetially as
well.

For example,

|                       List             |                    Returns            |
| -------------------------------------- | ------------------------------------- |
|         ("Bob", "Alice")               |          ("Alice", "Bob")             |
| ("Bob", "Alice"); ("andrew", "alice")  | ("alice"; "andrew"); ("Alice", "Bob") |

### Rotating Letters

This assignment is adapted from the Canadian Computing Competition: 2013 Stage 1, Junior #2
[[1]](#ref1).

An artist wants to construct a sign whose letters will rotate freely in the breeze. In order to do
this, she must only use letters that are not changed by rotation of 180 degrees: I, O, S, H, Z, X,
and N. The list of valid chars are specified in the list `validChars`.

Your task is to write a function that reads a word and determines whether the word can be used on
the sign. This function takes a list of chars and returns `true` if all the characters are "valid",
i.e. within the list of valid characters. You may use the variable `validChars` that is defined in
Library.fs.

Hint. In the [List module](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html), there is a function that returns true if all items return true.


### Flipper

This assignment is adapted from the Canadian Computing Competition: 2019 Stage 1, Senior #1 [[2]](#ref2).

You are trying to pass the time while at the optometrist. You notice there is a grid of four numbers:

    1 2
    3 4

You see lots of mirrors and lenses at the optometrist, and wonder how flipping the grid horizontally
or vertically would change the grid.

Specifically, a "horizontal" flip (across the horizontal centre line) would take the original grid
of four numbers and result in:

    3 4
    1 2

A "vertical" flip (across the vertical centre line) would take the original grid of four numbers and
result in:

    2 1
    4 3

Your task is to determine the final orientation of the numbers in the grid after a sequence of
horizontal and vertical flips. The grid is provided as a 4-tuple starting from the upper left,
moving right, then down. So the grid:

    1 2
    3 4

will be provided as `(1, 2, 3, 4)`.

The `flipAll` function takes in a list of commands, given as either `'h'` or `'v'`, for horizontal or
vertical.

The `flip` function takes a tuple of 4 integers and a command to flip it horizontally or vertially.

The `flipAll` takes a list of commands and starting from `(1, 2, 3, 4)` and flip the grid according to the
command.

Hint: Since each command takes an existing grid and returns a new version of that, it should use the
`List.fold` function.

### Binary Search Trees

In the following functions, you will work with binary trees and potentially binary search trees
(BSTs). A BST is a binary tree where every item in the left subtree is smaller than the value of the
node, and every item in the right subtree is larger than the node.


For example, this is a valid BST:

      3
     / \
    1   6
       / \
      4   9

For example, but this is not, because of the 2:

      3
     / \
    1   6
       / \
      2   9

If you need help, please consult the following page: [Algorithms. Chapter 3.2. Binary Search Tree](https://algs4.cs.princeton.edu/32bst/)

### bstMin/bstMax

These functions take a binary search tree and returns the smallest value or the largest value,
respectively. Since we need to be able to handle cases where the tree is empty, return the value as
an option type (Some or None).

You may assume that the tree is always a valid BST for bstMin and bstMax.

### isBST

You are to return true if the given binary tree is a binary search tree. This is a fairly complex
problem, with multiple helper functions that you need to first implement.

#### between

This helper function takes a number and two optional numbers, and returns true if the number is
between the two. If a boundary is `None`, treat it as always true.

| x |   min  |   max  | returns |
| - | ------ | ------ | ------- |
| 3 | Some 1 | Some 5 |   true  |
| 3 |   None | Some 5 |   true  | 
| 3 | Some 1 |   None |   true  |
| 3 |   None |   None |   true  |
| 0 | Some 1 | Some 5 |   false |
| 6 | Some 1 | Some 5 |   false |

#### helper

This recursive helper function checks if the tree is a binary search tree, *and* all the values are
within the two ranges. The ranges are provided as optionals, so you should use the `between`
function that you just completed.

This function returns true if:

- The node value x is between the two ranges
- All values in the left subtree is smaller than x
- All values in the right subtree is larger than x

(BTW, what should an empty tree return?).

If you need hints, you may consult the following Java code from Algorithms, 4th Edition, by
Sedgewick, Robert [[3]](#ref3).


## References

- <a id="ref1">[1]</a>https://dmoj.ca/problem/ccc13j2
- <a id="ref2">[2]</a>https://dmoj.ca/problem/ccc19s1
- <a id="ref3">[3]</a>https://algs4.cs.princeton.edu/32bst/BST.java.html
