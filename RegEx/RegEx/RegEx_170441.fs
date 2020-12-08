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
 *      Written:    22/10/2020
 * Last updated:    22/10/2020
 **************************************************************************** *)
open System
open System.Text.RegularExpressions
//  Function that determines if a character is alphanumeric
let isalnum(c:char):bool =
    let mutable ret:bool=false
    if Char.IsLetter(c) || Char.IsNumber(c) then
        ret<-true
    ret
//  Function that determines if a variable is compatible with PROLOG
let variablePROLOG (w: string):bool =
    let mutable w = w;
    let mutable wChar:char = w.[0]
    let mutable ret = false
    //  The character must be an uppercase or a underscore
    if (Char.IsLetter(wChar) && wChar.Equals(Char.ToUpper(wChar))) || wChar.Equals('_') then
        //  The first char is deleted of the string
        w <- w.Substring(1,w.Length-1)     
        try
            wChar <- w.[0]
        with
            | :? System.IndexOutOfRangeException -> ()
        //  While w has character and the first char is an alphanumeric or an underscore...
        while w.Length > 0 && (isalnum (wChar) || wChar.Equals('_') ) do
            //  The first char is deleted of the string
            w <- w.Substring(1,w.Length-1)
            try
                wChar <- w.[0]
            with
                | :? System.IndexOutOfRangeException -> ()
        //  If w is empty then
        if w.Equals("") then
            ret<-true
    ret

[<EntryPoint>]
let main argv =
    //  For the string tokens
    let mutable tokens = []
    //  Splits the string into words
    let source_code = "int result = 100;".Split()
    //  Loop through each source code word
    for word in source_code do
        //  This will check if a token has datatype DATATYPE
        if Regex.IsMatch(word, "(str|int|bool)") then
            tokens <- tokens @ ["DATATYPE", word]
        //  This will check if a token has IDENTIFIER declaration
        elif Regex.IsMatch(word, "[a-z]|[A-Z]") then
            tokens <- tokens @ ["IDENTIFIER", word]
        //  This will check if a token has datatype OPERATOR
        elif Regex.IsMatch(word, "(\*|\-|\/|\+|\%|\=)") then
            tokens <- tokens @ ["OPERATOR", word]
        //  This will check if a token has datatype INTEGER
        elif Regex.IsMatch(word, ".[0-9]") then
            if word.EndsWith(";") then
                tokens <- tokens @ ["INTEGER", word.Substring(0,word.Length-1)]
                tokens <- tokens @ ["END_STATEMENT", ";"]
            else
                tokens <- tokens @ ["INTEGER", word] 
    //  Prints the array of tokens    
    tokens |> printfn "%A"
    //  This next part checks if a array of variables are compatible with PROLOG
    let var = ["X"; "Objeto2"; "_23"; "Resultado"; "_x23"]
    printfn "<<<Variables PROLOG>>>"
    for x in var do
        if variablePROLOG (x) then
            x|> printfn "Variable %s: True"
        else    
            x|> printfn "Variable %s: False"
    
    0 // return an integer exit code
