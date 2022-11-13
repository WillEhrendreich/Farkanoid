// For more information see https://aka.ms/fsharp-console-apps

open GameEngine.Model

let sceneDefinition:SceneDefinition =
  { SpriteSets =[
      SpriteSet.FromImage "Images/redBrick.png"
      SpriteSet.FromImage "Images/greenBrick.png"
    ]
    GameObjects = [
      { Id = "" ; SpriteSetName = "redBrick" ; SpriteAnimationSequence = [0] ; Position = { X = 100 ; Y = 100 } }
    ]
  }

printfn "Hello from F#"