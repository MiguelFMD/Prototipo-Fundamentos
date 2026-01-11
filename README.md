# Prototipo fundamentos

Enlace entrada a portfolio con vídeo explicativo: 
https://sites.google.com/ull.edu.es/portfolio-mfmdmastervj/inicio/fundamentos-del-desarrollo-de-videojuegos

## Movimiento jugador

Script: PlayerController.cs

Gestiona el movimiento del jugador horizontal como se ha seguido en las prácticas. La diferencia está en la detección para saber si el jugador está tocando el suelo o no, ya que se crea una esfera de colisión a los pies del jugador y nos dice si este está tocando el suelo o no. Si está tocando el suelo puede saltar, si salta haremos la animación de salto, cuando empiece a caer haremos la animación de caída hasta que vuelva a tocar el suelo.

## Cambio de cámaras

Script: CameraSwitcher.cs

Se gestiona con un trigger, donde si el jugador entra se activará una cámara que apunta a un grupo de coleccionables, si sale volverá a la cámara normal que sigue al jugador.

## Música y SFX

La música se encuentra en un objeto de la escena y se gestiona su volumen mediante el audio mixer. Lo mismo con los SFX (suena un sonido cuando coges un coleccionable)

## Coleccionables

Script: CollectableObjects.cs

Si el jugador colisiona con un objeto este se destruye, activa el sonido SFX y llama al evento ObjectCollected. En GameManager.cs "escucha" este evento para sumar 10 puntos al jugador y actualizar la UI de puntuación con los nuevos puntos.

## Movimiento fondos

Script: MovimientoVerticalBG.cs y ControladorFondoCamara.cs

Hay 2 texturas de fondos en quads 3D planos que scrolean infinitamente en diagonal movimiendo sus coordenadas de textura, igual que en las prácticas. Además también se controla la posición de la cámara respecto al ancho de los fondos para ver si es necesario mover un fondo y ponerlo al final del siguiente para que siempre haya una textura de fondo, igual que se hizo en las prácticas.

## Colisiones y tilemaps

Hay 2 capas de tilemaps, una para dibujar el fodo, la cual no tiene colisión. Y otra para techo, paredes y suelos, la cual sí tiene colisión. Esta última capa es la que tiene el layer "GroundLayer" el cual se usa para detectar si el jugador está tocando el suelo o no.
