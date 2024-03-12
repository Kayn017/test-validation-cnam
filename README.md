# Morpion App : Tests et validations

## I. Les difficultés liées à la validation

Le première grande difficultée liée à la validation du projet est la structure du code.  
Certaines fonctions sont très longues et peu lisibles, elles ont souvent trop de responsabilités et font trop de choses.  
Il est donc déjà plus difficile de savoir ce que la fonction fait et de tester les différentes parties de la fonction.

> **Exemple :** La fonction `BoucleJeu()` initialise la grille de jeu, demande aux joueurs de jouer à tour de rôle, effectue leurs actions, vérifie si un joueur a gagné, et affiche le résultat.  
> Il est donc plus difficile de tester individuellement la partie qui gère les inputs utilisateurs par exemple.

Une autre difficulté qui freine la validation du projet est le manque de séparation entre l'UI et la logique métier du programme.
Il est impossible de tester de manière automatisée les fonctions de logique, à cause des inputs utilisateurs demandé par l'UI.

De plus, certaines fonctions sont mal optimisées et présente de gros problèmes de conceptions, les rendant difficile à tester.

> **Exemple :** La fonction `verifVictoire()` est une fonction très longue et difficile à lire.  
> Il es très difficile de comprendre comment elle fonctionne exactement, et de corriger des bugs dedans.

```csharp
        public bool verifVictoire(char c) =>
             grille[0, 0] == c && grille[1, 0] == c && grille[2, 0] == c && grille[3, 0] == c ||
             grille[0, 1] == c && grille[1, 1] == c && grille[2, 1] == c && grille[3, 1] == c ||
             grille[0, 2] == c && grille[1, 2] == c && grille[2, 2] == c && grille[3, 2] == c ||
             grille[0, 3] == c && grille[1, 3] == c && grille[2, 3] == c && grille[3, 3] == c ||
             grille[0, 4] == c && grille[1, 4] == c && grille[2, 4] == c && grille[3, 4] == c ||
             grille[0, 5] == c && grille[1, 5] == c && grille[2, 5] == c && grille[3, 5] == c ||
             grille[0, 6] == c && grille[1, 6] == c && grille[2, 6] == c && grille[3, 6] == c ||
             grille[0, 0] == c && grille[0, 1] == c && grille[0, 2] == c && grille[0, 3] == c ||
             grille[0, 1] == c && grille[0, 2] == c && grille[0, 3] == c && grille[0, 4] == c ||
             grille[0, 2] == c && grille[0, 3] == c && grille[0, 3] == c && grille[0, 5] == c ||
             grille[0, 3] == c && grille[0, 4] == c && grille[0, 5] == c && grille[0, 6] == c ||
             grille[1, 0] == c && grille[1, 1] == c && grille[1, 2] == c && grille[1, 3] == c ||
             grille[1, 1] == c && grille[1, 2] == c && grille[1, 3] == c && grille[1, 4] == c ||
             grille[1, 2] == c && grille[1, 3] == c && grille[1, 4] == c && grille[1, 5] == c ||
             grille[1, 4] == c && grille[1, 4] == c && grille[1, 5] == c && grille[1, 6] == c ||
             grille[2, 0] == c && grille[2, 1] == c && grille[2, 2] == c && grille[2, 3] == c ||
             grille[2, 1] == c && grille[2, 2] == c && grille[2, 3] == c && grille[2, 4] == c ||
             grille[2, 2] == c && grille[2, 3] == c && grille[2, 3] == c && grille[2, 5] == c ||
             grille[2, 3] == c && grille[2, 4] == c && grille[2, 5] == c && grille[2, 6] == c ||
             grille[3, 0] == c && grille[3, 1] == c && grille[3, 2] == c && grille[3, 3] == c ||
             grille[3, 1] == c && grille[3, 2] == c && grille[3, 3] == c && grille[3, 4] == c ||
             grille[3, 2] == c && grille[3, 3] == c && grille[3, 4] == c && grille[3, 5] == c ||
             grille[3, 3] == c && grille[3, 4] == c && grille[3, 5] == c && grille[3, 6] == c ||
             grille[0, 0] == c && grille[1, 1] == c && grille[2, 2] == c && grille[3, 3] == c ||
             grille[0, 1] == c && grille[1, 2] == c && grille[2, 3] == c && grille[3, 4] == c ||
             grille[0, 2] == c && grille[1, 3] == c && grille[2, 4] == c && grille[3, 5] == c ||
             grille[0, 3] == c && grille[1, 4] == c && grille[2, 5] == c && grille[3, 6] == c ||
             grille[0, 3] == c && grille[1, 2] == c && grille[2, 1] == c && grille[3, 0] == c ||
             grille[0, 4] == c && grille[1, 4] == c && grille[2, 2] == c && grille[3, 1] == c ||
             grille[0, 5] == c && grille[1, 3] == c && grille[2, 3] == c && grille[3, 2] == c ||
             grille[0, 6] == c && grille[1, 5] == c && grille[2, 4] == c && grille[3, 3] == c;
```

Enfin, il a beaucoup de code dupliqué dans le projet, ce qui fait que l'on doit tester plusieurs fois la même chose alors qu'une seule fois aurait suffit, sur un projet mieux conçu.

## II. Les méthodes de résolution de ces problèmes

Pour résoudre ces problèmes, j'ai décidé de restructurer le projet pour le rendre plus testable et plus maintenable dans le futur.

Pour cela, j'ai commencé par restructurer le code sous forme de MVC, afin de séparer clairement l'UI, les données manipulées et la logique métier.

Après cela, j'ai opéré une séparation des fonctions afin que chaque fonction et chaque classe n'ai qu'une seule responsabilité. Cela m'a permis de déjà pouvoir tester chaque fonctionnalité plus facilement.
Cela passe par la création de nouvelles classes ( exemple : la classe `ConsoleGridGameView` qui récupère les fonctions chargées de l'affichage ), mais aussi d'interfaces et de classes abstraites afin d'éviter le plus possibles les couplages forts entre les classes.

J'ai fait le choix d'utiliser des interfaces pour affaiblir le plus possible les couplages entre les classes, mais j'ai aussi décidé de mettre des classes abstraites dans les situations où du code pouvait être partagé par les différentes classes qui en héritent.

> **Exemple :** Pour vérifier les différentes conditions de victoires, j'ai décidé de créer des Evaluators. 
> J'ai donc créé une interface `IEvaluator` qui servirait pour qu'ils puissent être tous utilisé de façon générique. 
> Cependant, pour les jeux du morpion et du puissance quatre, les conditions de victoires sont les mêmes et partagent du code en commun : l'alignement de jetons.  
> 
> La classe abstraite `AbstractLineAlignementEvaluator` est donc là pour structurer les évaluateurs qui testeraient des alignements et pour avoir une seule fonction centralisée pour tester l'alignement. 
> Les évaluateurs qui hérite de cette classe servent uniquement à définir comment utiliser cette fonction.

## III. Le développement des fonctionnalités manquantes

Pour les fonctionnalités manquantes, j'ai encore modifié la structure du code existant pour faciliter ces ajouts.

Cela passe déjà par la création de Factory, qui permette une création centralisée des différentes classes.

Egalement, pour les communications entre les vues et les controlleurs, j'ai mis en place un pattern Observer. 
A chaque évenement nécessitant de rafraichir la vue, les fonctions écoutant cet évenement sont notifiées.
J'ai choisi ce pattern, car il permet également de "brancher" dessus un gestionnaire de sauvegarde : en effet, il me suffit simplement d'écouter l'évenement `Play` pour sauvegarder l'état de la partie.