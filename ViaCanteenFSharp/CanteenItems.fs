module CanteenItems

(* Phase 1:
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
(* Phase 2:
Implement a function to order food items from(or leave comment to)
The canteen in a concurrent way.
Hints: The OrderFood message processing should use the price
calculation function that returns the price of the specified
food item multiplied by the given quantity:

F# has both shared memory concurrency and message passing concurrency.
As discussed during the lessons, F# has a build in mailbox processor
concept that is popular in Erlang language. This built in mailbox
processor is defined in the F# library as a type called MailboxProcessor
and usually reffered to as an Agent or Actor

type CanteenMessage = | OrderFood of AllFood * int // food qty
                      | LeaveAComment of string //"Delicious salad"

Implement a canteen agent(call it canteenFoodAgent) that receives a 
CanteenMessage declared above and prints a message with the price of
the food item to the sender(for OrderFood). Further, a second message
LeaveAComment of string (ie. "Comment") to leave a string comment to
the canteen operators. Acknowledge the comments with your own ideas.

Example: > canteenFoodAgent.Post (OrderFood(ViaSalad {Food=Vegie;Size=Large}, 4));;
Should give for instance: > Please pay DKK128.0 for your order of 4 ViaSalad.Thanks!
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

//Write this in the F# interactive
let testLargeChicken = calculateCanteenItemPrice (Salad(Chicken, Large))
let testMediumChocolate = calculateCanteenItemPrice (Cake(Chocolate, Medium))
let testSmallPoultry = calculateCanteenItemPrice (Sandwich(Poultry, Small))





type CanteenMessage = | OrderFood of CanteenItem * int 
                      | LeaveAComment of string 

let printCanteenItem (canteenItem : CanteenItem) =
    match canteenItem with
    | Salad (itemType, _ ) -> itemType.ToString() + " Salad"
    | Sandwich(itemType, _ ) -> itemType.ToString() + " Sandwich"
    | Cake (itemType, _ )->  itemType.ToString() + " Cake"
    | _ -> failwith "Invalid canteen item type"


let processFoodOrder item amount =
    let itemName = printCanteenItem item
    let totalPrice = calculateCanteenItemPrice item * amount
    let msg = "Please pay " + totalPrice.ToString() + " DKK for your order of " + amount.ToString() + " " + itemName + ". Thank you!"
    msg

let processComment comment =
    let msg = "Your comment was: " + comment + ". Thank you!"
    msg

let processMessage message =
    match message with
    | OrderFood (item, amount) -> processFoodOrder item (float amount)
    | LeaveAComment (comment) -> processComment comment
    | _ -> failwith "Invalid message request"


let canteenFoodAgent = new MailboxProcessor<CanteenMessage>(fun inbox ->
    let rec loop =
        async { let! msg = inbox.Receive()
                printfn "%s" (processMessage msg)
                return! loop
              }
    loop)

canteenFoodAgent.Start()

let canteenItem1 = Salad(Chicken, Large)
let canteenItem2 = Cake(Chocolate, Medium)
let canteenItem3 = Sandwich(Poultry, Small)

let comment1 = "This place is digusting"
let comment2 = "I like it but would prefer more vegan products"
let comment3 = "It has very cheap prices. Good good for students."


canteenFoodAgent.Post (OrderFood (canteenItem1, 4))
canteenFoodAgent.Post (OrderFood (canteenItem2, 2))
canteenFoodAgent.Post (OrderFood (canteenItem3, 10))

canteenFoodAgent.Post (LeaveAComment (comment1))
canteenFoodAgent.Post (LeaveAComment (comment2))
canteenFoodAgent.Post (LeaveAComment (comment3))