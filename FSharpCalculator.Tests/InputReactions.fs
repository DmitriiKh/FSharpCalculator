module FSharpCalculator.Tests.InputReactions

open NUnit.Framework
open Calculator.Calculator
open Calculator.Mathematics
open Calculator.Keyboard

let Process (state : State, input : Key list) : State =
    List.fold(fun state key -> ProcessInput(key, state)) state input

[<SetUp>]
let Setup () =
    ()

[<Test>]
let One_OneOnDisplay () =
    let initState = InitState()

    let newState = ProcessInput(Key.D(One), initState)

    Assert.That(newState.Display, Is.EqualTo("1"))

[<Test>]
let OneZero_OneZeroOnDisplay () =
    let initState = InitState()
    let keysPressed = [ Key.D(One); Key.D(Zero) ]

    let newState = Process (initState, keysPressed)

    Assert.That(newState.Display, Is.EqualTo("10"))

[<Test>]
let Add_AddInPendingOperation () =
    let initState = InitState()
    let keysPressed = [ Key.O(Add) ]

    let newState = Process (initState, keysPressed)

    Assert.That(newState.PendingOperation, Is.EqualTo(Add))

[<Test>]
let OneZeroAddClear_ZeroOnDisplay_ZeroInMemory_NoneInPendingOperation () =
    let initState = InitState()
    let keysPressed = [ Key.D(One); Key.D(Zero); Key.O(Add); Key.C(Clear) ]

    let newState = Process (initState, keysPressed)

    Assert.That(newState.Display, Is.EqualTo("0"))   
    Assert.That(newState.Memory, Is.EqualTo(0))
    Assert.That(newState.PendingOperation, Is.EqualTo(None))

[<Test>]
let OneZeroAddFive_FiftingOnDisplay_ZeroInMemory_NoneInPendingOperation () =
    let initState = InitState()
    let keysPressed = [ Key.D(One); Key.D(Zero); Key.O(Add); Key.D(Five); Key.C(Calculate) ]

    let newState = Process (initState, keysPressed)

    Assert.That(newState.Display, Is.EqualTo("15"))   
    Assert.That(newState.Memory, Is.EqualTo(0))
    Assert.That(newState.PendingOperation, Is.EqualTo(None))

[<Test>]
let OneZeroSubtractSix_FourOnDisplay_ZeroInMemory_NoneInPendingOperation () =
    let initState = InitState()
    let keysPressed = [ Key.D(One); Key.D(Zero); Key.O(Subtract); Key.D(Six); Key.C(Calculate) ]

    let newState = Process (initState, keysPressed)

    Assert.That(newState.Display, Is.EqualTo("4"))   
    Assert.That(newState.Memory, Is.EqualTo(0))
    Assert.That(newState.PendingOperation, Is.EqualTo(None))

[<Test>]
let OneZeroMultiplyFive_FiftyOnDisplay_ZeroInMemory_NoneInPendingOperation () =
    let initState = InitState()
    let keysPressed = [ Key.D(One); Key.D(Zero); Key.O(Multiply); Key.D(Five); Key.C(Calculate) ]

    let newState = Process (initState, keysPressed)

    Assert.That(newState.Display, Is.EqualTo("50"))   
    Assert.That(newState.Memory, Is.EqualTo(0))
    Assert.That(newState.PendingOperation, Is.EqualTo(None))

[<Test>]
let OneZeroDivideFive_TwoOnDisplay_ZeroInMemory_NoneInPendingOperation () =
    let initState = InitState()
    let keysPressed = [ Key.D(One); Key.D(Zero); Key.O(Divide); Key.D(Five); Key.C(Calculate) ]

    let newState = Process (initState, keysPressed)

    Assert.That(newState.Display, Is.EqualTo("2"))   
    Assert.That(newState.Memory, Is.EqualTo(0))
    Assert.That(newState.PendingOperation, Is.EqualTo(None))
