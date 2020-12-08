(*
 * *****************************************************************************
 *        Name:    Juan Gerardo     
 *     Surname:    Montalvo Becerra
 *          ID:    170441
 *       Major:    IT Engineering
 * Institution:    Universidad Politécnica de San Luis Potosí
 *   Professor:    Juan Carlos González Ibarra
 * Description:    Made in VSC, using F# language.
 *                
 *  Written:       21/09/2020
 *  Last updated:  21/09/2020
 **************************************************************************** *)
open System

[<EntryPoint>]
let main argv = 
    //  We start declaring the list that includes false and true values
    let booleans = [false; true]
    // The first table executes the OR operation between x and y
    printfn "x\ty\tx or y"
    printfn "----------------------"
    //  The chained FOR creates all the possible sets between x and y
    for x in booleans do
        for y in booleans do
            // To obtain a logic OR you could use "or" or "||"
            printfn" %A\t%A\t%A" x y (x or y)
    printf "\n\n"
    // The second table executes the AND operation between x and y
    printfn "x\ty\tx and y"
    printfn "----------------------"
    //  The chained FOR creates all the possible sets between x and y
    for x in booleans do
        for y in booleans do
            // In this case, you can only use &&.
            printfn" %A\t%A\t%A" x y (x && y)
    printf "\n\n"
    // The Third table executes a not operation of only the x value
    printfn "x\tnot x"
    printfn "-------------"
    //  The FOR is used to search for every element of the list called booleans
    for x in booleans do
        //  To create a not operation, you simply use "not" before the variable  
        printfn" %A\t%A" x (not x)
    printf "\n\n"
    // Finally, we have the last table that creates an Inclusive OR AKA XOR
    printfn "x\ty\tx ^ y"
    printfn "----------------------"
    //  The FOR is used to search for every element of the list called booleans
    for x in booleans do
        for y in booleans do
            //  This is more complex that the other logic operations. This time, It is necessary that we create
            //  the logic behind the XOR which is A ^ B = (A OR B) AND ~(A OR B)
            printfn" %A\t%A\t%A" x y ((x || y) && not (x && y)) 
    0 // return an integer exit code
