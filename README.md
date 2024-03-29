# Lista de Heróis - Backend

Este é o backend do projeto Lista de Heróis. Este projeto é responsável por fornecer uma API RESTful para gerenciar uma lista de heróis. O projeto é desenvolvido usando .NET.

## Instalação

Siga estas etapas para instalar e executar o projeto:

0. A Query de criação do db se encontra na pasta da Api, query.sql
1. Clone o repositório `git clone https://github.com/seu-usuario/lista-herois-back.git`
2. Navegue até a pasta do projeto `cd .\lista-herois-back\super-herois-api\`
3. Execute `dotnet restore` para restaurar as dependências do projeto
4. Configure a string de conexão ao BD no arquivo appsettings
5. Execute `dotnet run` para iniciar o servidor

## API

A API fornece os seguintes endpoints:

- `GET /api/herois`: Retorna uma lista de todos os heróis
- `POST /api/herois`: Cria um novo herói
- `GET /api/herois/{id}`: Retorna detalhes de um herói específico
- `PUT /api/herois/{id}`: Atualiza um herói específico
- `DELETE /api/herois/{id}`: Deleta um herói específico
