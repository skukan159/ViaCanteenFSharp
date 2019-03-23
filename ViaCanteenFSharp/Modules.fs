module Modules

(*
Design a type to represent different types of food in the canteen.
Implement price calculation
Have at least:
3 kinds of salad
3 kinds of sandwitch
3 kinds of cake
Hints: You will need to define the data type for the food amd size(union)
and the content (for instance a bag/wrap) with the size (record).
You will also need to define
the price calculation function that uses pattern matching.
*)
type SaladType = Greek | Bulgarian | Croatian 
type SandwichType = Chicken | Salmon | Vegan
type CakeType = Chocolate | RakijaCake | VeganCake
//type TypeOfFood = | SaladType | SandwichType | CakeType
type Size = | Small | Medium | Large
//type CanteenItem = {ItemType:TypeOfFood; ItemSize:Size; }
type CanteenItem = | Salad of SaladType * Size 
                   | Sandwich of SandwichType * Size
                   | Cake of CakeType * Size

            

let CalculateItemBySize (size : Size) =
    match size with
    | Small -> 1.0
    | Medium -> 2.0
    | Large -> 2.5
    | _ -> failwith "Size not recognized"

let CalculateSaladByType (saladType : SaladType) =
    match saladType with
    | Greek -> 10.0
    | Bulgarian -> 2.0
    | Croatian -> 50.0
    | _ -> failwith "Type not recognized"

let CalculateSandwichByType (sandwichType : SandwichType) =
    match sandwichType with
    | Chicken -> 15.0
    | Salmon -> 20.0
    | Vegan -> 50.0
    | _ -> failwith "Type not recognized"

let CalculateCakeByType (cakeType : CakeType) =
    match cakeType with
    | Chocolate -> 30.0
    | RakijaCake -> 5.0
    | VeganCake -> 50.0
    | _ -> failwith "Type not recognized"

let GetItemPrice (item : CanteenItem) =
    match item with
    | Salad(saladType,saladSize) -> CalculateSaladByType saladType * CalculateItemBySize saladSize 
    | Sandwich(sandwichType,sandwichSize) -> CalculateSandwichByType sandwichType *  CalculateItemBySize sandwichSize 
    | Cake(cakeType,cakeSize) -> CalculateCakeByType cakeType * CalculateItemBySize cakeSize
    | _ -> failwith "Item not recognized" 


let testItem1 = Salad(SaladType.Bulgarian, Size.Large)
let testItem2 = Cake(CakeType.VeganCake, Size.Medium)
let testItem3 = Sandwich(SandwichType.Chicken, Size.Small)




