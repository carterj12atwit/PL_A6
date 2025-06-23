namespace wit.comp3350

open NUnit.Framework
open System.Diagnostics

/// <summary>This module contains some helper functions to make asserts easier to read</summary>
module TestHelper =

    /// <summary>Assert if the value is true, fail if false</summary>
    [<StackTraceHidden>]
    let assertTrue (actual: 'a) =
        Assert.That(actual, Is.True)

    /// <summary>Assert if the value is false, fail if true</summary>
    [<StackTraceHidden>]
    let assertFalse (actual: 'a) =
        Assert.That(actual, Is.False)

    /// <summary>Assert if the value is equal, fail if not</summary>
    [<StackTraceHidden>]
    let assertEquals (expected: 'a) (actual: 'a) =
        // NOTE: NUnit swaps this order
        Assert.That(actual, Is.EqualTo(expected))

    /// <summary>Assert if the list is empty, fail if not</summary>
    [<StackTraceHidden>]
    let assertListEmpty (actual: 'a list) =
        Assert.That(actual, Is.Empty)

    /// <summary>Assert if the list contains the same values, fail if not</summary>
    [<StackTraceHidden>]
    let assertListEquals (expected: 'a list) (actual: 'a list) =
        let e = expected |> List.map string |> String.concat ", "
        let a = actual |> List.map string |> String.concat ", "
        Assert.That(actual, Is.EqualTo(expected), $"Expected: [{e}]\n     But was:  [{a}]")

    /// <summary>Assert if the option is None, fail if not</summary>
    [<StackTraceHidden>]
    let assertIsNone (actual: 'a option) =
        match actual with
        | None -> Assert.That(actual, Is.EqualTo(None))
        | Some ac -> Assert.Fail($"Expected: None\n     But was: Some {ac}")

    /// <summary>Assert if the option contains the same value, fail if not</summary>
    [<StackTraceHidden>]
    let assertIsSome (expected: 'a) (actual: 'a option) =
        match actual with
        | None -> Assert.Fail($"Expected: Some {expected}\n     But was: None")
        | Some ac -> Assert.That(ac, Is.EqualTo(expected))
