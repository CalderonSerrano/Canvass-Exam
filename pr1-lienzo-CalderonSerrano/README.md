# Proyecto 1: Lienzo
 
Se quiere desarrollar un programa de dibujo 2D. El programa debe permitir trabajar con diferentes lienzos que contendrán las diferentes figuras.

-	Del lienzo conoceremos obligatoriamente su nombre, ancho y alto.
-	Todas las figuras tendrán un identificador de tipo _string_ que se asignará en el momento de crearlas (siendo un dato obligatorio). 
-	De las figuras se conocerá su posición (x, y). Si no se indica la posición al crearla se tomará por defecto la posición (0,0). 
-	Las figuras se deben poder desplazar indicando el desplazamiento en cada una de sus coordenadas (dx,dy). 
-	Tendremos dos tipos de figuras: rectángulos y círculos.
-	De los rectángulos se sabe su altura y anchura. No podremos crear un rectángulo sin estos datos.
-	De los círculos se conoce su radio. No podremos crear un círculo sin conocer ese dato.
-	Se quiere poder obtener el área de cada una de las figuras así como la suma de las áreas de todas las figuras que hay en el lienzo activo.
-	Debe poderse obtener la descripción de cada figura que seguirá un formato diferente según sea un rectángulo o un círculo. 
    -	Para los rectángulos: _rectangulo;id;posX;posY;ancho;alto;area_
    -	Para los círculos: _circulo;id;posX;posY;radio;area_


--------------------
Cuando se ejecute el programa principal mostrará un menú con las siguientes opciones:

1.	Crear lienzo en blanco
2.	Cambiar lienzo
3.	Añadir rectángulo
4.	Añadir círculo
5.	Mostrar lienzo
6.	Desplazar
7.	Salir

A continuación, se describe qué ocurrirá cuando el usuario elija cada una de las opciones:

-	**Crear lienzo en blanco**: El programa pedirá el nombre, el ancho y el alto del lienzo que se quiere crear. Una vez creado el lienzo éste pasará a ser el lienzo activo. En el lienzo activo es donde se añaden las figuras. Los lienzos recién creados no tienen figuras asociadas (están en blanco). No podemos crear más de un lienzo con el mismo nombre. Al ejecutar la aplicación exisitirá por defecto un lienzo activo llamado _default_ con una altura y anchura de 100.
-	**Cambiar lienzo**: Muestra una lista con los nombres de todos los lienzos creados hasta el momento y pide al usuario que indique qué lienzo quiere que sea el activo. Si el lienzo indicado existe pasará a ser el lienzo activo.
-	**Añadir rectángulo**: El programa pedirá los datos necesarios para crear el rectángulo y lo añadirá al lienzo activo. 
-	**Añadir círculo**: El programa pedirá los datos necesarios para crear el círculo y lo añadirá al lienzo activo.

- No podrá haber en un lienzo más de una figura con el mismo identificador. A la hora de crear cualquier figura se pedirá al usuario si quiere indicar su posición (x,y). En el caso de que no se indique la posición será la (0,0). No se podrán añadir figuras cuya posición (x,y) esté fuera del lienzo.

-	**Mostrar lienzo**: Muestra el nombre del lienzo activo, sus dimensiones, la descripción de todas las figuras del lienzo y el área total de las figuras en el lienzo. El formato con el que los mostrarán las figuras será el indicado anteriormente. Es decir:
    -	Para los rectángulos: _rectangulo;id;posX;posY;ancho;alto;area_
    -	Para los círculos: _circulo;id;posX;posY;radio;area_
-	**Desplazar**: El programa pedirá el identificador de la figura que se quiere desplazar. Si se encuentra pedirá las distancias que se quiere desplazar en cada eje (dx, dy). La figura se desplazará la distancia indicada siempre y cuando la posición de destino se encuentre dentro del lienzo.Si como resultado del desplazamiento la figura quedase fuera del lienzo no se desplazaría.
-	**Salir**: El programa finaliza.