# RedocPro

Implementación del servicio Customer Identity and Access Management (CIAM)  

Para descargar la colección de Postman puede hacer <a href="postman_collection.json" download>click aquí</a>

Para descargar las variables de entorno de Postman puede hacer <a href="test_environment.json" download>click aquí</a>

## Ejecución local
Para ejecutar de forma local, se pueden seguir los siguientes pasos:
1. Instalar la versión más reciente de Visual Studio.
2. Descargar el `.zip` de la rama `main` del repositorio.
3. Abrir el proyecto.
4. Instalar las depencias de Node con ```npm install```
5. Agregar en el [`appsettings.Development.json`]
6. Ahora, puedes hacer click en la ejecutar el proyecto, o bien, en "Depurar > Iniciar depuración".

Donde puedes interactuar con los endpoints de CIAM. Si no se abre la ventana, puedes ingresar a esta por medio del siguiente enlace: [https://localhost:7131/swagger).

## Como contribuir al repositorio
Para contribuir al repositorio se te deben otorgar permisos de escritura y seguir los siguientes pasos. 

1. Asociar un nuevo SSH con tu cuenta de GitHub institucional.

    En esta ocasión, no basta con descargar el `.zip` del repositorio. Debes configurar tu dispositivo para conectar tu cuenta de GitHub mediante SSH, puedes seguir el siguiente [tutorial de GitHub](https://docs.github.com/en/authentication/connecting-to-github-with-ssh/adding-a-new-ssh-key-to-your-github-account) para añadir una SSH a tu cuenta. Además, debes darle permisos para acceder a `digitaltitransversal`, sigue el siguiente [tutorial](https://docs.github.com/en/enterprise-cloud@latest/authentication/authenticating-with-saml-single-sign-on/authorizing-an-ssh-key-for-use-with-saml-single-sign-on) para dar dichos permisos

2. Teniendo ya el SSH configurado, debes clonar el repositorio en la carpeta de tu preferencia. Como sugerencia, puedes crear una carpeta `~/Projects` para mantener todos los proyectos en un sólo lugar.

    En la terminal, corre el siguiente comando:
    ```
    git clone git@github.com:
    ```

    Debería aparecer una salida parecida a:
    ```
    remote: Enumerating objects: 542, done.
    remote: Counting objects: 100% (314/314), done.
    remote: Compressing objects: 100% (177/177), done.
    remote: Total 542 (delta 196), reused 178 (delta 122), pack-reused 228
    Receiving objects: 100% (542/542), 110.60 KiB | 1.44 MiB/s, done.
    Resolving deltas: 100% (271/271), done.
    ```

3. En este punto, se pueden seguir los pasos que se describieron para la ejecución local.

4. Si se quiere agregar nuevos cambios, debes crear tu propia rama.
    ```
    git branch rama-de-ejemplo
    ```

5. Para empezar a trabajar sobre la rama creada, puedes ejecutar el siguiente comando:

    ```
    git checkout rama-de-ejemplo
    ```

    En este punto ya puedes comenzar a hacer tus cambios. Si no haces el `checkout` a tu rama, puede que afectes a otras ramas e interrumpir el trabajo de los demás. Recuerda que no te dejará hacer `push` a `main`. 

6. Después de hacer tus cambios, haz pruebas unitarias e

7. Se checa de manera automática que se cumpla ciertas reglas de sintaxis. Algunas de estas reglas son necesarias para tener una sintaxis consistente en todo el repositorio. La mayoría de las reglas se pueden aplicar de manera automática corriendo el siguiente comando:
    ```
    dotnet format
    ```
    En caso de enviar tus cambios y todavía tener pendientes de sintaxis, tendrás que checar de forma manual cómo arreglarlo. Te puedes guiar de la [documentación de StyleCop](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/tree/master/documentation) y pedir ayuda al equipo. Para checar de forma local la sintaxis, puedes correr el siguiente comando:

    ```
    dotnet format --verify-no-changes --verbosity m --severity warn
    ```

