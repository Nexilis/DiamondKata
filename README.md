Based on:
"F# property based testing introduction" by Mark Seemann on Pluralsight

The only valid inputs are A-Z

Examples:
input:
A
output:
A

input:
B
output:
 A
B B
 A

input:
C
output:
  A
 B B
C   C
 B B
  A

It's hard to implement using Example-Driven Development, used Property Based Testing instead.

Run using:
$ dotnet test
