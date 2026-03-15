# Finance.Net

API .NET 8 pour la gestion de transactions financieres (revenus/depenses), construite avec une architecture en couches et MongoDB.

## Sommaire

- [Vue d'ensemble](#vue-densemble)
- [Architecture](#architecture)
- [Stack technique](#stack-technique)
- [Structure du repository](#structure-du-repository)
- [Prerequis](#prerequis)
- [Configuration](#configuration)
- [Installation et lancement](#installation-et-lancement)
- [Documentation API (Swagger)](#documentation-api-swagger)
- [Endpoints](#endpoints)
- [Flux de traitement](#flux-de-traitement)
- [Tests](#tests)
- [Pistes d'amelioration](#pistes-damelioration)

## Vue d'ensemble

Le projet expose une API REST pour manipuler des transactions:

- creation d'une transaction
- recuperation de toutes les transactions
- recuperation d'une transaction par identifiant
- mise a jour d'une transaction
- suppression d'une transaction

Le backend est organise en 4 projets:

- `Financio.Api` (presentation HTTP)
- `Financio.Applications` (services metier)
- `Financio.Domain` (modeles, DTO, mapping, settings)
- `Financio.Infrastructure` (acces MongoDB et repository)

## Architecture

L'architecture suit une separation des responsabilites en couches:

1. **API**: expose les routes HTTP et gere les codes de retour.
2. **Application**: orchestre la logique metier via `ITransactionService`.
3. **Data Access**: encapsule les operations de persistance via `ITransactionDataAccess`.
4. **Infrastructure**: initialise MongoDB et fournit `IBaseRepository`.
5. **Domain**: contient les entites (`Transaction`), DTO (`TransactionDto`) et mapping.

Injection de dependances:

- `AddApplications()` enregistre les services metier.
- `AddInfrastructure(configuration)` configure MongoDB et le repository.

## Stack technique

- .NET 8 (`net8.0`)
- ASP.NET Core Web API
- MongoDB.Driver
- Swagger / OpenAPI (`Swashbuckle.AspNetCore`)
- CORS active pour un frontend local `http://localhost:3000`

## Structure du repository

```text
Financio.Api.sln
src/
	Financio.Api/
		Controllers/FinancioController.cs
		Program.cs
		appsettings.json
		appsettings.Development.json
	Financio.Applications/
		DependencyInjection.cs
		Services/Transactions/
			ITransactionService.cs
			TransactionService.cs
			DataAccess/
				ITransactionDataAccess.cs
				TransactionDataAccess.cs
	Financio.Domain/
		Models/Transaction.cs
		Models/RepositoryCollection.cs
		Dto/TransactionDto.cs
		Mapping/TransactionExtensions.cs
		Settings/MongoSettings.cs
	Financio.Infrastructure/
		DependencyInjection.cs
		Common/
			IBaseRepository.cs
			BaseRepository.cs
tests/
```

## Prerequis

- SDK .NET 8 installe
- MongoDB accessible localement ou a distance

Verification rapide:

```bash
dotnet --version
```

## Configuration

La configuration MongoDB est declaree dans `src/Financio.Api/appsettings.Development.json`.

Exemple:

```json
{
	"MongoDB": {
		"ConnectionString": "mongodb://localhost:27017",
		"DatabaseName": "Dev"
	}
}
```

Variables/cadres utiles:

- `ASPNETCORE_ENVIRONMENT=Development` pour charger la config de developpement.
- Profils de lancement disponibles dans `src/Financio.Api/Properties/launchSettings.json`.

URLs de developpement par defaut:

- `http://localhost:5112`
- `https://localhost:7287`

## Installation et lancement

Depuis la racine du repository:

```bash
dotnet restore
dotnet build Financio.Api.sln
dotnet run --project src/Financio.Api/Financio.Api.csproj
```

L'API demarre ensuite avec Swagger disponible en environnement `Development`.

## Documentation API (Swagger)

Une fois l'API lancee:

- `http://localhost:5112/swagger`
- ou `https://localhost:7287/swagger`

## Endpoints

Base route du controleur: `api/Financio`

1. `GET /api/Financio/GetAllTransactions`
2. `GET /api/Financio/GetById/{id}`
3. `POST /api/Financio/AddTransactions`
4. `PUT /api/Financio/Update/{id}`
5. `DELETE /api/Financio/Transaction/{id}`

### Exemple de payload (POST/PUT)

```json
{
	"amount": 120.5,
	"type": 0,
	"category": "Salaire",
	"description": "Versement mensuel",
	"date": "2026-03-15T10:00:00Z"
}
```

Valeurs du champ `type`:

- `0` = `Income`
- `1` = `Expense`

## Flux de traitement

Pour une requete API:

1. Le controleur recoit la requete HTTP.
2. Le service applicatif transforme les DTO en modeles domaine.
3. La couche DataAccess appelle le repository MongoDB.
4. Les resultats sont mappes vers des DTO pour la reponse.

## Tests

Le dossier `tests/` existe mais est actuellement vide.

Commande standard (quand des projets de test seront ajoutes):

```bash
dotnet test
```

## Pistes d'amelioration

- Ajouter des tests unitaires et d'integration.
- Ajouter une validation des DTO (FluentValidation ou DataAnnotations).
- Uniformiser le naming des routes REST (`/transactions`, `/transactions/{id}`, etc.).
- Ajouter une gestion globale des exceptions (middleware) avec format d'erreur standard.
- Ajouter une authentification/autorisation si l'API est exposee.