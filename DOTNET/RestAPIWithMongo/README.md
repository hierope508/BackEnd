# Rest API using MongoDB
Rest API using MongoDB


# Pre requisitos:
	.NET CORE 5.0 (https://dotnet.microsoft.com/download)
	Visual Studio 2019 ou VS Code
	Instancia do MongoDB (Caso precise localmente -> https://www.mongodb.com/try/download/community)

# Instalação
	1 - Configurar instancia do mongoDB utilizando os comandos abaixo:
		1 - Configurar variavel de ambiente PATH para que o mongo esteja acessivel de qualquer local(https://www.c-sharpcorner.com/article/how-to-set-up-and-starts-with-mongodb/#:~:text=Click%20on%20environment%20variables%20button,Program%20Files%5CMongoDB%5C”)
		2 - No PowerShell ou CMD:
			1 - mongo
			2 - use DesafioZeBackEndDB
			3 - db.createCollection('Partners')
	
	2 - Alterar arquivo "RestAPIWithMongo\RestAPIWithMongo\appsettings.json" com os parametros CollectionName, ConnectionString e DatabaseName para os configurados na instancia do mongoDB

# Como rodar
	1 - Visual Studio:
		1 - Abrir arquivo RestAPIWithMongo.sln
		2 - Restaurar Pacotes NuGet
		3 - Executar projeto (F5)
		4 - Consumir metodos utilizando a pagina do Swagger que é aberta ou utilizando sua ferramenta de preferencia
			Metodos: /Partner GET, POST
					/ /PartnerLocation GET

	2 - VsCode
		0 - Instalar extensão NuGet Package Manager
		1 - Abrir pasta \RestAPIWithMongo\RestAPIWithMongo
		2 - Restaurar pacotes Nuget
		3 - Executar projeto (F5)
		4 - Consumir API pela ferramenta de preferencia ou utilizando o Swagger no navegador(Ex: https://localhost:5001/swagger/index.html)

# Deploy
	1 - Compilar projeto em modo Release
	2 - Utilizar a ferramenta de deploy do Visual Studio caso destino seja um Windows server com IIS ou Azure
	3 - Caso contrário, copiar binários do caminho bin\Release\net5.0 para servidor destino

