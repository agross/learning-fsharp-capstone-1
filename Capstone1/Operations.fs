module Operations
open Domain

let deposit amount account =
  { account with Balance = account.Balance + amount }

let withdraw amount account =
  let newBalance = account.Balance - amount
  if newBalance < 0m then
    account
  else
    { account with Balance = newBalance }