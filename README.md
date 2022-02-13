# SistemaDeLogin
Antes de poder arrancar el proyecto, se deben instalar 2 cosa. El Visual Studio y .NET 5 Runtime.

Visual Studio: https://visualstudio.microsoft.com/es/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false

.NET 5 Runtime: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-5.0.405-windows-x64-installer

Durante la instalacion de Visual Studio se nos preguntara que cargas de trabajo queremos instalar. Seleccionaremos "Desarrollo de ASP.NET y web" y "Desarrollo de escritorio .NET".

Si por algún casual no se nos ha abierto esta última pestaña de cargas de trabajo solo tendremos que buscar la aplicacion de Visual Studio Installer y ejecutarlo.

En esta aplicacion damos click sobre el boton "modificar" en la version de VS mas reciente y seleccionamos las cargas de trabajo mencionadas anteriormente.

Una vez todas las instalaciones hayan finalizado podemos arrancar el proyecto.

Abrimos la consola del administrador de paquetes nuget. Si no puede cargar correctamente, reiniciar el Visual Studio.

Una vez abierto, en la consola de VS ejecutar el comando "update-database" (sin las comillas).

Con todo esto hecho, el proyecto ya puede ser ejecutado.
