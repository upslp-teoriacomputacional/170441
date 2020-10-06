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
 *  Written:       04/10/2020
 *  Last updated:  05/10/2020
 **************************************************************************** *)
open System
//  Initial variables
let mutable simbolo = ""
let fin = None
//  Function that matches a given char with a simbol, digit, or null
let caracter (character:char) :int =
    simbolo <- ""
    
    match character with 
    | '0'| '1'| '2'| '3'| '4'| '5'| '6'| '7'| '8'| '9' -> simbolo <- " Digito " ;0
    | '+'| '-'| '*'| '/'  -> simbolo <- "Operador";1
    | ' ' -> 2
    | _ -> 3 
//  Function of Body
let body () = 
    printfn "+--------------+---------+-----------+---------------+"
// Funtion that prints a title
let encabezado () =
    printfn "|  Edo. Actual |Caracter |  Simbolo  |Edo. Siguiente |"
    body()
//  Function that prints a set of values
let contenido estadosig character simbolo estado =
    if estado = 4 then
        printfn "|     %A        |  %A    |%A |      ERR      |" estadosig character simbolo 
    else 
        printfn "|     %A        |  %A    |%A |       %A       |" estadosig character simbolo estado

    


[<EntryPoint>]
//  Main code
let main argv =
    //  E = 4 | A = 5
    //  Table of states
    let tabla = [ [1;4;4];[4;2;4];[3;4;4];[4;4;5] ]
    //  Variable of initial state 
    let mutable estado = 0
    printfn "+-------------------------------------+"
    printfn "|    Ingrese una cadena a evaluar:    |"
    printfn "+-------------------------------------+"
    //  Input of a string
    let cadena = Console.ReadLine()
    body()
    encabezado()
    //  Cicle FOR that iterates the input string
    for character in cadena do
        //  Asignation of state to the next state
        let estadosig = estado
        //  Call the caracter function that returns a specific value
        let charcaracter = caracter character
        //  Determine if the value was not invalid
        if (charcaracter = 3) then
            printfn "< < < C A R A C T E R   I N V A L I D O > > >"
            exit 0
        //  Change the value of the state with a value of the states' table
        estado <- tabla.[estado].[charcaracter]
        // If the state is 4 then is a invalid string
        if (estado = 4) then
            contenido estadosig character simbolo estado
            body()
            printfn "|              Cadena No Valida :(                   |"
            printfn "+----------------------------------------------------+"
            exit 0
        //  Otherwise it prints the information
        contenido estadosig character simbolo estado
        body()

    //  At the end, if the state is different than 3, it is invalid
    if (estado <> 3) then
        printfn "|              Cadena No Valida :(                   |"
        printfn "+----------------------------------------------------+"
    //  And if it is equal then it is valid
    if (estado = 3) then
        printfn "|     %A        |         |Fin Cadena |               |" estado
        body()
        printfn "|                Cadena Valida                       |"
        printfn "+----------------------------------------------------+"    
    0 // return an integer exit code
