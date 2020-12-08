(*
 * *****************************************************************************
 *         Name:    Juan Gerardo     
 *      Surname:    Montalvo Becerra
 *           ID:    170441
 *        Major:    IT Engineering
 *  Institution:    Universidad Politécnica de San Luis Potosí
 *    Professor:    Juan Carlos González Ibarra
 *  Description:    Made in VSC, using F# language.
 *
 *              
 *      Written:    12/11/2020
 * Last updated:    13/11/2020
 *****************************************************************************)
open System
//  Because we have nodes with two states, we need a second table that has those second values
let tabla = [ [1;-1;-1]; [1;1;1]; [-10;-1;-1];]
let tabla2 = [ [-1;-1;-1]; [2;-1;-1]; [-1;-1;-1];]
let pdaRules = [["Z;SZ";"E";"E"];["S;e|Z;e";"S;SX";"X;e"];["E";"E";"E"];]
let mutable nPrint = 1;
//  Matching functions aba (Function Made by Vazquez Reyes Rodolfo Emanuel)
let caracter (mtch:string) :string =
    //  match evaluates the first char of the string and returns the same value
    match mtch with 
        | head when head.StartsWith("a") -> "a"
        | head when head.StartsWith("b") -> "b"
        | head when head.StartsWith("") -> "''"
        | _ -> exit(0)
//  Just a title with color (Function Made by Vazquez Reyes Rodolfo Emanuel)
let title () =
    Console.ForegroundColor<-ConsoleColor.Red
    printfn "+-------------------------------------+"
    printf "|    "
    Console.ForegroundColor<-ConsoleColor.Green
    printf "Ingrese una cadena a evaluar:"
    Console.ForegroundColor<-ConsoleColor.Red
    printfn "    |"
    printfn "+-------------------------------------+"
    Console.ForegroundColor<-ConsoleColor.White
//  Prints a visible separation in the exit (Function Made by Vazquez Reyes Rodolfo Emanuel)
let body () = 
    for x in [0 .. 30] do
        if x % 2 = 0 then
            Console.ForegroundColor<-ConsoleColor.Green
            printf "+-----"
        else
            Console.ForegroundColor<-ConsoleColor.Red
            printf "+-----"
    printfn ""
    Console.ForegroundColor<-ConsoleColor.White
//  Prints a transition table for the evaluated string (Function Made by Vazquez Reyes Rodolfo Emanuel & Montalvo Becerra Juan Gerardo)
let transitionTable (cd:string)(accepted:bool)(hStack:string) =
    let mutable key = cd
    let hStack = hStack.Split '|'
    let mutable count = 1;
    let mutable color = ConsoleColor.White
    let mutable temp = ""
    //  The color is defined depending on the variable accepted
    if accepted then
        color <- ConsoleColor.Green
    else
        color <- ConsoleColor.Red
    Console.ForegroundColor<-color
    printfn "+---------------+---------------+---------------+---------------+--------------+"
    printfn "|  Edo. Actual  |    Caracter   |    Simbolo    |Edo. Siguiente |     PILA     |"
    while not (key.Equals("")) do
        try
            temp <- key.Remove (key.IndexOf(")")+1)
        with
          | :? System.ArgumentOutOfRangeException -> temp <- key
        try
            key <- key.Remove (key.IndexOf("("),key.IndexOf(")")+2)
        with
          | :? System.ArgumentOutOfRangeException -> key <- key.Remove (key.IndexOf("("),key.IndexOf(")")+1)
        //  temp|>printfn "%s"
        //  key|>printfn "%s"
        Console.ForegroundColor<-color
        printfn "+---------------+---------------+---------------+---------------+--------------+"
        printf "|" 
        Console.ForegroundColor<-ConsoleColor.White
        printf "\t%s\t" (temp.Substring(1,temp.IndexOf(",")-1)) 
        Console.ForegroundColor<-color
        printf "|"
        Console.ForegroundColor<-ConsoleColor.White 
        printf "\t%s\t"  (temp.Substring(temp.IndexOf(" ")+1,temp.IndexOf(":")-temp.IndexOf(" ")-1)) 
        Console.ForegroundColor<-color
        printf "|" 
        Console.ForegroundColor<-ConsoleColor.White
        printf "\t%s\t" (temp.Substring(temp.IndexOf(":")+1,temp.IndexOf("-")-temp.IndexOf(":")-1)) 
        Console.ForegroundColor<-color
        printf "|" 
        Console.ForegroundColor<-ConsoleColor.White
        printf "\t%s\t"  (temp.Substring(temp.IndexOf(">")+1,temp.IndexOf(")")-temp.IndexOf(">")-1))
        Console.ForegroundColor<-color
        printf "|"

        Console.ForegroundColor<-ConsoleColor.White
        printf "\t%A\t"  (hStack.[count])
        Console.ForegroundColor<-color
        printfn "|" 
        count <- count + 1
    //  At the end, it displays if the chain was valid or not
    if accepted then
        printfn "+---------------+---------------+---------------+---------------+--------------+"
        printfn "|                               Cadena Valida                                  |"
        printfn "+---------------+---------------+---------------+---------------+--------------+"
    else
        printfn "+---------------+---------------+---------------+---------------+--------------+"
        printfn "|                             Cadena No Valida :(                              |"
        printfn "+---------------+---------------+---------------+---------------+--------------+"
    Console.ForegroundColor<-ConsoleColor.White
