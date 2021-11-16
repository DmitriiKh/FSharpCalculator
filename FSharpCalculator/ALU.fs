namespace Calculator
open Mathematics

module ALU =

    type AluError = DivisionByZero

    let inline RunOperation (a, b, operation : MathOperation) =
        match operation with
        | Add -> a + b
        | Subtract -> a - b
        | Multiply -> a * b
        | Divide -> a / b
        | None -> b
