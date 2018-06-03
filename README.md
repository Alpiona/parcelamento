# Programa para simulação de parcelamentos
* Para qualquer método, é necessário o valor do débito ("vlrDebito") e a quantidade de parcelas ("numParcelas").
* A URL base utilizada é "http://localhost:50252", porém pode ser alterada no arquivo "Properties/launchSettings.json" em "applicationUrl".
* Se necessário, utilizar ponto (".") para centavos.

# Método GET

```
GET /api/simulacao/{vlrDebito}/{numParcelas}

Ex: /api/simulacao/1234.24/10
```
# Método POST
* Para fazer a simulação usando POST é nessário as informações serem enviadas como JSON.
```
POST /api/simulacao/
```
* Exemplo:
```javascript
{
  "vlrDebito":"2200",
  "numParcelas":20
}
```
