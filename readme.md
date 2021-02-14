# Technical Test - Simon Ng

The entry points to the API are in the controller files, I was unable to finish to "expert" mode of exercise 3, but have left some notes as to the possible solutions.

## Exercise 1

GET /api/answers

## Exercise 2

GET /api/sort

Sort option
- Low
- High
- Ascending
- Descending
- Recommended

## Exercise 3

POST /api/trolleyTotal

Current this calls the /trolleyCalculator resource provided, there is a sandbox project which I did some snippets of code to try to solve it. I have not been able to solve it, my notes are in the notes section below

### Sample Request
```json
{
  "products": [
    {
      "name": "Test Product A",
      "price": 10
    }
  ],
  "specials": [
    {
      "quantities": [
        {
          "name": "Test Product A",
          "quantity": 3
        }
      ],
      "total": 29
    },
    {
      "quantities": [
        {
          "name": "Test Product A",
          "quantity": 5
        }
      ],
      "total": 48
    }
  ],
  "quantities": [
    {
      "name": "string",
      "quantity": 11
    }
  ]
}
```

### Exercise 3 Notes
My current thinking is that (using the above request as an example) is that I need to work out all the combinations of the specials to find out how to make the quantity of the purchase.

So in the above the customer wants to buy 11 of the product A. The available prices are:
- 1 pack @ $10 each
- 3 pack @ $29
- 5 pack @ $46

The steps (I'm not sure if this will work is)

#### Step 1 - Work out all possible combinations

The possible combination of purchase are
- 11 x 1 pack
- 2 x 5 pack & 1 x 1 pack
- 2 x 3 pack & 1 x 5 pack
- 2 x 3 pack & 5 x 1 pack
...

See Step 1 notes below

#### Step 2 - Calculate price for each combo

- 11 x 1 pack > 11 * $10 = $110
- 2 x 5 pack & 1 x 1 pack > 2 * $46 + 1 x 10 = $102
- 2 x 3 pack & 1 x 5 pack > 2 * 29 + 1 x 48 = $106 
- 2 x 3 pack & 5 x 1 pack > 2 * 29 + 5 x 11 = $110
...

#### Step 3 - Return the cheapest combination

#### Step 1 Notes
That is the main challenge I ran into, I'm looking online and into recursive functions. I'm researching onto recursive functions, as it is a problem of how to sum an array of numbers to a given result (allowing reuse).

I've stole some online to play around with, I've been more focus on debugging and understanding how they work in a sandbox environment, to play around it, and try to make my own simple recursive functions to learn how to understand them.