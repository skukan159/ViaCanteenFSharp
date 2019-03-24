// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open Modules
open System

[<EntryPoint>]
let main argv = 


    printfn "%F" (CalculateCanteenItemPrice salad)
    printfn "%F" (CalculateCanteenItemPrice cake)
    printfn "%F" (CalculateCanteenItemPrice sandwich)

    Console.ReadLine()
    0 // return an integer exit code
