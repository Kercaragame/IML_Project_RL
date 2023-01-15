## Training_NoAlea_1

### Set Up
Grace aux infos que nous avons pu avoir avec les trainings précédents. Nous allons directement sur la solution la plus optimisé que nous avions trouvé.

### Résultats
Nous obtenons des résultats tout à fait satisfaisant mais il faudrait train plus longtemps l'IA

## Training_NoAlea_2

### Set Up 
Temps de training multiplié par 2

### Résultats
Les résultats dépendent trop de la carte que nous avons pour les mêmes settings je n'ai pas les mêmes résultats ce qui peut poser problèmes.

## Training_NoAlea_3

### Set Up 
Pour ce training nous n’allons pas besoin de changer les paramètres de l'arène pour avoir chaque arène aléatoire donc l'IA s'entrainera sur 12 arènes différentes 

### Résultat
Il est très encourageant l'IA apprend bien voire très bien les résultats de mean reward sont correct. Cependant il faut remettre en contexte que la reward diminue avec le temps 

## Training_NoAlea_3_long

### Set up 
Pour ce training nous passons le temps d'entrainement de 2 millions de step à 5 millions

### Résultats 
Il n'y a pas grand changement en termes de mean reward par rapport à l'entrainement précédent. Alors que cet entrainement est 2.5 fois plus long que le précédent.

## Training_NoAlea_4 

### Set Up 
Nous allons changer la valeur de la reward diminuant avec le temps, nous allons la passer de 0.001f a 0.0001f. Cette valeur est aussi multipliée à la valeur de la distance entre le robot et l'objectif.

Nous allons aussi augmenter le temps de training de 2 millions de step a 2.5 millions de step

### Résultat
L'IA apprends au moins aussi bien que précédemment et options des résultats tout à fait satisfaisant
