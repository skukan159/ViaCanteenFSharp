// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open CanteenItems
open System

[<EntryPoint>]
let main argv = 

    printfn "Large chicken salad costs: %A DKK" testLargeChicken
    printfn "Medium chocolate cake costs: %A DKK" testMediumChocolate
    printfn "Small poultry sandwich costs: %A DKK" testSmallPoultry

    Console.ReadLine()
    0 // return an integer exit code
