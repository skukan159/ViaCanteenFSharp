// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open Modules
open System

[<EntryPoint>]
let main argv = 


    printfn "%F" (GetItemPrice testItem1)
    printfn "%F" (GetItemPrice testItem2)
    printfn "%F" (GetItemPrice testItem3)

    Console.ReadLine()
    0 // return an integer exit code
