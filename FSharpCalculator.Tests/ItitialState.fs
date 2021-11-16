module FSharpCalculator.Tests.InitialState

open NUnit.Framework
open Calculator
open Mathematics

[<SetUp>]
let Setup () =
    ()

[<Test>]
let EmptyDisplay () =
    Assert.That(Calculator.InitState().Display, Is.EqualTo("0"))

[<Test>]
let NoPendingOperation () =
    Assert.That(Calculator.InitState().PendingOperation, Is.EqualTo(None))

[<Test>]
let ZeroInMemory () =
    Assert.That(Calculator.InitState().Memory, Is.EqualTo(0))
