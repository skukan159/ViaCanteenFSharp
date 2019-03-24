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

type Salad = Chicken | Danish | Swedish 
type Sandwich = Poultry | Fish | Vegetarian
type Cake = Chocolate | Strawberry | IceCream
type Size = | Small | Medium | Large
type CanteenItem = | Salad of Salad * Size 
                   | Sandwich of Sandwich * Size
                   | Cake of Cake * Size

let CalculateItemPriceBySize (size : Size) =
    match size with
    | Small -> 0.5
    | Medium -> 1.0
    | Large -> 1.5
    | _ -> failwith "Size not recognized"

let CalculateSaladPrice (salad : Salad) =
    match salad with
    | Chicken -> 20.0
    | Danish -> 25.0
    | Swedish -> 30.0
    | _ -> failwith "Salad not recognized"

let CalculateSandwichPrice (sandwich : Sandwich) =
    match sandwich with
    | Poultry -> 30.0
    | Fish -> 25.0
    | Vegetarian -> 30.0
    | _ -> failwith "Sandwich not recognized"

let CalculateCakePrice (cake : Cake) =
    match cake with
    | Chocolate -> 15.0
    | Strawberry -> 10.0
    | IceCream -> 20.0
    | _ -> failwith "Cake not recognized"

let CalculateCanteenItemPrice (canteenItem : CanteenItem) =
    match canteenItem with
    | Salad(saladType, saladSize) -> CalculateSaladPrice saladType * CalculateItemPriceBySize saladSize 
    | Sandwich (sandwichType, sandwichSize) -> CalculateSandwichPrice sandwichType *  CalculateItemPriceBySize sandwichSize 
    | Cake (cakeType, cakeSize) -> CalculateCakePrice cakeType * CalculateItemPriceBySize cakeSize
    | _ -> failwith "Canteen item not recognized" 


let salad = Salad(Salad.Chicken, Size.Large)
let cake = Cake(Cake.Chocolate, Size.Medium)
let sandwich = Sandwich(Sandwich.Poultry, Size.Small)




