// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open JosephsCanteenItems
open System

[<EntryPoint>]
let main argv = 


    printfn "Large chicken salad costs: %A DKK" (CalculateCanteenItemPrice ChickenSalad Large)
    printfn "Medium chocolate cake costs: %A DKK" (CalculateCanteenItemPrice ChocolateCake Medium)
    printfn "Small poultry sandwich costs: %A DKK" (CalculateCanteenItemPrice PoultrySandwich Small)

    Console.ReadLine()
    0 // return an integer exit code
