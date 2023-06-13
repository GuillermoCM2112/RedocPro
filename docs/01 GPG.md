# Clave GPG
## Requerimientos
   
   1. El usuario debe tener instalado [Gnupg](https://www.gnupg.org/download) y [Git Bash](https://git-scm.com/downloads) para usuarios con Windows.
   2. El usuario debe tener instalado [Brew](https://brew.sh/index_es) para usuarios con MacBook.

## Generación con MacBook

1. Abre la Terminal.

2. Verifica si ya tienes instalado GPG en tu Mac escribiendo el siguiente comando y presionando enter:
 ```
    gpg --version  
 ```
   *NOTA: GPG ya está instalado, verás la versión instalada y podrás continuar con el paso 4. Si no lo tienes instalado, continua con el paso 3.*

3. Si no tiene GPG, el Usuario instala GPG con Homebrew.
 ```
    brew install gnupg
 ```
4. El Usuario le indica a GPG que genere una clave GPG.
    * GPG solicita al Usuario la información requerida para generar la clave (nombre, dirección de correo electrónico, contraseña, etc.).
    * Es muy importante que la logitud de la clave sea de: 4,096

6. El Usuario ingresa la información requerida para generar sus clave gpg. 
   * Exportar la clave 
```
    gpg --full-generate-key
    gpg --list-secret-keys --keyid-format=long
```
   * Copia el ID de la clave que acabas de generar (debería tener el formato 4096R/XXXXXXXXXXXXXXXX).
   * Configura Git para usar tu clave de firma ejecutando los siguientes comandos:
```
    git config --global user.signingkey XXXXXXXXXXXXXXXX
    git config --global commit.gpgsign true
```
    
7. Se obtiene la clave gpg en la terminal para exportarla a Github
```
    gpg --armor --export [key_id]
```
8. GPG muestra la clave generada al Usuario.

9. La clave generada se guarda dentro de Github en el apartado de [GPG keys](https://github.com/settings/keys)

10. Prueba que puedas firmar tus commits 
    * El siguiente comando mostrara tu configuración, la cual debe ser parecida a la siguiente:
    
```
    user.signingkey=[Key]
    gpg.program=gpg2
    commit.gpgsign=true
    git commit -S -m “[Develop] Comment”
```

11. En caso de no ser exitoso, ejecuta lo siguiente:

```
    brew install pinentry-mac
    echo "pinentry-program $(which pinentry-mac)" >> ~/.gnupg/gpg-agent.conf
    killall gpg-agent
    $ if [ -r ~/.bash_profile ]; then echo 'export GPG_TTY=$(tty)' >> ~/.bash_profile; \

    else echo 'export GPG_TTY=$(tty)' >> ~/.profile; fi
    
    $ if [ -r ~/.zshrc ]; then echo 'export GPG_TTY=$(tty)' >> ~/.zshrc; \

   else echo 'export GPG_TTY=$(tty)' >> ~/.zprofile; fi
```

12. En caso de seguir con problemas seguir la siguiente secuencia:

```
    brew uninstall gpg
    brew install gpg2
    brew install pinentry-mac 
    gpg --full-generate-key 
```

   * Obten la key generada: 
   
```
    gpg --list-keys
```

Actualiza la key en local
```
    git config --global user.signingkey <Key de tu list>
    git config --global gpg.program /usr/local/bin/gpg
    git config --global commit.gpgsign true
```

Exporta tu Key a GitHub :

```
    gpg --armor --export <key> 
```

Agrega la key a GitHub desde GPG keys:   

Si el error a un persiste ejecuta el siguiente comando:

```
    test -r ~/.bash_profile && echo 'export GPG_TTY=$(tty)' >> ~/.bash_profile
    echo 'export GPG_TTY=$(tty)' >> ~/.profile
```

*NOTA: Si el error aun persiste:

   * *Instala: https://gpgtools.org* 
   * *Firma la clave que utilizaste presionando "Sign" en la barra de menú: Key -> Sign*.

## Generación con Windows

1. Correr el comando para verificar si ya existe alguna clave creada.
```
    gpg --list-secret-keys --keyid-format=long
```
2 Si no existe una clave se debe generar con el siguiente comando o en caso contrario pasar al paso 4):
```
    gpg --full-generate-key
```
  * Seleccionar el tipo de llave por defecto (RSA and RSA).
  * Seleccionar la longitud de bits por defecto (3072).
  * Seleccionar el tiempo de expiración por defecto(0) y confirmar.
  * Escribir tu nombre, correo electrónico, comentario opcional y Passhphrase y confirmarlos.

4. Ejecutar el siguiente comando para visualizar la nueva llave existente:
```
    gpg --list-secret-keys --keyid-format=long
```
   * Copiar el Id de la clave: [ key_id ] 

   * Ejecutar el siguiente comando
```
    gpg --armor --export [key_id]
```
   * Copiar la clave GPG, incluyendo comentarios
   * Pegar la clave completa en https://github.com/settings/keys  e ingresa el título deseado
   * Ejecutar el comando con el ID de la clave GPG
```
    git config --global user.signingkey [ key_id ]
```
