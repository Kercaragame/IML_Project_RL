## Training_Fay_1

Probleme Unity  -> recommencement

## Training_Fay_2

### Set up
Changement sur l'agent pour qu'il puisse voir les 2 obstacles
learning_rate :0.00003 -> 0.0001
hidden_layers : 2 -> 3

### Résultat
apprentissage inéfficace car l'agent n'atteint que tres peu l'objectif ou meme les murs

Voie d'amélioration augmenter la vitesse du robot

## Training_Fay_3

### Set up
changement sur la vitesse de l'agent multilication par 10
speed : 15 -> 150
learning-rate : 0.0001 -> 0.001
hidden_units : 128 -> 256

### Résultat
apprentissage plus éfficace qu'avant mais agent surement trop rapide. De plus doute sur l'utilité de l'augmentation du nbre de neuronnes

plafond de verre apparant à la moyenne de reward à 0.850 -> esquive pas assez efficace des obstacle 

Voie d'amélioration: 
diminuation de la vitesse du robot
augmentation de la reward négative lié au obstacle 
réduction du nombre de neuronnes

## Training_Fay_4

### Set up
Vu que nous avions grandement avancé à la dernière étape. Nous n'avons changé qu'un paramètre. Nous avons réduis le nombre de neuronnes dans les couches cachées.

hidden_units : 256 -> 128

# Résultats 
moins bons que la dernière fois donc nombre de neuronnes a augmenter pour une meilleur efficacité

## Training_Fay_5

### Set up 
changement de la vitesse du robot
speed : 150 -> 60
hidden_units : 128 -> 256

### Résultat
équivalant au Training_Fay_3 apprentissage un peu plus lent à cause de la vitesse du robot mais assez négligeable au bout de 500k époques.

Voie d'amélioration :
On a vu que le nombres de neuronnes influe beaucoup sur les performance de l'IA nous allons modifier ces paramètres (nombres de neuronnes par couches et aussi le nombres de couches)

## Training_Fay_6

### Set up
hidden_units : 256 -> 384
hidden_layers : 3 -> 2

Nous ne changeons pas le nombre de neuronnes mais nous le répartissons plus que sur 2 couches 

### Résultat
bien moins bon que les précédents et plus aléatoire en moyenne de récompense passant de 0.648 à 0.496 puis 0.598 en "seulement" 20k époques. L'IA reste donc bien trop aléatoire pour etre utilisable. De plus ayant un moyenne de récompense de 0.2 plus faible que les autres essais

Voie d'amélioration 
Augmenter le nombre de couches mais pas forcément le nombre de neuronnes en globale

## Training_Fay_7

### Set up 
hidden_units = 384 -> 192
hidden_layers 2 -> 4

Nous doublons le nombre de couches et gardons le meme nombre de neuronnes en globalité

### Résultat
résultat légèrement meilleur que l'entrainement *Training_Fay_6* cependant pas assez constant et pas au niveau du training 3 et 5.

Voie d'amélioration augmentation du nombre de nueronnes

## Training_Fay_8

### Set up
hidden_units = 192 -> 256

### Résultat
encore plus aléatoire qu'avant il y a donc un optimum de couche qui semble etre à 3 pour notre problème 

voie d'amélioration :
Retourner au valeur du training 5 puis essayer de modifier des valeurs pour l'améliorer.

Le problème que l'on a c'est que l'on peut trouver un optimum local car nous n'avons pas rechercher dans tous le domaine du possible le problèmeme étant qu'il y a beaucoup de paramètres à potentiellement changer. De plus ici nous ne nous concentrons que sur la technologie PPO. 

## Training_Fay_9

### Set up 
hidden_units : 256 -> 512
hidden_layers : 4 -> 3

### Résultat
moins bien un plus gros nombre de neuronne amène à plus d'instabilité 

## Training_Fay_10

### Set up 
même set up que Training-Fay_5

### Résultats
résultats assez bon avec un mean reward entre 0.75 et 0.80
Cependant encore des problèmes d'aléatoire même si avec une amplitude moins grande

## Training_Fay_11

### Set up 
Suppression de la reward en fonction de la distance

Changement sur les paramètres de l'entraineur (pas toucher jusqu'a présent) nous allons essayer d'augmenter la vitesse d'évolution
epsilon : 0.2 -> 0.3

### Résultat
Quasiment aucun changement par rapport au training précédant légèrement moins aléatoire 

## Training_Fay_12

### set up 
Nous allons voir si l'augmetation de l'epsilon compense la suppression de la reward en fonction de la distance

Changement sur l'un des parametre de l'entraineur
epsilon : 0.3 -> 0.2

### Résultat
Assez gros changement par rapport au training précédent beaucoup moins satisfaisant 

Voie d'amélioration :
- retour à un epsilon de 0.3
- retour de la reward en fonction de la distance

## Training_Fay_13

### Set up 
Nous allons effectué les changement que nous avions suposé au training précédent.
Retour de la reward en fonction de la distance

Retour de l'epsilon de l'entraineur à 0.3
epsilon : 0.2 -> 0.3

### Résultat
entrainement absolument pas concluant. La reward moyenne n'a quasiment jamais été aussi aléatoirepassant de 0.636 à 0.275. Cela provient surement de l'epsilon qui tend l'entrainement à beaucoup évoluer suremenent trop dans ce cas 

Voie d'amélioration :
- diminution de l'epsilon à 0.1 (plus petit que le training 10)


## Training_Fay_14

### Set Up
Modification de l'entraineur
epsilon : 0.3 -> 0.1

Cela dervrait réduire l'évolution cela aussi augmente indirectement l'influence de l'aléatoire qui correspond au paramètre beta

### Résultat
Comme prévu il y avait beaucoup d'aléatoire ce qui a donné un résultat inutilisable.


## Training_Obs5_1

### Set Up
Maintenant que nous avons des paramètres qui semble correct nous allons essayer d'augmenter le nombre d'obstacle
Nombre Obstacle = 2 -> 5
Il ne faut pas oublier d'augmenter le nombre de parametres que le robot doit "voir" 
Vector Observation : Space Size = 12 -> 21

Notre config est peut etre bonne pour 2 obstacles mais pour 5 je pense qu'il faudra augmenter le nombre de neuronnes

### Résultat
Le résultat est catastrophique le robot n'arrive que tres peu à aller vers l'objectif et finis dans un mur ou un obstacle.

Voie d'amélioration :
- Nous avions vu lors du training Training_Fay_4 que lorsque nous baissons le nombre de neuronne l'IA devient moins efficace, l'augmenter peut etre une bonne solution
- Augmenter le nombre d'époques dans le training peut aussi etre intéressant

## Training_Obs5_2

### Set Up 
Application des améliorations cités précédement
max_steps : 500000 -> 1000000

modification des paramètres du réseau de neuronnes:
hidden_units : 256 -> 512

### Résultats

