// For more information see https://aka.ms/fsharp-console-apps

open GameEngine.Model

let sceneDefinition:SceneDefinition =
  { SpriteSets =[
      SpriteSet.FromImage "Images/redBrick.png"
      SpriteSet.FromImage "Images/yellowBrick.png"
      SpriteSet.FromImage "Images/greenBrick.png"
    ]
    GameObjects = [
      { Id = "" ; SpriteSetName = "redBrick" ; SpriteAnimationSequence = [0] ; Position = { X = 2 ; Y = 2 } }
      { Id = "" ; SpriteSetName = "redBrick" ; SpriteAnimationSequence = [0] ; Position = { X = 96 ; Y = 2 } }
      { Id = "" ; SpriteSetName = "redBrick" ; SpriteAnimationSequence = [0] ; Position = { X = 190 ; Y = 2 } }
      { Id = "" ; SpriteSetName = "yellowBrick" ; SpriteAnimationSequence = [0] ; Position = { X = 2 ; Y = 48 } }
      { Id = "" ; SpriteSetName = "yellowBrick" ; SpriteAnimationSequence = [0] ; Position = { X = 96 ; Y = 48 } }
      { Id = "" ; SpriteSetName = "yellowBrick" ; SpriteAnimationSequence = [0] ; Position = { X = 190 ; Y = 48 } }
      { Id = "" ; SpriteSetName = "greenBrick" ; SpriteAnimationSequence = [0] ; Position = { X = 2 ; Y = 94 } }
      { Id = "" ; SpriteSetName = "greenBrick" ; SpriteAnimationSequence = [0] ; Position = { X = 96 ; Y = 94 } }
      { Id = "" ; SpriteSetName = "greenBrick" ; SpriteAnimationSequence = [0] ; Position = { X = 190 ; Y = 94 } }
      
    ]
  }

GameEngine.Startup.create "Farkanoid" 800 600 sceneDefinition
