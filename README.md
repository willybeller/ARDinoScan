# DinoScan AR

Application de réalité augmentée permettant de scanner des images de dinosaures et d'afficher des modèles 3D interactifs.

## 👥 Contributeurs

- **Willy Beller** 
- **Enzo Bochsler** 
- **Colin Dufeutrelle** 

## 🎯 Cibles d'images

L'application reconnaît 3 images de dinosaures :

### 1. Pachycephalasaurus
![Pachycephalasaurus](https://raw.githubusercontent.com/willybeller/ARDinoScan/refs/heads/main/ImagesCibles/Pachy.png)

### 2. Stegasaurus  
![Stegasaurus](https://raw.githubusercontent.com/willybeller/ARDinoScan/refs/heads/main/ImagesCibles/Stega.png)

### 3. Velociraptor
![Velociraptor](https://raw.githubusercontent.com/willybeller/ARDinoScan/refs/heads/main/ImagesCibles/Raptor.png)


## 🦕 Fonctionnalités

- **Reconnaissance d'images** : Scannez des cartes ou images de dinosaures
- **Modèles 3D** : Visualisation de dinosaures en réalité augmentée
- **Animations interactives** : Contrôlez les animations des dinosaures
- **Effets sonores** : Sons réalistes pour chaque dinosaure
- **Interface intuitive** : Boutons pour déclencher différentes actions

## 🛠️ Technologies

- **Unity 2022.3+** : Moteur de jeu
- **Vuforia** : SDK de réalité augmentée
- **C#** : Scripts et logique de jeu
- **Android** : Plateforme cible

## 📱 Installation

1. Clonez le projet
2. Ouvrez dans Unity 2022.3 ou version ultérieure
3. Configurez Vuforia avec votre licence
4. Buildez pour Android (API Level 29+)

## 🎮 Utilisation

1. Lancez l'application sur votre appareil Android
2. Pointez la caméra vers une image de dinosaure
3. Le modèle 3D apparaît en réalité augmentée
4. Utilisez les boutons pour déclencher animations et sons

## 📂 Structure

- `Assets/FerociousIndustries/` : Modèles 3D et animations des dinosaures
- `Assets/Scenes/` : Scènes Unity principales
- `Assets/test_lancement.cs` : Script principal de contrôle AR
- `Assets/XR/` : Configuration Vuforia et cibles d'images

---

*Développé avec Unity et Vuforia*
