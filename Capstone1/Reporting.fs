module Reporting

let report action account =
  printfn "%s: %A" action account
  account
