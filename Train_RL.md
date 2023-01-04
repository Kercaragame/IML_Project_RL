# Training et Selection de l'IA de Reinforcement Learning

- [Installation](#installation)
- [Training](#training)
- [Comparaison des trainings](#comparaison-des-trainings)
- [Utilisation des trainings](#utilisation-des-trainings)

### Installation

Vérifier que la version de python installer est la 3.9.9.

Pour créer l'environnement virtuel il faut faire la commande :
```sh 
py -m venv <nom de l environnement virtuel créé>
```

Ensuite activer l'environnement virtuel pour pouvoir installer les bibliothèques nécessaires au bon fonctionnement du training sans impacter l'environnement python.
```sh 
<nom de l environnement virtuel créé>\Script\activate
```

Maintenant que vous êtes dans l'environnement virtuel nous allons pouvoir télécharger les modules nécessaires au training :

- torch 1.7.1+co11
- mlagents 

(Optionnel) Avant toute chose pensez à mettre à jour pip:
pip install --upgrade pip

Télécharger en premier torch. Cela va prends un peu de temps et de la place sur votre disque dure prévoyez au moins 5Go.
```sh
pip install torch~=1.7.1 -f https://download.pytorch.org/whl/torch_stable.html
```

Ensuite télécharger la dernière version de mlagents. Cette bibliothèque a besoin de nombreuses autres bibliothèques qui seront installer automatiquement.
```sh
pip install mlagents
```

Pour vérifier que mlagents a bien été installer faites la commande :
```sh
mlagents-learn --help
```

Si une liste d'argument s'affiche c'est que l'installation c'est bien passé vous allez pourvoir commencer le training

### Trainings

La commande pour les trainings est la suivante :
```sh
mlagents-learn <emplacement du fichier de configuration> --run-id=<nom de l training>
```

L'emplacement du fichier de configuration correspond au fichier de configuration de l'IA de reinforcement learning. Ce fichier est situé dans le dossier Config\default_configuration.yaml

Le nom de l'training correspond au nom que vous voulez donnez à votre IA de reinforcement learning.

La commande que nous allons utiliser est :
mlagents-learn Config\default_configuration.yaml --run-id=Training1

Pour plus d'informations sur la commande est les potentiels ajouts que vous voulez faire voici le lien vers la documentation officiel de la commande : https://github.com/Unity-Technologies/ml-agents/blob/com.unity.ml-agents_2.0.1/docs/Training-ML-Agents.md

### Comparaison des trainings

Suite aux trainings nous regardons les différences de performances entre les différents fichiers de configuration que nous avons utilisé. Nous avons pour ça la commande :
```sh
tensorboard --logdir <emplacement du dossier avec les résultats>
```

Le dossier avec les résultats est le dossier *results* qui est l'emplacement ou est stocké tous les trainings réalisés plus tôt.

(Optionnel) Vous pouvez installer la bibliothèque tensorflow comme demandé lors de l'exécution de la commande mais cela n'est en rien obligatoire.

**TODO** :lien vers une autre page expliquant les différents graphes et ce que l'on y fait 

**ajouter photo montrant une fenetre de tensorboard**

### Utilisation des trainings

Suite à la phase d'training et la comparaison entre ceux-ci vous allez pouvoir choisir l'IA entrainée qui sera ensuite mise dans le robot.

Pour récupérer l'IA utilisable par unity il faudra aller chercher le fichier *.omnx* situé dans le dossier avec le nom de l'IA choisi puis dans le sous dossier *BasiqueAgent* qui correspond au nom que nous avons donné à l'IA dans Unity. 

**ajouter photo explicative**

Ensuite importer ce fichier dans Unity par un copier / coller. 

Enfin il faudra sélectionner l'agent dans Unity et dans les paramètres de la section "Behavior Parameters" dans l'option "Model" glisser le fichier .omnx que vous êtes allé chercher précédemment.

**ajouter photo explicative**

Vous pourrez maintenant utiliser le robot avec l'IA sélectionnée en cliquant sur le bouton play de Unity

