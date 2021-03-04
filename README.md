# FactoryTrial

Just testing kind of "Factory Pattern" in simple Unity3D project. This implementation has also pooling feature for gameobjects. Instantiating and destroying game objects in unity is a very expensive process, so re-using them might help pain a bit. However, it should be kept in mind that pooling decreases CPU overhead during the gameplay but increases memory footprlnt. 

## Features in current version
- GameObjectFactory is managing list of readily instantiated gameobjects ("pool")
- object spawner can order instantiated gameobjects from "factory"
- object spawner can return used gameobjects back to "factory". No need to destroy objects after use.
- gameobject ("Enemy" prefab in this case) uses event/delegate to inform spawner to put it back to pool

## Known issues / non-implemented features
- Factory gameobject pool has only initial size in use -> need to implement mechanisms to increase pool size up to maximum limit
- There will be error if pool is empty and spawner tries to get another instance (will be fixed soon)
- Error handling mostly missing  

## !Under Construction!
