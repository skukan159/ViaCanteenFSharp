// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open Modules
open System

[<EntryPoint>]
let main argv = 


    printfn "%F" (CalculateCanteenItemPrice largeChickenSalad)
    printfn "%F" (CalculateCanteenItemPrice mediumChocolateCake)
    printfn "%F" (CalculateCanteenItemPrice smallPoultrySandwich)

    Console.ReadLine()
    0 // return an integer exit code
