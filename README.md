#Implementation of DiamondKata

Based on: **"F# property based testing introduction"** by Mark Seemann on Pluralsight

The only valid inputs are letters `A-Z`

Examples:

**1.**

input:

`A`

output:

`A`

**2.**

input:

`B`

output:

```
 A
B B
 A
```

**3.**

input:

`C`

output:

```
  A
 B B
C   C
 B B
  A
```

It's hard to implement using Example-Driven Development, so Property Based Testing is used instead.

Run using:
`$ dotnet test`
