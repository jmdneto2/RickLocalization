# RickLocalization 

> Instruçoes de como rodar a aplicação:

<strong>1 - Banco de Dados</strong>

<ul>
<li>1.1 - Criar banco de dados e rodar script:</li>

<li>1.2 - No SQL Server criar base com o nome RickLocalization;</li>

<li>1.3 - Em relação ao script:</li>

<li>1.3.1 - Caso queira rodar direto os scripts feitos pelo migration, rodar o que está dentro da pasta RickLocalization\Scripts\1 - 		MigrationScript.sql	</li>
  
<li>1.3.2 - Caso queira criar o script de migração ou dar o comando para atualizar a base pelo EF, abrir Solution no VStudio 2019 (Passo 3.1) e na tela do Package Manager Console,  apontar como Default Project, o projeto Repository. Também garantir que esteja dentro da pasta Repository da solution(cd .\RickLocalization.Repository):</li>
  
<li>1.3.2.1 - Na repository:</li>
    
<li>1.3.2.2 - Gerar Script:</li>
			
			dotnet ef --startup-project ..\RickLocalization\RickLocalization.WebApi.csproj migrations script			
	          
<li>1.3.2.3 - Ou Fazer com que o EF rode os comandos:</li>
						
			dotnet ef --startup-project ..\RickLocalization\RickLocalization.WebApi.csproj database update
			
<li>1.3.3 - Popular banco de dados com script .\RickLocalization\Scripts\2 - DbScripts.sql</li>

<strong>2 - Rodar front end:</strong>

<li>2.1 - Abrir prompt de comando, apontar para a pasta \RickLocalization\RickLocalization\ClientApp\ e rodar:</li>
		
	ng serve --watch

<strong>3 -  Debug Back End/Front pelo V Studio 2019:</strong>

<li>3.1 - Abrir RickLocalization\RickLocalization.sln;</li>

<li>3.2 - Aguardar/executar restore dependências;</li>

<li>3.3 - Botão Debug via IIS Express;</li>
</ul>
