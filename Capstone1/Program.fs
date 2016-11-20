open System
open Domain
open Interaction
open Reporting

[<EntryPoint>]
let main argv =
  let name = queryName
  let balance = queryDecimal "Please enter the opening balance:"

  let customer = { Customer.Name = name }
  let mutable account = { Id = Guid.NewGuid()
                          Owner = customer
                          Balance = balance }

  account |> report "Opened account" |> ignore

  while true do
    let action  = nextAction()
    match action with
    | Some (op, action) ->
      let amount = queryDecimal "How much?"
      account <- account |> action amount  |> report op
    | _ -> Environment.Exit(0)

  0
