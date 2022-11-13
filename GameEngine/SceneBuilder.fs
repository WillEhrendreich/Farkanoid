module GameEngine.SceneBuilder

open GameEngine.Model

exception FromStripNotImplementedException

type TextureSet =
  { Name: string
    Textures: OpenGl.Texture.T list 
  }

let createScene gl sceneDefinition : Scene =
  let spriteSets =
    sceneDefinition.SpriteSets
    |> List.map (fun (name,source) ->
      (
        name,
        match source with
          | SpriteSource.FromImages images ->
            images
            |> List.map(fun filename ->
              let texture = OpenGl.Texture.create gl filename
              texture
            )
          | SpriteSource.FromStrip _ -> raise FromStripNotImplementedException
      )  
    )
    |> Map.ofList
  
  { GameObjects =
      sceneDefinition.GameObjects
      |> List.map (fun god ->
        { Id = god.Id
          Sprite =
            { Textures = spriteSets[god.SpriteSetName]
              AnimationSequence = god.SpriteAnimationSequence
              CurrentFrame = 0
            }
          Position = god.Position
        }
      )
  }