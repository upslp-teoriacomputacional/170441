# **COLLABORATOR**
This code was made with the help of [Vazquez Reyes Rodolfo Emanuel - 171072]( https://github.com/upslp-teoriacomputacional/171072)
# **How did you solve the problem?**
To commence the coding of the NFA I modified the transition table of the a*ba* because the original one will cause an infinite loop and result in an error called “Stack Overflow”. Once that is changed, the next step was to divide the transition table into two tables just as it is displayed below.
### Transition table 1
| ESTADO  | ""  | a  | b  |
| :------------: | :------------: | :------------: | :------------: |
|Q0|Q2|E|E|
|Q1|A|E|E|
|Q2|Q3|E|E|
|Q3|Q8|E|E|
|Q4|E|E|Q5|
|Q5|Q6|E|E|
|Q6|Q7|E|E|
|Q7|Q1|E|E|
|Q8|E|Q9|E|
|Q9|Q3|E|E|
|Q10|E|Q11|E|
|Q11|Q7|E|E|
### Transition table 2
| ESTADO  | ""  | a  | b  |
| :------------: | :------------: | :------------: | :------------: |
|Q0|E|E|E|
|Q1|E|E|E|
|Q2|Q8|E|E|
|Q3|Q4|E|E|
|Q4|E|E|E|
|Q5|E|E|E|
|Q6|Q10|E|E|
|Q7|Q10|E|E|
|Q8|E|E|E|
|Q9|E|E|E|
|Q10|E|E|E|
|Q11|E|E|E|
With this new transition table is possible to make a NFA that does not cycle infinitely. 
The NFA program was made using recursive functions that receives the initial node, a string and a “”. With these parameters, the code makes as many branches as possible that will result in a error state or accept state of the initial string.
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
This time, the main issue was the programming language itself. F# provides a good structure to build a comparison for the character, but in other aspects it will give you a hard time trying to find something more specific. For example, one of my problems was variables because I did no know that you could use mutable in order to alter the value assigned without having to declare it a second time.
# **Is it a NP or P complexity?**
Because the code includes a search, it indicates O(n²) for the complexity. Hence, the complexity will be polynomial.
