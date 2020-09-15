# **Como solucionaste el problema**
Para poder solucionar el problema, lo primero que realice es una búsqueda sobre el lenguaje de F#, ya que no tenía ningún conocimiento acerca de como era las declaraciones al momento de la programación. Posteriormente, me di a la tarea de buscar las respectivas expresiones a las que se usaban en el código hecho en Python, y sobre como se utilizaban dentro del código en F#. 
Una vez programadas las características, procedí a ejecutar ambos códigos para checar similitudes o diferencias y proceder a la corrección de estas mismas.
# **Comando para ejecutar las operaciones**
Los comandos utilizados para manejar los conjuntos dentro de F# fueron:
- Add: Devuelve un nuevo conjunto con un elemento agregado al conjunto. No se produce ninguna excepción si el conjunto ya contiene el elemento especificado.
- Contains: se evalúa como true si el elemento especificado está en el conjunto especificado.
- Empty: El conjunto vacío para el tipo especificado.
- Intersect: Calcula la intersección de los dos conjuntos.
- isSubset: Se evalúa como true si todos los elementos del primer conjunto están en el segundo.
- isSuperset: Se evalúa como true si todos los elementos del segundo conjunto están en el primero.
- ofSeq: crea una nueva colección a partir del objeto enumerable especificado.
- Remove: Devuelve un nuevo conjunto con el elemento especificado eliminado. No se produce ninguna excepción si el conjunto no contiene el elemento especificado.
- Unión: Calcula la unión de los dos conjuntos.
# **Problemas y soluciones al programar la practica**
Inicialmente, uno de mis primeros problemas fueron la declaración de variables y funciones dentro de F#. No es nada parecido a lo que he manejado y al principio resulto confuso, aunque después tuvo más sentido.
Otro problema fue la traducción de Python a F#, ya que los dos lenguajes son diferentes y los comandos para los sets son diferentes. Un ejemplo es la función de diferencia simétrica que en Python si esta, pero en F# no existe. Mi solución fue ejecutar las diferencias individuales y sumarlas.
Otra cuestión fue el ambiente de ejecución. Para Python no es necesario escribir un print para mostrar el contenido de variables en algunos casos. Al momento de ejecutar el código de F# con Dotnet run, es necesario declarar una salida con printf para la información que quiera ver, en caso contrario no se mostraría nada.