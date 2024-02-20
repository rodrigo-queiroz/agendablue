![Template AgendaBlue](https://github.com/rodrigo-queiroz/agendablue/assets/19469902/2df5c405-6ed2-4f29-8dae-dfad4d68ba3b)
# Agenda Blue Tecnology

Desenvolvimento de um CRUD simples para uma Agenda solicitada pela empresa Blue Technology.

## 🔨 Funcionalidades do projeto
- `Funcionalidade 1` `Cadastro de Usuários`: Nosso sistema precisa estar apto a cadastrar os usuários na agenda. Para cadastrar, devem ser informados nome, e-mail válido e telefone.
- `Funcionalidade 2` `Atualizar Usuários`: Para que o sistema fique em dia, atualize os dados dos usuárioos cadastrados.
- `Funcionalidade 3` `Remover Usuários`: Para remoção de um usuário, o sistema faz as perguntas se realmente você deseja remover este usuário.
- `Funcionalidade 4` `Filtrar Usuários`: Nosso sistema vem com um filtro para que você não fique muito tempo pesquisando na sua agenda.

#### Endpoint para visualizar o frontend: http://localhost:3000/
#### Endpoint para acessar o Swagger e fazer os testes da API: http://localhost:5000/swagger/index.html

> [!WARNING]
> Requisitos para instalar o projeto em sua máquina:
> - Faça o clone do deste projeto;
> - Tenha instalado o Docker Desktop na sua máquina
> - Na pasta principal onde está localizado o docker-compose.yml, execute este comando:
```docker-compose up --build```

> ![image](https://github.com/rodrigo-queiroz/agendablue/assets/19469902/2aeae716-266e-496b-b74c-a0e9b5a2219a)


## ✔️ Técnicas e tecnologias utilizadas

#### 🔨 Containers
- client : Servidor Nginx para buildar o projeto em vue.js.
- server : Onde é publicado nossa aplicação em .NET 6.
- 
#### 🔨 FrontEnd
- ``Vue 3``
- ``Typescript``
- ``Vite``
- ``ESLint``
- ``Prettier``
- ``Escrita do código utilizando o Composition Api do Vue.js ``

#### 🔨 BackEnd
- ``Net 6``
- ``Arquitetura em CQRS``
- ``MediatR`` 
- ``Entity Framework Core ORM``
- ``FluentValidation e Filtros de validação``
- ``Testes unitários com o xUnity``
- ``Dependency Inversion, Repository Pattern``
- ``Swagger``

#### 🔨 Database
``EF Core In-Memory Database Provider``

