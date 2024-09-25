# Wish List App

Description : Application complète permettant de créer, des "Envies", de les visualiser et de les modifier (CRUD).  
Objectif : Apprendre le fonctionnement de ASP.Net Core avec une archi MVC.

# Etapes :

Je me suis basé sur le tutoriel de Microsoft : https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-8.0&tabs=visual-studio-code

## 1. Création du projet 
```shell
dotnet new mvc -o WishList
```
`dotnet new` => Création d'un nouveau projet
`mvc` => Nom du template
`-o WishList` => Dossier de sortie (ici ./WishList)

## 2. Création d'un Modèle de données
On créer le modèle de données pour permettre la génération automatique du controlleur et de la vue par l'outil `aspnet-codegenerator` 
./Models/Wish.cs
```c#
public class Wish
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> Tags { get; set; }
    public DateTime? DateTime { get; set; }
}
```

## 3. Génération automatique de la vue et du controlleur
Utilisation de l'outil `aspnet-codegenerator` :
```shell
dotnet aspnet-codegenerator controller -name WishController -m Wish -dc WishList.Data.WishListContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite
```
Explication des paramètres 
`dotnet aspnet-codegenerator` : Outil de génération automatique
`controller -name WishController` : génération du controlleur avec son nom
`-m Wish` : Nom du modèle
`-dc WishList.Data.WishListContext` : Data Context => Nom du contexte de données
`--relativeFolderPath Controllers` 	Chemin du dossier de sortie relatif (ici Controllers) pour créer les fichiers du controlleur (en lien avec le contexte).
`--useDefaultLayout` Template de vue (ici template par défaut)
`--referenceScriptLibraries` Ajoute _ValidationScriptsPartial aux pages Modifier et Créer. (TODO: Se renseigner en détail sur ces scripts)
`--databaseProvider sqlite` Nom du provider SQL (SQLite ou SQL Serveur)

## 4. Migration de la base de données

Utilisation de EntityFramwork (`ef` dans la  CLI) permet la migration et donc la gestion de la base de données (Création, modification...)

Création d'une nouvelle migration nommée InitialCreate (Se retrouve dans ./Migrations/[DATETIME]_InitialCreate.cs)
```shell
dotnet ef migrations add InitialCreate
 ```

Mise à jour de la base de données vers la dernière migration (commande `up` du fichier InitialCreate)
```shell
dotnet ef database update
 ```