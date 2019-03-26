module CanteenItems

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

type SaladType = Chicken | Danish | Vegetarian 
type SandwichType = Poultry | Fish | Vegan
type CakeType = Chocolate | Strawberry | IceCream
type Size = | Small | Medium | Large
type CanteenItem = | Salad of SaladType * Size 
                   | Sandwich of SandwichType * Size
                   | Cake of CakeType * Size

let calculateItemPriceBySize (size : Size) =
    match size with
    | Small -> 0.5
    | Medium -> 1.0
    | Large -> 1.5
    | _ -> failwith "Size not recognized"

let calculateSaladPrice (saladType : SaladType) =
    match saladType with
    | Chicken -> 20.0
    | Danish -> 25.0
    | Vegetarian -> 30.0
    | _ -> failwith "Salad not recognized"

let calculateSandwichPrice (sandwichType : SandwichType) =
    match sandwichType with
    | Poultry -> 30.0
    | Fish -> 25.0
    | Vegan -> 30.0
    | _ -> failwith "Sandwich not recognized"

let calculateCakePrice (cakeType : CakeType) =
    match cakeType with
    | Chocolate -> 15.0
    | Strawberry -> 10.0
    | IceCream -> 20.0
    | _ -> failwith "Cake not recognized"

let calculateCanteenItemPrice (canteenItem : CanteenItem) =
    match canteenItem with
    | Salad(saladType, saladSize) -> calculateSaladPrice saladType * calculateItemPriceBySize saladSize 
    | Sandwich (sandwichType, sandwichSize) -> calculateSandwichPrice sandwichType *  calculateItemPriceBySize sandwichSize 
    | Cake (cakeType, cakeSize) -> calculateCakePrice cakeType * calculateItemPriceBySize cakeSize
    | _ -> failwith "Canteen item not recognized" 


let largeChickenSalad = Salad(Chicken, Large)
let mediumChocolateCake = Cake(Chocolate, Medium)
let smallPoultrySandwich = Sandwich(Poultry, Small)

//Write this in teh F# interactive
let testLargeChicken = calculateCanteenItemPrice (Salad(Chicken, Large))
let testMediumChocolate = calculateCanteenItemPrice mediumChocolateCake
let testSmallPoultry = calculateCanteenItemPrice smallPoultrySandwich