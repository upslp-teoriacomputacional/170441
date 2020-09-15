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
 *  Written:       10/09/2020
 *  Last updated:  10/09/2020
 **************************************************************************** *)
open System

[<EntryPoint>]
let main argv = 
    let A = Set.empty.Add(1).Add(2).Add(3).Add(4).Add(5)
    let B = Set.empty.Add(3).Add(4).Add(5).Add(6).Add(7)
    let C = Set.empty
    //  Pertenencia de un conjunto
    let pertenencia =
        //  Se declaran los conjuntos
        let A = Set.empty.Add(1).Add(2).Add(3).Add(4).Add(5)
        //  Se verifica si ciertos elementos pertencen al conjunto
        if A.Contains 1 then printf(" A contains 1\n")
        if not (A.Contains 1) then printf(" A doesn't contains 1\n")
        if A.Contains 10 then printf(" A contains 10\n")
        if not (A.Contains 10) then printf(" A doesn't contains 10\n")
    //  Transformación a conjunto
    let transformarConj =
        //  Se declaran los conjuntos haciendo una tranformación
        let A = Set.empty.Add(1).Add(2).Add(3)
        printf "The set is: %A\n" A
        let B = Set.empty.Add(1).Add(2).Add(3).Add(4).Add(5)
        printf "The set is: %A\n" B
        //  En este caso, se tiene que transformar de String a Seq y Seq a Set
        let C = Set.ofList (Seq.toList "Hola Mundo")
        printf "The set is: %A\n" C
    //  Quitar un elemento de un Set
    let quitar =
        //  Se declaran los conjuntos
        let A = Set.empty.Add(0).Add(1).Add(2).Add(3).Add(4).Add(5)
        //  Se remueve el elemento con valor dos
        let A = A.Remove 2
        printf "The set after deleting 2: %A\n" A
    //  Limpiar un set
    let clearSet =
        //  Se declaran los conjuntos
        let A = Set.empty.Add(0).Add(1).Add(2).Add(3).Add(4).Add(5)
        //  Se inicia el Set A como vacío o empty
        let A = Set.empty
        printf "The set after removing all: %A\n" A
    //  Clonar sets
    let copiar =
        //  Se declaran los conjuntos
        let A = Set.empty.Add(0).Add(1).Add(2).Add(3).Add(4).Add(5)
        // Se copia el set A a B
        let B = A
        printf "Set A: %A Compare set B: %A\n" A B
    //  Agregar un elemento a un set existente
    let agregar =
        //  Se añade el elemento 897 al set B
        let B = B.Add(987)
        printf "The new set B: %A\n" B
    //  Se realiza la operación de union
    let union =
        //  Se declaran los conjuntos
        let A = Set.empty.Add(1).Add(2).Add(3).Add(4).Add(5)
        let B = Set.empty.Add(3).Add(4).Add(5).Add(6).Add(7)
        //  Se unen los elementos sin repeticion de ambos sets
        printf "The union: %A\n" (Set.union A B)
        printf "The union: %A\n" (A+B)
    //  Intersección de sets
    let interseccion =
        //  Se declaran los conjuntos
        let A = Set.empty.Add(1).Add(2).Add(3).Add(4).Add(5)
        let B = Set.empty.Add(3).Add(4).Add(5).Add(6).Add(7)
        //  Se intersectan los elementos de A y B. Se muestran
        printf "The intersection: %A\n" (Set.intersect A B)
    //  Diferencia de sets
    let diferencia =
        //  Se declaran los conjuntos
        let A = Set.empty.Add(1).Add(2).Add(3).Add(4).Add(5)
        let B = Set.empty.Add(3).Add(4).Add(5).Add(6).Add(7)
        (*La diferencia del set de A en B se muestra. 
        NOTA: La diferencia de A-B es diferente a la de B-A.
        Tambien se puede ejecutar esta operación con: 
        *)
        printf "The difference: %A\n" (Set.difference A B)
        printf "The difference: %A\n" (A-B)
    //  Diferencia Simetrica
    let simetrica =
        //  Se declaran los conjuntos
        let A = Set.empty.Add(1).Add(2).Add(3).Add(4).Add(5)
        let B = Set.empty.Add(3).Add(4).Add(5).Add(6).Add(7)
        let C = Set.empty
        (*  F# no maneja una funcion tal como Symmetric_difference.
            En este caso, para realizar dicha funcion, es necesario
            Obtener la diferencia individual de ambos sets y sumarlos
        *)
        printf "The Symmetric difference: %A\n" ((A-B)+(B-A))
        printf "The Symmetric difference: %A\n" ((B-A)+(A-B))
        printf "The Symmetric difference: %A\n" ((A-C)+(C-A))
        printf "The Symmetric difference: %A\n" ((B-C)+(C-B))
    //  Subconjuntos de un conjunto
    let subconjunto =
        //  Se declaran los conjuntos
        let B = Set.ofSeq [0 .. 1.. 9]
        let A = Set.ofSeq [1 .. 1.. 5]
        //  Se obtiene si cierto conjunto es subconjunto de otro
        //  ; Si sí es subconjunto, el resultado es True; si no, False
        printf "The subset: %A\n" (A.IsSubsetOf B)
        printf "The subset: %A\n" (B.IsSubsetOf A)
    //  Superconjunto de un conjunto
    let superconjunto() =
        //  Se declaran los conjuntos
        let B = Set.ofSeq [0 .. 1.. 9]
        let A = Set.ofSeq [1 .. 1.. 5]
        printf "The superset: %A\n" (B.IsSupersetOf A)
        printf "The superset: %A\n" (A.IsSupersetOf B)
    0 // return an integer exit code
