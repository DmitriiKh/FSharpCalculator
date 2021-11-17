namespace Calculator
open Mathematics
open Microsoft.FSharp.Core.LanguagePrimitives

module ALU =

    type AluError = DivisionByZero

    let inline RunOperation a b operation =
        match operation with
        | Add -> Ok (a + b)
        | Subtract -> Ok (a - b)
        | Multiply -> Ok (a * b)
        | Divide -> if b = GenericZero then Error DivisionByZero else Ok (a / b)
        | None -> Ok b
