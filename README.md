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
  - Fonctionnalités :
    - resetRun() -> Permet de gérer le positionnement de l'agent et de l'objectif sur une map de taille petite
    - SuccesTask() -> Retour utilisateur pour voir l'évolution de l'entraînement
    - FailedTask() -> Retour utilisateur pour voir l'évolution de l'entraînement
- AreneManagerAdvanced hérite de AreneManager :
  - Fonctionnalités :
    - resetRun() -> Redéfini resetRun afin qu'elle soit efficace sur des environnements de taille grande avec des obstacles
    - initRun() -> Permet de gérer l'initialisation des entraînements afin de choisir le type d'aléatoires (Plusieurs map différentes, Un même type de map,...) ce qui permet d'entraîner notre agent de manière poussée sur différents schémas d'apprentissage
    - Update() -> Retour utilisateur pour voir ce qui influence les décisions de l'agent (Raycast ...)
    - generatedObsFromSave() -> Génération des obstacles de manière aléatoire.
    - checkDistance() -> Règles pour la génération des obstacles...
    - subscribeOBS() -> Permet de copier la structure d'une map sur d'autres maps afin d'accélérer l'entraînement

Ces scripts permettent toutes la gestion de la création de l'environnement aléatoirement ce qui est très important dans le processus d'entraînement d'un agent de manière efficace afin d'éviter l'overfitting sur un seul et même environnement. Ils permettent aussi de visualiser l'agent entraîner sur des maps choisies afin de voir si l'entraînement à été efficace et si l'agent RL réussi bien les tâches.

### Description de l'entrainement de l'IA

### Challenges
Nous avons rencontré plusieurs challenges lors de ce projet :

- La création de l'environnement aléatoire : En effet, la mise en place de l'algorithme permettant de créer un environnement généré aléatoirement soumis à plusieurs règles (distance minimum entre les obstacles, avec le joueur, entre l'objectif et le joueur, le fait que l'environnement puisse se détruire et se reconstruire de manière fluide et rapide pendant l'entraînement...) a pris beaucoup de temps et a nécessité plusieurs phases de test afin de le perfectionner et de le valider.
- Le choix et la gestion des données à suivre en entrée de notre réseau de neurones (position des obstacles vs système de raycast pour détecter les obstacles...)
- La parametrisation des hyperparametres de l'environnement. (Developpement par BENJI)
