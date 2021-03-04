# FactoryTrial

Just testing kind of "Factory Pattern" in simple Unity3D project. This implementation has also pooling feature for gameobjects. Instantiating and destroying game objects in unity is a very expensive process, so re-using them might help pain a bit. However, it should be kept in mind that pooling decreases CPU overhead during the gameplay but increases memory footprlnt. 

## Features in current version
- GameObjectFactory is managing list of readily instantiated gameobjects ("pool")
- List size increases automatically based on demand (creates new gameobjects to pool when close to the limit)
- object spawner can order instantiated gameobjects from "factory"
- object spawner can return used gameobjects back to "factory". No need to destroy objects after use.
- gameobject ("Enemy" prefab in this case) uses event/delegate to inform spawner to put it back to pool

## Known issues / non-implemented features
- Factory gameobject pool size has no maximum size limitation in use yet. Need to figure out what is best way to implement that. 

## !Under Construction!
