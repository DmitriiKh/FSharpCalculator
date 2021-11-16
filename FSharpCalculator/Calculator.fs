namespace Calculator
open Mathematics
open Display
open Keyboard
open ALU

module Calculator = 

    type State = {
        Memory : int
        Display : string
        PendingOperation : MathOperation
        }

    let InitState() : State =
        { Display = "0"; PendingOperation = None; Memory = 0 }

    let MapAluError (aluError : AluError) : string =
        match aluError with
        | DivisionByZero -> "Division by zero"

    let RunOperation (current : State) : string =        
        ALU.RunOperation(float current.Memory, float current.Display, current.PendingOperation) |> string

    let AppendDigitToDisplay(digit : Digit, current : State) : State =
        { current with Display = AppendDigit(digit, current.Display) }

    let InsertOperation (operation : MathOperation, current : State) : State =
        let newMemory = current.Display |> int
        { PendingOperation = operation; Memory = newMemory; Display = "0" }

    let ExecuteCommand (command : Command, current : State) : State =
        match command with
        | Clear -> InitState()
        | Calculate -> { current with Display = RunOperation(current); PendingOperation = None; Memory = 0 }

    let ProcessInput (input : Key, current : State) : State =
        match input with 
        | D digit -> AppendDigitToDisplay(digit, current)
        | O operation -> InsertOperation(operation, current)
        | C command -> ExecuteCommand(command, current)
        | Unknown -> current
