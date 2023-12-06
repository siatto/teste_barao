# Centro Universitário Barão de Mauá - Projeto de Gerenciamento de Estudantes

## Visão Geral

Este projeto foi desenvolvido para o departamento de Tecnologia da Informação do Centro Universitário Barão de Mauá. A ferramenta permite que usuários autenticados gerenciem estudantes e endereços de forma eficiente.

## Funcionalidades

- **Listagem de Estudantes e Endereços:** Visualize estudantes e endereços, com a capacidade de filtrar por nome.
- **Detalhes Protegidos:** Detalhes de estudantes são protegidos; é necessário autenticar para visualizar informações sensíveis.
- **Operações de CRUD:** Realize operações de criação, leitura, atualização e exclusão para estudantes e endereços.
- **Integração com ViaCEP:** Automatize a busca de endereços através da API ViaCEP utilizando o CEP.
- **Segurança:** Utilize JWT para autenticação e autorização, garantindo endpoints seguros.

## Requisitos de Login

- **Primeiro Acesso:** Ao acessar o gerenciador, crie um login fornecendo um código de autorização (código fixo: 000000).
  
- **Segurança:** Senhas são criptografadas para garantir a segurança do usuário.
  
## Tecnologias Utilizadas

- **Backend Framework:** ASP.NET Core
- **Frontend Framework:** Angular
- **Banco de Dados:** Entity Framework
- **API Externa:** ViaCEP
- **Documentação:** Swagger
- **Testes:** Unitários integrados ao projeto
- **Logging:** Utilização do Serilog
- **Autenticação e Autorização:** JWT

## Estrutura do Projeto

A estrutura do código foi cuidadosamente projetada para facilitar a manutenção e compreensão. O uso do Entity Framework contribui para um código mais limpo.

## Como Executar

1. Clone o repositório.
2. Configure as conexões com o banco de dados no arquivo de configuração.
3. Execute a aplicação.

## Documentação

Explore a API utilizando o Swagger. Após executar a aplicação, acesse `http://localhost:5000/swagger` no navegador.

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para melhorar este projeto e torná-lo ainda mais eficiente.
