# 🌍 Exchange Rate API

> **Checkpoint 4° Avaliativo da disciplina de Advanced Business With .NET**

## 📜 Descrição

Este projeto é uma API de consulta desenvolvida em .NET que consulta o endpoint [ExchangeRate API](https://v6.exchangerate-api.com) para obter a taxa de câmbio mais recente do dólar americano (USD) para o real brasileiro (BRL).

## 🛠️ Funcionalidades

- **Endpoint**: `/api/exchange`
- **Método**: `GET`
- **Descrição**: Retorna a taxa de câmbio atual do USD para BRL.

## 📂 Estrutura do Projeto

- **Models**
  - `IConversionRate`: Interface que define a estrutura para as taxas de câmbio.
  - `ConversionRate`: Implementa a interface `IConversionRate` e representa a taxa de câmbio para o BRL.

- **Controllers**
  - `IExchangeController`: Interface que define o método para obter a taxa de câmbio.
  - `ExchangeController`: Implementa a interface `IExchangeController` e contém a lógica para chamar a API externa e retornar a taxa de câmbio.


## ⚙️ Configuração

1. **Chave da API**
   - Substitua `API_KEY` na constante `ApiUrl` em `ExchangeController` pela sua chave de API real.

2. **Instalação de Dependências**
   - Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/download) instalado.
   - Restaure as dependências do projeto executando:
     ```bash
     dotnet restore
     ```

3. **Execução**
   - Para executar o projeto localmente, use o comando:
     ```bash
     dotnet run
     ```
   - A API estará disponível em `http://localhost:5000/api/exchange`.

## ✅ Testes

- **Endpoint**: `/api/exchange`
- **Método**: `GET`
- **Resposta Esperada**:
  ```json
  {
    "CurrencyPair": "USD/BRL",
    "Rate": 5.4969,
    "Date": "2024-08-28T00:00:00Z"
  }
  ```

## 📚 Documentação

A documentação da API está disponível em Swagger, que fornece detalhes sobre os endpoints e como usá-los. Acesse a documentação em:
```https
    http://localhost:5000/swagger
```

> [!NOTE]
> O link Swagger só estará disponível após iniciar o projeto localmente.

## 💻 Tecnologias

As seguintes ferramentas foram usadas neste projeto:

### 🖥️ Ambientes de Desenvolvimento Integrado (IDEs):
![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)


### 📚 Linguagem de Programação:
![CSharp](https://img.shields.io/badge/CSharp-4CAF50?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=.net&logoColor=white)

## 🔗 Projeto no Azure DevOps

O código-fonte e a documentação adicional estão disponíveis no [repositório público do Azure DevOps](https://dev.azure.com/lalahaylou/exchange-rate-api).
