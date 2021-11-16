open Calculator
open System

[<EntryPoint>]
let main argv =
    let mutable state = Calculator.InitState()
    let mutable key = ""
    while true do
        printfn "%s" state.Display
        key <- Console.ReadKey().KeyChar.ToString()
        Console.Clear()
        state <- Calculator.ProcessInput(Calculator.Keyboard.StringToDigit(key), state)
    0