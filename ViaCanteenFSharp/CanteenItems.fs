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

type ItemType = Chicken | Danish | Vegetarian | Poultry | Fish | Vegan | Chocolate | Strawberry | IceCream
type Size = | Small | Medium | Large

type CanteenItem = Item of ItemType * Size

let CalculateItemPriceBySize (size : Size) =
    match size with
    | Small -> 0.5
    | Medium -> 1.0
    | Large -> 1.5
    | _ -> failwith "Size not recognized"

let CalculateSaladPrice (saladType : ItemType) =
    match saladType with
    | Chicken -> 20.0
    | Danish -> 25.0
    | Vegetarian -> 30.0
    | _ -> failwith "Salad not recognized"

let CalculateSandwichPrice (sandwichType : ItemType) =
    match sandwichType with
    | Poultry -> 30.0
    | Fish -> 25.0
    | Vegan -> 30.0
    | _ -> failwith "Sandwich not recognized"

let CalculateCakePrice (cakeType : ItemType) =
    match cakeType with
    | Chocolate -> 15.0
    | Strawberry -> 10.0
    | IceCream -> 20.0
    | _ -> failwith "Cake not recognized"

let CalculateCanteenItemPrice (canteenItemType : ItemType) (canteenItemSize : Size) =
    
    match canteenItemType with
    | Chicken | Danish | Vegetarian -> CalculateSaladPrice canteenItemType * CalculateItemPriceBySize canteenItemSize 
    | Poultry | Fish | Vegan -> CalculateSandwichPrice canteenItemType *  CalculateItemPriceBySize canteenItemSize 
    | Chocolate | Strawberry | IceCream -> CalculateCakePrice canteenItemType * CalculateItemPriceBySize canteenItemSize
    | _ -> failwith "Canteen item not recognized" 


let largeChicken = Chicken, Large
let mediumChocolate = Chocolate, Medium
let smallPoultry = Poultry, Small
let largeVegetarian = Vegetarian, Large

CalculateCanteenItemPrice Chicken, Large
CalculateCanteenItemPrice Chocolate, Medium
CalculateCanteenItemPrice Vegetarian Large
CalculateCanteenItemPrice Poultry, Small
CalculateCanteenItemPrice Vegetarian, Large