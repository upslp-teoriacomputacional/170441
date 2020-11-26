# **How did you solve the problem?**
To solve the problem, it is necessary that we translate all the python code into f sharp code. This was an issue, because the original code uses function that we do not have in f#. After that was done, I just add the MT rules so once I executed it, the output was exactly the MT for multiplying two unary numbers. 
# **Commands for executing operations**
-   mutable The mutable keyword allows you to declare and assign values in a mutable variable.
-   <>      Returns true if the left side is not equal to the right side; otherwise, returns false. 
- String.Substring Method	Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.
- String.Equals Method	Determines whether two String objects have the same value.
# **Problems and solutions during the work’s programming**
As I said before, the main problem was the function “dict” which makes a dictionary. The issue is that in the code is used with a for and that cannot be done in f#. So what I had to do is to make it as a List<List<String>>, which is a doble list of strings.

