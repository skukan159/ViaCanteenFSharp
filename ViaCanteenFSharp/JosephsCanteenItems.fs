﻿module JosephsCanteenItems


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

type ItemType = ChickenSalad | DanishSalad | VegetarianSalad | PoultrySandwich | FishSandwich | VeganSandwich | ChocolateCake | StrawberryCake | IceCreamCake
type Size = | Small | Medium | Large

type CanteenItem = Item of ItemType * Size

let calculateItemPriceBySize (size : Size) =
    match size with
    | Small -> 0.5
    | Medium -> 1.0
    | Large -> 1.5
    | _ -> failwith "Size not recognized"

let calculateSaladPrice (saladType : ItemType) =
    match saladType with
    | ChickenSalad -> 20.0
    | DanishSalad -> 25.0
    | VegetarianSalad -> 30.0
    | _ -> failwith "Salad not recognized"

let calculateSandwichPrice (sandwichType : ItemType) =
    match sandwichType with
    | PoultrySandwich -> 30.0

    | FishSandwich -> 25.0
    | VeganSandwich -> 30.0
    | _ -> failwith "Sandwich not recognized"

let calculateCakePrice (cakeType : ItemType) =
    match cakeType with
    | ChocolateCake -> 15.0
    | StrawberryCake -> 10.0
    | IceCreamCake -> 20.0
    | _ -> failwith "Cake not recognized"

let calculateCanteenItemPrice (canteenItemType : ItemType) (canteenItemSize : Size) =
    
    match canteenItemType with
    | ChickenSalad | DanishSalad |VegetarianSalad -> calculateSaladPrice canteenItemType * calculateItemPriceBySize canteenItemSize 
    | PoultrySandwich | FishSandwich |VeganSandwich -> calculateSandwichPrice canteenItemType *  calculateItemPriceBySize canteenItemSize 
    | ChocolateCake | StrawberryCake | IceCreamCake -> calculateCakePrice canteenItemType * calculateItemPriceBySize canteenItemSize
    | _ -> failwith "Canteen item not recognized" 


let largeChicken = ChickenSalad, Large
let mediumChocolate = ChocolateCake, Medium
let smallPoultry = PoultrySandwich, Small


let testVegetarian = VegetarianSalad, Large

calculateCanteenItemPrice VegetarianSalad Large