namespace Calculator
open Mathematics

module Keyboard =

    type Command = Clear | Calculate
    type Key = D of Digit | O of MathOperation | C of Command | Unknown

    let StringToDigit (str : string) : Key =
        match str with 
            | "0" -> Key.D(Zero)
            | "1" -> Key.D(One)
            | "2" -> Key.D(Two)
            | "3" -> Key.D(Three)
            | "4" -> Key.D(Four)
            | "5" -> Key.D(Five)
            | "6" -> Key.D(Six)
            | "7" -> Key.D(Seven)
            | "8" -> Key.D(Eight)
            | "9" -> Key.D(Nine)
            | "+" -> Key.O(Add)
            | "-" -> Key.O(Subtract)
            | "*" -> Key.O(Multiply)
            | "/" -> Key.O(Divide)
            | "c" -> Key.C(Clear)
            | "=" -> Key.C(Calculate)
            | _ -> Unknown

