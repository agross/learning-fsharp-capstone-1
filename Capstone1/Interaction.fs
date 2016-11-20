module Interaction
open System

let queryName =
  printfn "Please enter your name:"
  Console.ReadLine()

let rec queryDecimal(question) =
  printfn question
  let balance = Console.ReadLine()

  let result, balance = Decimal.TryParse(balance)
  if result = false then
    printfn "Huh?"
    queryDecimal question
  else
    balance

let rec nextAction() =
  printfn "Next action? (d)eposit, (w)ithdraw, E(x)it"
  let key = Console.ReadKey().KeyChar
  Console.WriteLine()

  match key with
  | 'd' -> Some ("Deposit requested", Operations.deposit)
  | 'w' -> Some ("Withdraw requested", Operations.withdraw)
  | 'x' -> None
  | _ ->
    printfn "Huh?"
    nextAction()
