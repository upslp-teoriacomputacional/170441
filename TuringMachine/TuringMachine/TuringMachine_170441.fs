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
 *      Written:    25/11/2020
 * Last updated:    25/11/2020
 *****************************************************************************)
open System
//  Se define una cadena de error
exception Error of string
// Define a function to construct a message to print
let turing_M (state) (blank) (rules:list<list<string>>) (tape:list<string>) (final) (pos) =
    //  Se pasan variables a variables mutables
    let mutable tape = tape
    let mutable pos = pos
    let mutable st = state
    //  Si la cinta está vacia, se agrega un signo de vacío
    if tape.IsEmpty then
        tape <- [blank]
    //  Si la posicion es menor de 0, se inicia con la posicion de la cinta
    if pos < 0 then
        pos <- pos + tape.Length
    //  La posicion no puede ser mayor que la longitud de la cinta
    if pos >= tape.Length || pos < 0 then
        raise (Error ("Se inicializa mal la posicion..."))
    let mutable Break = false
    //  Iniciamos el ciclo mientras que la variable Break sea falsa
    while not Break do
        Console.ForegroundColor<-ConsoleColor.DarkBlue
        //  Se imprime el estado
        printf "%s\t" st
        //  Se imprime cada caracter de la cinta y se especifica la posición del cabezal
        for i in 0..tape.Length-1 do
            if i = pos then
                Console.ForegroundColor<-ConsoleColor.Cyan
                printf "[%s] " tape.[i]
            else
                Console.ForegroundColor<-ConsoleColor.White
                printf " %s  " tape.[i]
        printfn ""
        let mutable isNotInTape = true
        //  Se checa si el estado es final
        if st = final then
            Break <- true
        //  Se checa si la regla actual coincide con la cinta
        for eachRule in rules do
            if st = eachRule.[0] && tape.[pos] = eachRule.[1] then
                isNotInTape <- false
        if isNotInTape then
            Break <- true
        if not Break then
            let mutable v1 = ""
            let mutable dr = ""
            let mutable s1 = ""
            //  Se busca la regla especifica
            for eachRule in rules do
                //  Cuando la regla coincida, se guarda v1, dr y s1
                if st = eachRule.[0] && tape.[pos] = eachRule.[1] then
                    v1 <- eachRule.[2]

                    dr <- eachRule.[3]

                    s1 <- eachRule.[4]
            let mutable newTape = []
            //  Se modifica la posicion actual de la cinta y se aplica un reemplazo de caracter
            for x in 0..tape.Length-1 do
                if x = pos then
                    newTape <- newTape @ [v1]
                else
                    newTape <- newTape @ [tape.[x]]
            tape <- newTape
            //  Si el cabeza debe ir a la izquierda
            if dr.Equals("left") then
                //  Y las posicion es mayor a 0, reduce la posicion
                if pos > 0 then
                    pos <- pos - 1
                //  Y si no, agrega un caracter de blank
                else
                    tape <- [blank] @ tape
            //  Si el cabeza debe ir a la derecha
            if dr.Equals("right") then
                //  Se aumenta la posición
                pos <- pos + 1
                //  y si la posicion es igual o mayor al tamaño de la cinta, agrega un caracter blank
                if pos >= tape.Length then
                    tape <- tape @ [blank]
            st <- s1


[<EntryPoint>]
let main argv =
    //  Se declaran las reglas para la Maquina de Turing que realiza la multiplicación de dos operadores unarios
    let c = [ ["s1"; "1"; "1"; "right"; "s1"];
              ["s1"; "x"; "x"; "right"; "s2"];

              ["s2"; "E"; "E"; "right"; "s2"];
              ["s2"; "="; "="; "right"; "s8"];
              ["s2"; "1"; "E"; "left"; "s3"];

              ["s3"; "E"; "E"; "left"; "s3"];
              ["s3"; "Y"; "Y"; "left"; "s3"];
              ["s3"; "x"; "x"; "left"; "s3"];
              ["s3"; "1"; "Y"; "right"; "s4"];

              ["s4"; "E"; "E"; "right"; "s4"];
              ["s4"; "Y"; "Y"; "right"; "s4"];
              ["s4"; "x"; "x"; "right"; "s4"];
              ["s4"; "1"; "1"; "right"; "s4"];
              ["s4"; "="; "="; "right"; "s4"];
              ["s4"; "b"; "1"; "left"; "s5"];

              ["s5"; "E"; "E"; "left"; "s5"];
              ["s5"; "1"; "1"; "left"; "s5"];
              ["s5"; "="; "="; "left"; "s5"];
              ["s5"; "x"; "x"; "left"; "s6"];

              ["s6"; "Y"; "Y"; "left"; "s6"];
              ["s6"; "b"; "b"; "right"; "s7"];
              ["s6"; "1"; "Y"; "right"; "s4"];

              ["s7"; "Y"; "1"; "right"; "s7"];
              ["s7"; "x"; "x"; "right"; "s2"];]
    //  Se llama a la función
    turing_M ("s1") ("b") (c) (["1";"1";"x";"1";"1";"="]) ("s8") (0)
    0 // return an integer exit code