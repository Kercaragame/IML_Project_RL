## Training_2Obs_1

Problem Unity -> recommencement

## Training_2Obs_2

### Set up
Changement sur l'agent pour qu'il puisse voir les 2 obstacles
learning_rate :0.00003 -> 0.0001
hidden_layers : 2 -> 3

### Résultat
Apprentissage inefficace car l'agent n'atteint que très peu l'objectif ou même les murs

Voie d'amélioration augmenter la vitesse du robot

## Training_2Obs_3

### Set up
Changement sur la vitesse de l'agent multiplication par 10
speed : 15 -> 150
learning-rate : 0.0001 -> 0.001
hidden_units : 128 -> 256

### Résultat
Apprentissage plus efficace qu'avant mais agent surement trop rapide. De plus doute sur l'utilité de l'augmentation du nbre de neurones

Plafond de verre appartenant à la moyenne de reward à 0.850 -> esquive pas assez efficace des obstacles 

Voie d’amélioration : 
Diminution de la vitesse du robot
Augmentation de la reward négative lié aux obstacles 
Réduction du nombre de neurones

## Training_2Obs_4

### Set up
Vu que nous avions grandement avancé à la dernière étape. Nous n'avons changé qu'un paramètre. Nous avons réduit le nombre de neurones dans les couches cachées.

hidden_units : 256 -> 128

# Résultats 
Moins bons que la dernière fois donc nombre de neurones a augmenter pour une meilleur efficacité

## Training_2Obs_5

### Set up 
Changement de la vitesse du robot
speed : 150 -> 60
hidden_units : 128 -> 256

### Résultat
Équivalant au Training_2Obs_3 apprentissage un peu plus lent à cause de la vitesse du robot mais assez négligeable au bout de 500k step.

Voie d'amélioration :
On a vu que le nombres de neurones influe beaucoup sur les performances de l'IA nous allons modifier ces paramètres (nombres de neurones par couches et aussi le nombres de couches)

## Training_2Obs_6

### Set up
hidden_units : 256 -> 384
hidden_layers : 3 -> 2

Nous ne changeons pas le nombre de neuronnes mais nous le répartissons plus que sur 2 couches 

### Résultat
Bien moins bon que les précédents et plus aléatoire en moyenne de récompense passant de 0.648 à 0.496 puis 0.598 en "seulement" 20k époques. L'IA reste donc bien trop aléatoire pour être utilisable. De plus ayant une moyenne de récompense de 0.2 plus faible que les autres essais

Voie d'amélioration 
Augmenter le nombre de couches mais pas forcément le nombre de neurones en globale

## Training_2Obs_7

### Set up 
hidden_units = 384 -> 192
hidden_layers 2 -> 4

Nous doublons le nombre de couches et gardons le même nombre de neurones en globalité

### Résultat
Résultat légèrement meilleur que l'entrainement *Training_2Obs_6* cependant pas assez constant et pas au niveau du training 3 et 5.

Voie d'amélioration augmentation du nombre de neurones

## Training_2Obs_8

### Set up
hidden_units = 192 -> 256

### Résultat
Encore plus aléatoire qu'avant il y a donc un optimum de couche qui semble être à 3 pour notre problème 

Voie d'amélioration :
Retourner aux valeurs du training 5 puis essayer de modifier des valeurs pour l'améliorer.

Le problème que l'on a c'est que l'on peut trouver un optimum local car nous n'avons pas rechercher dans tous le domaine du possible le problème me étant qu'il y a beaucoup de paramètres à potentiellement changer. De plus ici nous ne nous concentrons que sur la technologie PPO. 

## Training_2Obs_9

### Set up 
hidden_units : 256 -> 512
hidden_layers : 4 -> 3

### Résultat
Moins bien un plus gros nombre de neurone amène à plus d'instabilité 

## Training_2Obs_10

### Set up 
Même set up que Training-2Obs_5

### Résultats
Résultats assez bon avec un mean reward entre 0.75 et 0.80
Cependant encore des problèmes d'aléatoire même si avec une amplitude moins grande

## Training_2Obs_11

### Set up 
Suppression de la reward en fonction de la distance

Changement sur les paramètres de l'entraineur (pas toucher jusqu'a présent) nous allons essayer d'augmenter la vitesse d'évolution
epsilon : 0.2 -> 0.3

### Résultat
Quasiment aucun changement par rapport au training précédant légèrement moins aléatoire 

## Training_2Obs_12

### set up 
Nous allons voir si l'augmentation de l'epsilon compense la suppression de la reward en fonction de la distance

Changement sur l'un des paramètres de l'entraineur
epsilon : 0.3 -> 0.2

### Résultat
Assez gros changement par rapport au training précédent beaucoup moins satisfaisant 

Voie d'amélioration :
- retour à un epsilon de 0.3
- retour de la reward en fonction de la distance

## Training_2Obs_13

### Set up 
Nous allons effectuer les changements que nous avions supposé au training précédent.
Retour de la reward en fonction de la distance

Retour de l'epsilon de l'entraineur à 0.3
epsilon : 0.2 -> 0.3

### Résultat
Entrainement absolument pas concluant. La reward moyenne n'a quasiment jamais été aussi aléatoire passant de 0.636 à 0.275. Cela provient surement de l'epsilon qui tend l'entrainement à beaucoup évoluer surmènent trop dans ce cas 

Voie d'amélioration :
- diminution de l'epsilon à 0.1 (plus petit que le training 10)

## Training_2Obs_14

### Set Up
Modification de l'entraineur
epsilon : 0.3 -> 0.1

Cela devrait réduire l'évolution cela aussi augmente indirectement l'influence de l'aléatoire qui correspond au paramètre beta

### Résultat
Comme prévu il y avait beaucoup d'aléatoire ce qui a donné un résultat inutilisable.

## Training_Obs5_1

### Set Up
Maintenant que nous avons des paramètres qui semble correct nous allons essayer d'augmenter le nombre d'obstacle
Nombre Obstacle = 2 -> 5
Il ne faut pas oublier d'augmenter le nombre de paramètres que le robot doit "voir" 
Vector Observation : Space Size = 12 -> 21

Notre config est peut être bonne pour 2 obstacles mais pour 5 je pense qu'il faudra augmenter le nombre de neurones

### Résultat
Le résultat est catastrophique le robot n'arrive que très peu à aller vers l'objectif et finis dans un mur ou un obstacle.

Voie d'amélioration :
- Nous avions vu lors du training Training_2Obs_4 que lorsque nous baissons le nombre de neurone l'IA devient moins efficace, l'augmenter peut-être une bonne solution
- Augmenter le nombre d'époques dans le training peut aussi être intéressant

## Training_Obs5_2

### Set Up 
Application des améliorations cités précédemment
max_steps : 500000 -> 1000000

modification des paramètres du réseau de neurones:
hidden_units : 256 -> 512

### Résultats

Les résultats ne sont pas utilisable car n’arrivant que très peu à atteindre l’objectif
