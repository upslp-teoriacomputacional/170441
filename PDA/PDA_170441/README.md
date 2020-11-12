# **How did you solve the problem?**
First, we need to convert the context free language to a pushdown automaton. We were given the Grammar “(anbn|n>=0)” that produces (P=> S = aSb | ab). 
Once that is done, the next was to modify the NFA program so that it can accept a PDA form of automaton. The program is already in a general form, so we only have to modify the transition table and create a new table of rules for the PDA.
### Transition table
| ESTADO  | ""  | a  | b  |
| :------------: | :------------: | :------------: | :------------: |
|Q0|Q1|E|E|
|Q1|Q1,Q2|Q1|Q1|
|Q2|A|E|E|

### Rules for the PDA table
| ESTADO  | ""  | a  | b  |
| :------------: | :------------: | :------------: | :------------: |
|Q0|Z;SZ|E|E|
|Q1|S;e-Z;e|S;SX|X;e|
|Q2|Q8|E|E|

With this tables, we can achieve both forms of accepting a PDA, by End of State or Empty Stack. But, for this program, it will always have to accept it by both.
# **Commands for executing operations**
-   mutable The mutable keyword allows you to declare and assign values in a mutable variable.
-   match       Pattern matching is used for control flow.
-   Console.ReadLine()  Reads the next line of characters from the standard input stream.
-   <>      Returns true if the left side is not equal to the right side; otherwise, returns false. 
- try...with	Expression that is used for exception handling in the F# language.
- String.Remove Method	Returns a new string in which a specified number of characters from the current string are deleted.
- String.IndexOf Method	Reports the zero-based index of the first occurrence of a specified Unicode character or string within this instance. The method returns -1 if the character or string is not found in this instance.
- String.Substring Method	Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.
# **Problems and solutions during the work’s programming**
The main issue was how to take both forms, so that the result will have to accept by End of state and Empty stack. This was solved with the code below:
```f#
for rule in pdaRules.[nodo].[0].Split '|' do
                try
                    if ((stack.Substring(0,1)) = (rule.Substring(0,1)) ) then
                        if (rule.Substring(rule.Length-1).Equals("e")) then
                            stack <- stack.Substring(1)
                        else
                            stack <- stack.Substring(1)
                            stack <- rule.Substring(rule.IndexOf(";") + 1) + stack
                        st <- state + "(q" + string nodo + ", '':''->" + "q" + string tabla.[nodo].[0] + "),"
                        if (tabla2.[nodo].[0] <> -1) then
                            st <- state + "(q" + string nodo + ", '':''->" + "q" + string tabla2.[nodo].[0] + "),"
                            node (tabla2.[nodo].[0]) (cad) (st) (histStack) (stack)
                        node (tabla.[nodo].[0]) (cad) (st) (histStack) (stack)
                with
                    | :? System.ArgumentOutOfRangeException -> ()
            //  If the node has a second state then it calls to another recursive node
```
It accesses to the table of rules and obtains each rule for the letter. Then, it analyzes the first letter of the input string and the first letter of the stack and depending of the rule, it could execute a push or pop operation.
# **Is it a NP or P complexity?**
Because the code includes a search, it indicates O(n²) for the complexity. Hence, the complexity will be polynomial.

