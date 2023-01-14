# IML_Project_RL

Ce projet a été réalisé dans le cadre du modules IML du Master SIIA de l'UBO. Ce projet a été réalisé par MODENA Enzo et GEORGES Benjamin.

Ce projet & été créé sur Unity 2021.3.9f1 (LTS) avec le package mlagents version 2.0.1

*A faire table des matières*
Ce que attend le prof :

- Objectives description (2-3 sentences): Describe the goal of this project.
- High-level description (1 paragraph): At a high-level, describe how you used IML
- Challenges (1 paragraph): Describe the challenges you faced and how you overcame them.
- Future work (1 paragraph): If you had more time, how would you improve your implementation?
- Takeaways (at least 2 bullet points with 2-3 sentences per bullet point): What are your key takeaways from this project that would help you/others in future robot programming assignments working in pairs? For each takeaway, provide a few sentences of elaboration.

### Description des Environnements virtuels créés
Pour gérer l'environnement nous avons conçu plusieurs scripts : 
- AreneManager
  - Fonctionnalitées :
    - resetRun() -> Permet de gerer le positionnement de l'agent et de l'objectif sur une map de taille petite
    - SuccesTask() -> Retour utilisateur pour voir l'évolution de l'entrainement
    - FailedTask() -> Retour utilisateur pour voir l'évolution de l'entrainement
- AreneManagerAdvanced hérite de AreneManger :
  - Fonctionnalitées :
    - resetRun() -> Redefini resetRun afin qu'elle soit efficace sur des environnment de taille grande avec des obs
    - initRun() -> Permet de gérer l'initialisation des entrainement afin de choisir le type d'aleatoires (Plusieurs map différentes,Un meme type de map) ce qui permet d'entrainer notre agent de manière pousser sur différent schema d'apprentissage
    - Update() -> Retour utilisateur pour voir ce qui influence les décisions de l'agent (Raycast ...)
    - generatedObsFromSave() -> Génération des obstacles de manière aléatoire.
    - checkDistance() -> Règles pour la généraiton des obstacles...
    - subscribeOBS() -> permet de copier la structure d'une map sur d'autres mapa fin d'accelerer l'entrainement

Ces scripts permettent toutes la gestion de la création de l'environnement aléatoirement ce qui est très important dans le processus d'entrainement d'un agent de manière efficace afin d'eviter l'overfitting sur un seul et meme environnement.

### Description de l'entrainement de l'IA
