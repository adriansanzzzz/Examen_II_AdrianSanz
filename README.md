# Examen_II_AdrianSanz
Adrian Sanz
## Asignatura: Interfaces Inteligentes
## Adrián Sanz Fernández - alu0101686400@ull.edu.es

## 1 - Crear una escena en la que el entorno se construya con el paquete The Shed de la Asset Store. Debes incluir al menos 3 arañas del paquete Free Fantasy Spider distribuidas por toda la habitación. Incluir un personaje del paquete Hungry Zombie. 
He añadido box collider a todos los nuevos objetos, ya que no lo tenian, y mesh collider al suelo para evitar que los objetos se cayeran al vacio.
<img width="1430" alt="image" src="https://github.com/adriansanzzzz/EXAMEN_InterfacesInteligentes/assets/74414073/b549a717-51f8-4129-adca-17ad360516c7">
## 2 - Crear un script que actúe de controlador del movimiento del Zombie, avanzando siempre hacia delante del eje Z.
![Ej2](https://github.com/adriansanzzzz/EXAMEN_InterfacesInteligentes/assets/74414073/bd156a6e-4d49-4401-985f-6805894c1cb3)

## 3 - Crear un script para teletransportar al monstruo a cada vez que se pulse la tecla T.
![ej3](https://github.com/adriansanzzzz/EXAMEN_InterfacesInteligentes/assets/74414073/3614274b-697b-4d04-a934-98c634de05d9)

## 4 - Crear un script que desplace aleatoriamente las macetas cada vez que el monstruo esté a una distancia que fijes de la pizarra y le acerque las sillas una distancia prefijada.
![Grabación de pantalla 2023-11-03 a las 16 41 25](https://github.com/adriansanzzzz/EXAMEN_InterfacesInteligentes/assets/74414073/b93bcdd1-ff49-4f4f-abee-6ef1f84781e8)
## 5 - Crear un script que al alcanzar el monstruo alguna silla todas las arañas se dirijan a él.
Esta parte me ha dado problemas y he probado con varias estrategias diferentes. Al final he utilizado lerp.
![ej5](https://github.com/adriansanzzzz/EXAMEN_InterfacesInteligentes/assets/74414073/b4af1a9c-d752-4281-988f-9864f6052713)
## 6 - Configurar el proyecto para funcionar con CardBoard. 
Para ello he añadido de la escena de hello cardboard la camara y el reticlepointer. He añadido la capa interactive a la pizarra y al resto ignore raycast.
<img width="753" alt="image" src="https://github.com/adriansanzzzz/EXAMEN_InterfacesInteligentes/assets/74414073/705b7c85-ba33-4aa0-a338-6bc995e28d20">
## 7 - Implementar una mecánica en la que el jugador al fijar la mirada sobre la pizarra, las arañas se alejen y las sillas vuelvan a su posición original.
![ej7](https://github.com/adriansanzzzz/EXAMEN_InterfacesInteligentes/assets/74414073/64781157-f4e7-4538-8c4d-c786169740ae)

## MODIFICACION
No me ha dado tiempo a implementar esta parte, pero me ha dado tiempo a dejar la mecanica de colision y de crear el contador
 ```csharp

        if (collision.gameObject.CompareTag("maceta")){
            cont++;

            if(cont==3){
                Debug.Log("Movimiento arañas cama");
                Debug.Log("Movimiento sillas puerta");

            }
```
