# andersonpipicano

Repositorio personal que reúne varios proyectos y ejercicios académicos: una hoja de vida web, un CRUD en ASP.NET MVC, un generador de facturas en PDF con C# y una red social hecha en Django.

## Contenido

- **Hoja de vida web** — páginas HTML (`index.html`, `DatosPersonales.html`, `Estudios.html`, `Pasatiempo.html`, `Contacto.html`) construidas con Bootstrap.
- **CRUD en ASP.NET MVC** — controladores y vistas para `Actividad`, `Entidad` y alertas (`Crud/`, `alert/`).
- **ProyectoPDF** — aplicación Windows Forms en C# que genera facturas en PDF a partir de una plantilla HTML usando iTextSharp (`ProyectoPDF/Proyecto/`).
- **social_django** — red social en Django con publicaciones, perfiles y seguimiento de usuarios (`social_django/`).

## Tecnologías

- HTML, CSS, Bootstrap
- C#, ASP.NET MVC, Windows Forms, iTextSharp
- Python, Django, SQLite

## Instalación

- **ProyectoPDF**: abrir `ProyectoPDF/ProyectoPDF.sln` en Visual Studio y compilar.
- **social_django**: crear un entorno virtual, instalar las dependencias de `social_django/requirements.txt` (Django 3.1) y ejecutar `python manage.py runserver` desde la carpeta `social_django/`.

## Licencia

MIT
