# **How did you solve the problem?**
The problem consisted of a translating the python algorithm to a F# algorithm. Initially, I just rewrite all sentences in a F# syntax. After that, some lines marked an error, hence I redesigned some lines of code that resulted correct after running the program.
The main problem of the implementation was a function that does not exist in F#, which is explained below.
# **Commands for executing operations**
-   mutable The mutable keyword allows you to declare and assign values in a mutable variable.
-   match       Pattern matching is used for control flow.
-   <>      Returns true if the left side is not equal to the right side; otherwise, returns false. 
- try...with	Expression that is used for exception handling in the F# language.
- String.IndexOf Method	Reports the zero-based index of the first occurrence of a specified Unicode character or string within this instance. The method returns -1 if the character or string is not found in this instance.
- String.Substring Method	Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.
- Char.IsLetter	Indicates whether a Unicode character is categorized as a Unicode letter.
- Char.ToUpper Method	Converts the value of a Unicode character to its uppercase equivalent.
- Regex.Match	Searches an input string for a substring that matches a regular expression pattern and returns the first occurrence as a single Match object.
- String.Equals Method	Determines whether two String objects have the same value.
# **Problems and solutions during the work’s programming**
One of the main issues was the isalnum function. In python, this function is already implemented but in F#, I had to make it inside the code otherwise it will cause an error because it does not exist. The code checks if a character is a letter or a number which will match the function isalnum that checks if a character is alphanumeric.
# **Is it a NP or P complexity?**
Because the code includes a match, it indicates O(n²) for the complexity. Hence, the complexity will be polynomial.
