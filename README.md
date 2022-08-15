# Projeto Atividade Api

Este projeto foi criado para apresentação solicitada pela empresa GFT do curso de treinamento por meio do instrutor Clécio Gomes. Este com o fundamento de criar uma Api Rest utilizando as tecnologias .Net e Entity FrameWork fornecendo ligação com banco de dados WorkBench.


### Pré requisitos 

Para uma boa navegação e um experimento adequado, é recomendado a utilização da ferramenta de suporte postmam.

* Clone o repositório na sua plataforma e utilize o comando: git clone "Link do repositório SSH/HTTPS".

* Para dar início ao seu projeto e para que ele se mantenha com o servidor ativo abra o terminal do Visutal Studeo Code e digite o comando: dotnet watch run.

### Acessos Http
* Para ter acesso aos endpoints que requerem autorização, você terá que efetuar o login através da ferramenta postmam. Email para acesso:
* "Email" = "Veterinario@gft.com", "Senha" = "Gft@1234".

* O Usuario comum terá acesso ao metodo Get da classe atendimentos, "Para que os clientes possam observar os registros de atendimentos de seus animais". Mas o mesmo será restrito de outras ações, nas quais apenas o usuario Veterinário terá acesso geral.

### Instalações de pacotes necessárias para a execução do projeto:
```
    <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="5.0.17" />
    
    <PackageReference Include="Swashbuckle.AspNetCore" Version="5.6.3" />
    
    <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="5.0.17" />

    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="5.0.17" />

    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.0.17" />

    <PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="5.0.4" />

    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="5.0.17" />
    
    <PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="5.0.5" />
```

### Instalações essências

É essêncial que você tenha instalado em sua ferramenta de trabalho estas bibliotecas e aplicativos para uma experiência completa.

Comando para instalar ferramentas para aceitar a Cli do entity

    dotnet tool install --global dotnet-ef

é interessante que também utilize o app Postmam para visualizações específicas do projeto.

    https://www.postman.com/downloads/

    
### Documentações - Notion
O projeto foi documentado na plataforma Notion, com anotações do passo a passo de todo procedimento percorrido.

Link Notion: https://www.notion.so/API-Treinamento-e0a322cd13714e64a9b389f18cf00e4f



## Autores

  - **Douglas Vinicius Vicente** - *Desenvolvimento do projeto* -
    https://git.gft.com/dsve

