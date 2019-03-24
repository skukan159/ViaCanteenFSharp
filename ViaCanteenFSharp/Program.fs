// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open CanteenItems
open System

[<EntryPoint>]
let main argv = 


    printfn "Large chicken salad costs: %A" (CalculateCanteenItemPrice largeChickenSalad)
    printfn "Medium chocolate cake costs: %A" (CalculateCanteenItemPrice mediumChocolateCake)
    printfn "Small poultry sandwich costs: %A" (CalculateCanteenItemPrice smallPoultrySandwich)

    Console.ReadLine()
    0 // return an integer exit code
