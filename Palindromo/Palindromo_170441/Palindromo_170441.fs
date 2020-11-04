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
 *      Written:    01/11/2020
 * Last updated:    03/11/2020
 **************************************************************************** *)

open System

[<EntryPoint>]
let main argv =
    //  Declaración del palindromo
    let read:string = "anita lava la tina"
    //  Preparación para convertirlo a una cadena analizable
    let words = read.ToUpper().Split()
    let mutable palindromo = ""
    //  Se integra a una sola variable, sin espacios
    for word in words do
        palindromo <- palindromo + word
    //  En caso de que el palindromo sea de longitud impar, se repite la letra de en medio
    if palindromo.Length % 2 <> 0 then
        palindromo <- palindromo.Insert(palindromo.Length/2, string(palindromo.[palindromo.Length/2]))
    //  Se convierte la palabra en caracteres separados
    let array = Seq.toList(palindromo)
    //  Se inicializa la lista con la que se checará el palindromo
    let mutable check:list<char> = []
    //  For que analiza la lista de caracteres
    for x in 0 .. array.Length-1 do
        //  Para la mitad de los caracteres...
        if x <= (array.Length/2)-1 then
            //  Los introdicimos uno por uno al nuevo arreglo
            check <- check @ [array.[x]]
        //  Para la última mitad...       
        else
            //  Se verifica al revez los caracteres introducidos con los faltantes
            if check.[check.Length-1] = array.[x] then
                check <- Seq.toList((String.Concat(Array.ofList(check))).Substring(0,check.Length-1))
        //  Se imprime cada estado
        check |> printfn "%A" 
    // Si la cadena al finalizar es vacía...
    if check.IsEmpty then
        //  La cadena era una palabra palíndroma
        printfn ">>>La palabra si es palíndroma"
    //  De lo contrario, no lo era
    else
        printfn ">>>La palabra no es palíndroma"     
    0 // return an integer exit code
