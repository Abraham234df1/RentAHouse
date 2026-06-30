Crea Services/IDepartamentoService.cs y Services/DepartamentoService.cs.
El servicio debe recibir IDepartamentoRepository por constructor y
validar antes de guardar o actualizar: la dirección no puede estar
vacía, el precio de renta debe ser mayor a cero, las habitaciones deben
ser mayores a cero, el estado debe ser Disponible, Rentado o
Mantenimiento, y si el estado es Rentado debe existir un Arrendatario.
Lanza excepciones de tipo ArgumentException con mensajes claros cuando
una validación falle.