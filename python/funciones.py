from lib.operaciones import suma
from lib.operaciones import HttpRequestResponeRedirect as RE

valor = int(raw_input('ingresa un valor'))
valor2 = int(raw_input('ingresa un valor'))
operacion = raw_input('¿Que operaciones desea realizar : {s - r}')

if operacion.lower == 's':
    print suma(valor,valor2)

elif operacion.lower == 'r':
    print resta(valor,valor2)
    


print RE
