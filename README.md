# Centro Universitário Barão de Mauá - Projeto de Gerenciamento de Estudantes

## Visão Geral

Este projeto foi desenvolvido para o departamento de Tecnologia da Informação do Centro Universitário Barão de Mauá. A ferramenta permite que usuários autenticados gerenciem estudantes e endereços de forma eficiente.

![image](https://github.com/siatto/barao/assets/6003300/5c5f7773-95d2-445a-a4ab-a1ab98c5c5a2)


## Funcionalidades

- **Listagem de Estudantes e Endereços:** Visualize estudantes e endereços, com a capacidade de filtrar por nome.
- **Detalhes Protegidos:** Detalhes de estudantes são protegidos; é necessário autenticar para visualizar informações sensíveis.
- **Operações de CRUD:** Realize operações de criação, leitura, atualização e exclusão para estudantes e endereços.
- **Integração com ViaCEP:** Automatize a busca de endereços através da API ViaCEP utilizando o CEP.
- **Segurança:** Utilize JWT para autenticação e autorização, garantindo endpoints seguros.
![image](https://github.com/siatto/barao/assets/6003300/8dc28cfd-f300-41b6-b742-83fa25b9e70c)


## Requisitos de Login

- **Primeiro Acesso:** Ao acessar o gerenciador, crie um login fornecendo um código de autorização (código fixo: 000000).
  
![image](https://github.com/siatto/barao/assets/6003300/a222b2b5-dc01-4135-8a1b-3285aa7a3257)
- **Segurança:** Senhas são criptografadas para garantir a segurança do usuário.
  
![image](https://github.com/siatto/barao/assets/6003300/c78b70a6-1f4d-4cb1-b04d-736d72000eac)

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

## Algumas Imagens

Filtros:
![image](https://github.com/siatto/barao/assets/6003300/de9010a6-7279-4421-a160-67b45232e385)

Detalhes:
![image](https://github.com/siatto/barao/assets/6003300/3eb661f4-ce6b-4514-abcd-eaf22168c5ea)

Basta digitar o CEP que os demais campos serão preenchidos:
![image](https://github.com/siatto/barao/assets/6003300/ce5844d4-7240-4162-ad52-fd8e96447b00)

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para melhorar este projeto e torná-lo ainda mais eficiente.