//  Recursive function that display every posible way for the STRING in the NFA 
//  (Function Made by Vazquez Reyes Rodolfo Emanuel & Montalvo Becerra Juan Gerardo)
let rec node (nodo:int) (cad:string) (state:string) (histStack:string) (stack:string) =
    let mutable stack = stack
    //  Variables that recover the current state and send the next
    let mutable st = ""
    let mutable proof = ""
    //  Because the very first node is "" we call a try catch that ignores the code in the first one
    try
        proof <- state.Remove(0,state.Length-2)
        proof <- proof.Remove 1
    with
      | :? System.ArgumentOutOfRangeException -> printf ""
    //  At the start, it checks if it already acceptable
    if ( proof.Equals("A"))  then
        if (stack.Length = 0) then
            body ()
            printfn "%A" state
            Console.ForegroundColor<-ConsoleColor.Green
            printfn " = It reaches the final state and the stack is empty"
            Console.ForegroundColor<-ConsoleColor.White
            transitionTable state true histStack
            histStack.Split '|' |> printfn "%A"
        else
            body ()
            printfn "%A" state
            Console.ForegroundColor<-ConsoleColor.Green
            printfn " = It reaches the final state and the stack is not empty"
            Console.ForegroundColor<-ConsoleColor.White
            transitionTable state true histStack
            histStack.Split '|' |> printfn "%A"
    //  It even checks if it's not acceptable
    elif (proof.Equals("E")) then
        if (stack.Length = 0) then
            body ()
            printfn "%A" state
            Console.ForegroundColor<-ConsoleColor.Red
            printfn " = It does not reach the final state and the stack is empty"
            Console.ForegroundColor<-ConsoleColor.White
            transitionTable state false histStack
            histStack.Split '|' |> printfn "%A"
        //  If neither of those occurred, it continues until it occurs
        else
            body ()
            printfn "%A" state
            Console.ForegroundColor<-ConsoleColor.Red
            printfn " = It does not reach the final state and the stack is not empty"
            Console.ForegroundColor<-ConsoleColor.White
            transitionTable state false histStack
            histStack.Split '|' |> printfn "%A"
        //  If neither of those occurred, it continues until it occurs
            
    else
        let histStack = histStack + "|" + stack
        let mutable chain = ""
        //  Uses the function match on the cad string
        let result = caracter cad
        if (tabla.[nodo].[1] <> -1 || tabla.[nodo].[2] <> -1 || tabla.[nodo].[0] = -10) then
        //  When the node is on q8 or q10
            if (tabla.[nodo].[1] <> -1) then
                //  If it is equal to a then it continues to the nex node
                if result.Equals("a") then
                    for rule in pdaRules.[nodo].[1].Split '|' do
                        try
                            if ((stack.Substring(0,1)) = (rule.Substring(0,1)) ) then
                                stack <- stack.Substring(1)
                                stack <- rule.Substring(rule.IndexOf(";") + 1) + stack
                                st <- state + "(q" + string nodo + ", " + result + ":a" + "->" + "q" + string tabla.[nodo].[1] + ")," 
                                node (tabla.[nodo].[1]) (cad.Remove(0,1)) (st) (histStack) (stack)
                        with
                           | :? System.ArgumentOutOfRangeException -> () 
                //  If it's not then it finishes with an E or error    
                else
                    st <- state + "(q" + string nodo + ", " + result + ":a" + "->" + "E)" 
                    node (tabla.[nodo].[1]) (cad) (st) (histStack) (stack)
            //  When the node is on q4 
            if (tabla.[nodo].[2] <> -1) then
                //  If it is equal to b then it continues to the nex node
                if result.Equals("b") then
                    for rule in pdaRules.[nodo].[2].Split '|' do
                        try
                            if ((stack.Substring(0,1)) = (rule.Substring(0,1)) ) then
                                if (rule.Substring(rule.Length-1, 1).Equals("e")) then
                                    stack <- stack.Substring(1)
                                st <- state + "(q" + string nodo + ", " + result + ":b" + "->" + "q" + string tabla.[nodo].[2] + ")," 
                                node (tabla.[nodo].[2]) (cad.Remove(0,1)) (st) (histStack) (stack)
                        with
                           | :? System.ArgumentOutOfRangeException -> ()     
                //  If it's not then it finishes with an E or error   
                else
                    st <- state + "(q" + string nodo + ", " + result + ":b" + "->" + "E)" 
                    node (tabla.[nodo].[2]) (cad) (st) (histStack) (stack)
            //  When the node is on q1
            if (tabla.[nodo].[0] = -10) then
                //  If it is equal to '' then it accepts the STRING
                if result.Equals("''") then
                    st <- state + "(q" + string nodo + ", " + result + ":''" + "->" + "A)" 
                    node (tabla.[nodo].[0]) (cad) (st) (histStack) (stack)  
                //  If it's not then it finishes with an E or error  
                else
                    st <- state + "(q" + string nodo + ", " + result + ":''" + "->" + "E)" 
                    node (tabla.[nodo].[0]) (cad) (st) (histStack) (stack)
        if (tabla.[nodo].[0] <> -1 && tabla.[nodo].[0] <> -10) then
            //  If the node contains a lambda expression then it goes directly to the next nodes without comparing
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
[<EntryPoint>]
//  Main code
let main argv =
    //  Calls title to print the starting point
    title ()
    //  Asks for a string to be evaluated
    let cadena = Console.ReadLine()
    //  Calls the a recursive function node

    node (0) (cadena) ("") ("") ("Z")
    0 // return an integer exit code
