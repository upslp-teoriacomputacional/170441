# **How did you solve the problem?**
The main goal was to analyze the string of characters and determine whether it was a palindrome or not. To solve these problems, we must prepare the string and convert it into a full string of upper words without spaces. This way, it will be easy to analyze each char. Once that is done, the next step consists of put every character that is between the start and the middle. Then, we just must compare backwards what we insert in the new array with what we have left in the string and if the characters match, then we delete it. If by the end, we have an empty array, then it means that the phrase was a palindrome. 
# **Commands for executing operations**
-   mutable The mutable keyword allows you to declare and assign values in a mutable variable.
-   <>      Returns true if the left side is not equal to the right side; otherwise, returns false. 
- try...with	Expression that is used for exception handling in the F# language.
- String.IndexOf Method	Reports the zero-based index of the first occurrence of a specified Unicode character or string within this instance. The method returns -1 if the character or string is not found in this instance.
- String.Substring Method	Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.
- Char.ToUpper Method	Converts the value of a Unicode character to its uppercase equivalent.
- String.Equals Method	Determines whether two String objects have the same value.
# **Problems and solutions during the work’s programming**
The only problem this time was to delete a char from the list. This part was program so that the array is casted to a string, where we delete the char and convert it again into a list of chars.

