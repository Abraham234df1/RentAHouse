Crea el archivo Data/ConexionBD.cs con una clase ConexionBD que reciba
IConfiguration por constructor, lea la cadena de conexión "ConexionSQL"
desde appsettings.json, y exponga un método ObtenerConexion() que
retorne un SqlConnection. Esta clase solo debe encargarse de la
conexión (principio de responsabilidad única). También actualiza
appsettings.json agregando la sección ConnectionStrings con la clave
ConexionSQL apuntando a Server=localhost;Database=RentaDepartamentos;
Trusted_Connection=True;TrustServerCertificate=True;

Data Source=MANUEL_ROSADO\SQLEXPRESS;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name="SQL Server Management Studio";Command Timeout=0

