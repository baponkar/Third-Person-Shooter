![Unity2020badge](https://img.shields.io/badge/Unity-2020-orange)
![C#badge](https://img.shields.io/badge/C-%23-brightgreen)

# [Third Person Shooter](https://github.com/baponkar/third-person-shooter)
## Version-1.0.0

![ScreenShts1](/ScreenShots/Screenshot_1.png)
![ScreenShts2](/ScreenShots/Screenshot_2.png)
![ScreenShts3](/ScreenShots/Screenshot_3.png)



This Unity Package has a Third Person Shooter Player which can shoot anything by raycast weapon.Currently it has set up with two types weapon i.e. pistol and assult rifle but if you want you can use any type weapon but it has need to record animation for that kind weapon.

I made this package by watching  ['Kiwi Coder'](https://www.youtube.com/c/TheKiwiCoder)s tutorials in YouTube.

The [Demo Video](https://www.youtube.com/watch?v=LJ2huf30TLQ) for this pacakge.

This package also dependent on following packges :

1. Cinemachine
2. Animation Rigging
3. [Unity Standard-Assets-Character](https://github.com/Unity-Technologies/Standard-Assets-Characters)
4. [Guns Pack : Low Poly Guns Collection](https://assetstore.unity.com/packages/3d/props/guns/guns-pack-low-poly-guns-collection-192553#publisher)
5. [Human Character (Free Sample Pack)](https://assetstore.unity.com/packages/3d/characters/human-characters-free-sample-pack-181554) by wolf3d
6. [Polygon Starter Pack](https://assetstore.unity.com/packages/3d/props/polygon-starter-pack-low-poly-3d-art-by-synty-156819#description)
7. [Unity Particle Pack](https://assetstore.unity.com/packages/essentials/tutorial-projects/unity-particle-pack-127325#description)

So you need to import above packages except third from 'Unity Asset store' as I have removed from my
package to save memory.Although you need to download 'Standard Asset Character' from here.
You can't download or import 5th asset as it is removed from asset store so I have to put used character model in this package.


## Technical Info :

* There is no settings need if you place Player prefab in your scene.(Currently it has some issue!)

* You need to see this short video to put a Player_2 prefab in your scene or you just follow this

1. Remove MainCamera from your scene.
2. Put 'MainCamera',"Player_Follow_Free_Look_Cam","--UI--"(optional), and "Player_2" in your scene.
3. Then set Player_2 in Follow section and set "Camera_Look" from Player_2 in "Look At" Section of "Player_Follow_Free_Look_Cam".
4. Now Set "Rig Controller" of CharacterLocomotion Script,"MainCamera" of CameraAim Script,"Player Camera","Raycast Target"
 "Weapon Right Grip","Weapon Left Grip" and "Rig Controller" from the Scene's Hierarchy "Player_2".
5. Set Multi Aim Constraint's "Source Object" of "Spine_Aim", "Spine1_Aim", "Head_Aim","Weapon_Pose" with "Raycast_Target".
6. Go To Edit->Project Preference->Time  and set Fixed Timestep to 0.01, Maximum Allowed Timestep to 0.1,Time Scale to 1 and Maximum Particle Timestep to 0.03
7. Go To Edit->Project Preference->Input Manager and off Snap of Horizontal and Vertical's by remove corresponding tick.

Now you are ready to basic movement of Player2 but if you want Weapon effect then you need to put weapon_pickup or pistol_pickup in your scene and go to playmode.

If you want to use the scripts in other scripts you need to mention "using Baponkar.ThirdPerson.Shooter" in your scripts.



## Issues :
1. You may see some aiming issue with player prefab I will try to remove those issue in coming upgrade package.
2. You may see some weired position of the player in near of the weapon pickup or inside of the houses.
3. The Recoil effects not works properly.
4. Some wired movement during sprinting and jumping.
5. Some Cinemachine Camera follow snaping issue.
6. Current Cinemachine also showing two error it will not affect to this package's work. It may be go away by upgrading Cinemachine package.
7. There is no reload option is not added.


## License :
Read License from [here](/LICENSE.txt) .
You can use it for non commercial purpose  but if you want to use it for commarcial purpose then you need to donate minimum $1 before using it.

![Donation](/Assets/baponkar_Third_Person_Shooter/Image/frame.png) or [here](https://github.com/sponsors/baponkar)

## Unity Version
Unity 2020.3.15f2 or higher version.

## Contact : [Email](gamingjam60@gmail.com) , @baponkar


