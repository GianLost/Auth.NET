# Auth.NET 🔐

**Auth.NET** é uma solução moderna e flexível de **autenticação e gerenciamento de usuários** para aplicações .NET. Foi projetado para ser um substituto de fácil integração para o sistema de autenticação padrão do .NET, proporcionando uma base robusta para cadastro, login e gerenciamento de usuários com recursos adicionais como segurança aprimorada e customização fácil.

Se você está criando uma aplicação .NET e precisa de uma solução de autenticação pronta para usar, o **Auth.NET** oferece uma implementação pré-configurada que pode ser facilmente integrada e adaptada à sua realidade.

## 🚀 Objetivo

O principal objetivo do **Auth.NET** é fornecer um sistema de autenticação fácil de usar e **extensível**, com as melhores práticas de segurança, que pode ser rapidamente integrado a qualquer aplicação .NET. Ele oferece uma estrutura base para **criar, autenticar, atualizar e gerenciar usuários**.

O projeto está estruturado para ser simples de usar e fácil de adaptar, permitindo que qualquer desenvolvedor consiga implementá-lo e personalizá-lo conforme as necessidades do seu sistema.

## 🔑 Recursos

- **Cadastro e autenticação de usuários**: Com base em senha segura e proteção contra ataques.
- **Validação de e-mail e senha forte**: Inclui verificações robustas para garantir a integridade das credenciais.
- **Token JWT para autenticação**: Integração nativa com tokens JWT para autenticação sem estado.
- **Segurança**: Criptografia de senhas, validação de dados e práticas recomendadas de segurança.
- **Customização fácil**: A estrutura modular permite que você adapte a implementação às necessidades específicas de seu projeto.
- **Documentação completa**: Exemplos práticos de como usar e adaptar o projeto.
- **Estrutura de API RESTful**: Ideal para integração com outros sistemas e aplicações web.

## 📦 Estrutura do Projeto

A solução está organizada de maneira clara para facilitar a navegação e personalização. A estrutura básica do projeto é a seguinte:

```
Auth.NET
│
├── src
│   ├── Auth.NET.Libs          # Biblioteca de funcionalidades essenciais de autenticação
│   ├── Auth.NET.Infrastructure # Camada de infraestrutura (ex: repositórios, banco de dados)
│   ├── Auth.NET.UI.RCL        # Componentes reutilizáveis de interface (Razor Components)
│   ├── Auth.NET.API           # API para gerenciar autenticação e usuários
│   └── AuthSample             # Exemplo de aplicação que utiliza a solução
│
├── tests
│   ├── Auth.NET.Tests         # Testes unitários
│   └── Auth.NET.IntegrationTests # Testes de integração
│
├── Auth.NET.sln               # Solução geral do projeto
└── README.md                  # Documentação do projeto
```

## 💻 Como Usar

1. **Clone o repositório**:
   ```bash
   git clone https://github.com/GianLost/Auth.NET.git
   cd Auth.NET
   ```

2. **Instale as dependências**:
   - Para os projetos, basta restaurar os pacotes NuGet.
   ```bash
   dotnet restore
   ```

3. **Compile e rode a solução**:
   - Compile a solução e execute a aplicação de exemplo.
   ```bash
   dotnet build
   dotnet run --project AuthSample
   ```

4. **Configuração do banco de dados**:
   - Configure a string de conexão no arquivo `appsettings.json`.
   - Execute as migrações do EF Core:
   ```bash
   dotnet ef database update --project Auth.NET.Infrastructure
   ```

## 🛠️ Como Personalizar

O **Auth.NET** foi projetado para ser altamente configurável. Para personalizar a implementação de autenticação:

- **Modelos de dados**: Você pode extender a classe `TUser` para adicionar novos campos.
- **Autenticação e autorização**: Modifique a lógica de autenticação no projeto `Auth.NET.API`.
- **UI**: Adapte a interface do usuário no projeto `Auth.NET.UI.RCL`.

## 📄 Licença

Este projeto está licenciado sob a **MIT License** - veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 🧑‍💻 Contribuindo

Contribuições são bem-vindas! Se você encontrar um bug ou tiver uma sugestão de melhoria, fique à vontade para abrir um **issue** ou fazer um **pull request**.

### Passos para contribuir:
1. Faça um **fork** do repositório.
2. Crie uma **branch** para a sua funcionalidade: `git checkout -b minha-nova-funcionalidade`.
3. Faça **commit** das suas alterações: `git commit -am 'Adiciona nova funcionalidade'`.
4. Faça o **push** para a branch: `git push origin minha-nova-funcionalidade`.
5. Abra um **pull request**.

## 📞 Contato

Se tiver dúvidas ou precisar de suporte, não hesite em me contatar:

- E-mail: [gianluca19993m@gmail.com](mailto:gianluca19993m@gmail.com)
- GitHub: [https://github.com/GianLost](https://github.com/GianLost)

---

Agradecemos por utilizar **Auth.NET**! 🚀

⚡️ **Simples, seguro e pronto para uso!**