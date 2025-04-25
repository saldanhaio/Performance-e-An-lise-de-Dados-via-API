# Codecon Challenge

Este repositório contém a implementação de uma API para o desafio técnico da Codecon, onde foram feitos testes de performance em endpoints específicos relacionados ao gerenciamento de usuários e informações sobre os mesmos.

## Endpoints

A API disponibiliza a seguinte rota:

### `GET /api/evaluation/evaluation`

Esse endpoint realiza testes de performance nos seguintes endpoints internos da aplicação, medindo o tempo de execução e verificando a validade dos dados retornados.

#### Testes realizados:
1. **/superusers** - Retorna a lista de superusuários.
2. **/top-countries** - Retorna a lista de países com mais usuários.
3. **/team-insights** - Retorna informações sobre equipes.
4. **/active-users-per-day** - Retorna a quantidade de usuários ativos por dia.

Cada teste retorna o seguinte resultado:
- **Endpoint**: O caminho do endpoint testado.
- **Status**: O status HTTP (200 em todos os casos, se tudo correr bem).
- **Time**: O tempo de execução do teste.
- **IsValidJson**: Indica se a resposta foi um JSON válido.

### Exemplo de Resposta:

```json
{
  "EvaluationResults": [
    {
      "Endpoint": "/superusers",
      "Status": 200,
      "Time": "50ms",
      "IsValidJson": true
    },
    {
      "Endpoint": "/top-countries",
      "Status": 200,
      "Time": "40ms",
      "IsValidJson": true
    },
    {
      "Endpoint": "/team-insights",
      "Status": 200,
      "Time": "45ms",
      "IsValidJson": true
    },
    {
      "Endpoint": "/active-users-per-day",
      "Status": 200,
      "Time": "35ms",
      "IsValidJson": true
    }
  ],
  "Timestamp": "2025-04-24T10:30:00Z"
}
