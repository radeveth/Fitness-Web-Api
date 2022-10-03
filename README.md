# Fitness-Web-Api

## :pencil: Project Description
A Fitness Web API contains more than 1300 exercises with body part, target muscle equipment necessary, and a form and follow-through animation.

## :hammer: Used technologies
* [ASP.NET Core 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [Entity Framework Core 6.0](https://learn.microsoft.com/en-us/ef/core/)

## :loudspeaker: Api functions

### :pushpin: Exercises:
- GET - /api/exercises/all
- GET - /api/exercises/getExercise?id=?
- POST - /api/exercises/create
- DELETE - /api/exercises/delete?id=?

### :pushpin: Body Parts
- GET - /api/bodyParts/all
- GET - /api/bodyParts/getBodyPart?id=?
- POST - /api/bodyParts/create
- DELETE - /api/bodyParts/delete?id=?

### :pushpin: Equipments:
- GET - /api/equipment/all
- GET - /api/equipment/getEquipment?id=?
- POST - /api/equipment/create
- DELETE - /api/equipment/delete?id=?

### :pushpin: Target Muscles:
- GET - /api/targetMuscles/all 
- GET - /api/targetMuscles/getTargetMuscle?id=?
- POST - /api/targetMuscles/create
- DELETE - /api/targetMuscles/delete?id=?
