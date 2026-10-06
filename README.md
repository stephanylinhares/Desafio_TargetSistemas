# Desafio Técnico – Target Sistemas

Projeto desenvolvido em C# (.NET Web API) como parte do teste técnico para a Target Sistemas. A aplicação processa dados via API REST para cálculo de comissões de vendas, gestão de movimentações de estoque e cálculo de juros sobre títulos em atraso.

## Funcionalidades Implementadas

- **Item 1 – Cálculo de Comissões (`GET /api/Comissoes`)**: Processa o arquivo JSON de vendas, aplica a regra de três faixas de percentagem (0%, 1% e 5%) e agrupa o valor total e comissão por vendedor.
- **Item 2 – Movimentação de Estoque (`POST /api/Estoque/movimentar` e `GET /api/Estoque`)**: Regista entradas e saídas de mercadorias em memória, gerando um identificador único (GUID) por movimentação e retornando o saldo final do produto.
- **Item 3 – Cálculo de Juros por Atraso (`POST /api/Juros/calcular`)**: Compara a data de vencimento informada com a data atual, calcula os dias em atraso e aplica a multa diária de 2,5%.

## Tecnologias Utilizadas

- **C# / .NET Web API**
- **Swagger / OpenAPI** (para documentação e testes interativos)
- **Git / GitHub**

## Como Executar

1. Clona o repositório ou faz o download do código-fonte:
```bash
git clone [https://github.com/stephanylinhares/Desafio_TargetSistemas.git](https://github.com/stephanylinhares/Desafio_TargetSistemas.git)