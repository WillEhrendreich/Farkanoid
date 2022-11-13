// For more information see https://aka.ms/fsharp-console-apps

open GameEngine.Model

let sceneDefinition =
  let brickWidth = 92
  let brickHeight = 44
  
  let brickRow spriteSetName y =
   {0..7}
    |> Seq.map(fun i ->
      { Id = "" ; SpriteSetName = spriteSetName ; SpriteAnimationSequence = [0] ; Position = { X = 2 + i * (brickWidth + 2); Y = y } }
    )
    |> Seq.toList
    
  let rows = [ "redBrick" ; "yellowBrick" ; "greenBrick" ]
  
  { SpriteSets =[
      SpriteSet.FromImage "Images/redBrick.png"
      SpriteSet.FromImage "Images/yellowBrick.png"
      SpriteSet.FromImage "Images/greenBrick.png"
    ]
    GameObjects =
      rows
      |> List.mapi(fun row color ->
        brickRow color (2 + (brickHeight + 2) * row)
      )
      |> List.concat
  }

GameEngine.Startup.create "Farkanoid" 800 600 sceneDefinition
