namespace Calculator
open Mathematics

module Display =

    let DigitToString (digit : Digit) : string =
        match digit with 
            | Zero -> "0"
            | One -> "1"
            | Two -> "2"
            | Three -> "3"
            | Four -> "4"
            | Five -> "5"
            | Six -> "6"
            | Seven -> "7"
            | Eight -> "8"
            | Nine -> "9"

    let ReFormat str =
        str |> int |> string

    let AppendDigit (digit : Digit, current : string) : string =
        current + DigitToString(digit) |> ReFormat
